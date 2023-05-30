import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { RecruiterResponse } from "../models/recruiter-response";

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  constructor(private httpClient: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public getRecruiterByUserGid(userGid: string): Observable<RecruiterResponse> {
    return this.httpClient.get<RecruiterResponse>(`${environment.baseUrl}/Recruiter/recruiterbyusergid?userGID=${userGid}`)
      .pipe(map((data) => {
        return data;
      }))
  }
}
