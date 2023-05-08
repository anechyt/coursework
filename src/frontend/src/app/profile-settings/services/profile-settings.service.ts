import { Injectable } from '@angular/core';
import { map, Observable } from "rxjs";
import { Recruiter } from "../../recruiters/models/recruiter";
import { environment } from "../../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Candidate} from "../../candidates/models/candidate";

@Injectable({
  providedIn: 'root'
})
export class ProfileSettingsService {

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
  public createCandidate(candidateRequest: Candidate): Observable<Candidate> {
    return this.httpClient.post<Candidate>(`${environment.baseUrl}/Candidates/create`, JSON.stringify(candidateRequest), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }));
  }
}
