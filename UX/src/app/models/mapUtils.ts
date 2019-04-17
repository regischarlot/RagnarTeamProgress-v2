import { } from 'reflect-metadata';

const jsonMetadataKey = "jsonProperty";

export interface IJsonMetaData<T> {
    name?: string,
    clazz?: {new(): T}
}

export function JsonProperty<T>(metadata?:IJsonMetaData<T>|string): any {
    if (metadata instanceof String || typeof metadata === "string"){
        return Reflect.metadata(jsonMetadataKey, {
            name: metadata,
            clazz: undefined
        });
    } else {
        let metadataObj = <IJsonMetaData<T>>metadata;
        return Reflect.metadata(jsonMetadataKey, {
            name: metadataObj ? metadataObj.name : undefined,
            clazz: metadataObj ? metadataObj.clazz : undefined
        });
    }
}

export class MapUtils {
	static isPrimitive(obj) {
        switch (typeof obj) {
            case "string":
            case "number":
            case "boolean":
                return true;
        }
        return !!(obj instanceof String || obj === String ||
        obj instanceof Number || obj === Number ||
        obj instanceof Boolean || obj === Boolean);
    }
	
	static getClazz(target: any, propertyKey: string): any {
		return Reflect.getMetadata("design:type", target, propertyKey)
	}
	
	static getJsonProperty<T>(target: any, propertyKey: string):  IJsonMetaData<T> {
		return Reflect.getMetadata(jsonMetadataKey, target, propertyKey);
	}

    static isArray(object) {
        if (object === Array) {
            return true;
        } else if (typeof Array.isArray === "function") {
            return Array.isArray(object);
        }
        else {
            return !!(object instanceof Array);
        }
    }

    static deserialize<T>(clazz:{new(): T}, jsonObject) {
        if ((clazz === undefined) || (jsonObject === undefined)) return undefined;
        let obj = new clazz();
        Object.keys(obj).forEach((key) => {
            let propertyMetadataFn:(IJsonMetaData) => any = (propertyMetadata)=> {
                let propertyName = propertyMetadata.name || key;
                let innerJson = jsonObject ? jsonObject[propertyName] : undefined;
                let clazz = this.getClazz(obj, key);
                if (MapUtils.isArray(clazz)) {
                    let metadata = this.getJsonProperty(obj, key);
                    if (metadata.clazz || MapUtils.isPrimitive(clazz)) {
                        if (innerJson && MapUtils.isArray(innerJson)) {
                            return innerJson.map(
                                (item)=> MapUtils.deserialize(metadata.clazz, item)
                            );
                        } else {
                            return undefined;
                        }
                    } else {
                        return innerJson;
                    }

                } else if (!MapUtils.isPrimitive(clazz)) {
                    return MapUtils.deserialize(clazz, innerJson);
                } else {
                    return jsonObject ? jsonObject[propertyName] : undefined;
                }
            };

            let propertyMetadata = this.getJsonProperty(obj, key);
            if (propertyMetadata) {
                obj[key] = propertyMetadataFn(propertyMetadata);
            } else {
                if (jsonObject && jsonObject[key] !== undefined) {
                    obj[key] = jsonObject[key];
                }
            }
        });
        return obj;
    }
}