import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { ResponseModel } from "../../shared/models/ResponseModel";
import { CandidateView } from "../../candidates/models/candidate-view";

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

  public getCandidatesNearbyRecruiter(userGID: string, maxDistance: number): Observable<CandidateView[]> {
    return this.httpClient.get<ResponseModel<CandidateView[]>>(`${environment.baseUrl}/Recruiter/candidatesnearby?userGID=${userGID}&maxDistance=${maxDistance}`)
      .pipe(map((data) => {
        return data.items;
      }));
  }

  public getCandidates():Observable<CandidateView[]> {
    return this.httpClient.get<CandidateView[]>(`${environment.baseUrl}/Candidates/candidates`)
      .pipe(map((data) => {
        return data;
      }))
  }

  public getCandidatesBySkills(skills: string[]): Observable<CandidateView[]> {
    return this.httpClient.post<CandidateView[]>(`${environment.baseUrl}/Candidates/candidatesbyskills`, JSON.stringify(skills), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }))
  }

  public getCandidatesByBio(bio: string[]): Observable<CandidateView[]> {
    return this.httpClient.post<CandidateView[]>(`${environment.baseUrl}/Candidates/candidatesbybio`, JSON.stringify(bio), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }))
  }

  public getCandidatesByResume(resume: string[]): Observable<CandidateView[]> {
    return this.httpClient.post<CandidateView[]>(`${environment.baseUrl}/Candidates/candidatesbyresume`, JSON.stringify(resume), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }))
  }
}
