import { JsonProperty } from './mapUtils';

export class Pair
{
    @JsonProperty('id')
    public id: number;
    @JsonProperty('name')
    public name: string;
}