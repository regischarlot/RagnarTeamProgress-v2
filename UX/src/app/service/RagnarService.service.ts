import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { RagnarResponse } from './ragnar-response';
import { Observable } from '@rxjs/rx';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RagnarService {

  constructor(private http: HttpClient, private apiService: ApiService) { }
  
  public GetFoundation(): Observable<RagnarResponse> {
    const response = this.apiService
      .get(`d3/foundation`)
      .catch(this.handleError);
    return response;
  }

  public CreateRunner(name: string, displayname: string, pace: number, cell: string, email: string, emergencycontact: string, type: number): Observable<RagnarResponse> {
    const response = this.apiService
      .put(`d3/runner`, { "name": name, "displayname":displayname, "pace": pace, "cell": cell, "email": email, "emergencycontact": emergencycontact, "type": type })
      .catch(this.handleError);
    return response;
  }

  public UpdateRunner(id: number, name: string, displayname: string, pace: number, cell: string, email: string, emergencycontact: string, type: number): Observable<RagnarResponse> {
    const response = this.apiService
      .post(`d3/runner`, { "id": id, "name": name, "displayname":displayname, "pace": pace, "cell": cell, "email": email, "emergencycontact": emergencycontact, "type": type })
      .catch(this.handleError);
    return response;
  }

  public handleError(err: any, caught: Observable<any>): any
  {
    throw err;
  }
}



