import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Candidate } from "../../candidates/models/candidate";
import { ResponseModel } from "../../shared/models/ResponseModel";

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  constructor(private httpClient: HttpClient) { }

  public getCandidatesNearbyRecruiter(userGID: string, maxDistance: number): Observable<Candidate[]> {
    return this.httpClient.get<ResponseModel<Candidate[]>>(`${environment.baseUrl}/Recruiter/candidatesnearby?userGID=${userGID}&maxDistance=${maxDistance}`)
      .pipe(map((data) => {
        return data.items;
      }));
  }

  public getCandidates():Observable<Candidate[]> {
    return this.httpClient.get<Candidate[]>(`${environment.baseUrl}/Candidates/candidates`)
      .pipe(map((data) => {
        return data;
      }))
  }
}
