import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Rx'
import { TRANSACTIONSERVICE_CONFIG } from './transaction.service-variables';
import 'rxjs/Rx';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';
import { HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { RagnarResponse } from './ragnar-response';


@Injectable()
export class ApiService {

    constructor(private http: HttpClient) { }

    public Headers(): HttpHeaders {
        return new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Cache-Control': 'no-cache',
            'Pragma': 'no-cache',
            'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT'
            });
    }

    private getJson(response: Response) {
        return response;
    }

    private checkForError(response: RagnarResponse): Response {
        if (response.success) {
            return response;
        } else {
            const error = new Error(response.errorMessage);
            error['response'] = response;
            throw error;
        }
    }

    private checkForSessionError(response: RagnarResponse): void {
        if (response.status === 401) {
            throw 'Session expired.';
        } 
    }

    get(path: string): Observable<any> {
        const url = `${TRANSACTIONSERVICE_CONFIG.apiEndpoint}${path}`;
        return this.http
            .get(url, { headers: this.Headers() })
            .map(this.getJson)
            .catch(err => {
                this.checkForSessionError(err);
                return Observable.throw(err);
            });
    }

    put(path: string, formData: any): Observable<any> {
        const url = `${TRANSACTIONSERVICE_CONFIG.apiEndpoint}${path}`;

        return this.http.put(url, formData, {  })
            .map(this.checkForError)
            .catch(err => {
                this.checkForSessionError(err);
                return Observable.throw(err);
            })
            .map(this.getJson);
    }

    post(path: string, formData: any): Observable<any> {
        const url = `${TRANSACTIONSERVICE_CONFIG.apiEndpoint}${path}`;

        return this.http.post(url, formData, {  })
            .map(this.checkForError)
            .catch(err => {
                this.checkForSessionError(err);
                return Observable.throw(err);
            })
            .map(this.getJson);
    }

    delete(path: string): Observable<any> {
        const url = `${TRANSACTIONSERVICE_CONFIG.apiEndpoint}${path}`;

        return this.http.delete(url, {  })
            .map(this.checkForError)
            .catch(err => {
                this.checkForSessionError(err);
                return Observable.throw(err);
            })
            .map(this.getJson);
    }
}
