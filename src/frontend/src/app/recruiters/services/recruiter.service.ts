import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Recruiter } from "../models/recruiter";

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

  public createRecruiter(recruiterRequest: Recruiter): Observable<Recruiter> {
    return this.httpClient.post<Recruiter>(`${environment.baseUrl}/Recruiter/create`, JSON.stringify(recruiterRequest), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }));
  }

  public getRecruiterByUserGID(userGID: string): Observable<Recruiter> {
    return this.httpClient.get<Recruiter>(`${environment.baseUrl}/Recruiter/recruiterbyusergid?userGID=${userGID}`)
      .pipe(map((data) => {
        return data;
    }));
  }
}
