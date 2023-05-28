import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { ResponseModel } from "../../shared/models/ResponseModel";
import { CandidatesResponse } from "../../candidates/models/candidates-response";

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  constructor(private httpClient: HttpClient) { }

  public getCandidatesNearbyRecruiter(userGID: string, maxDistance: number): Observable<CandidatesResponse[]> {
    return this.httpClient.get<ResponseModel<CandidatesResponse[]>>(`${environment.baseUrl}/Recruiter/candidatesnearby?userGID=${userGID}&maxDistance=${maxDistance}`)
      .pipe(map((data) => {
        return data.items;
      }));
  }

  public getCandidates():Observable<CandidatesResponse[]> {
    return this.httpClient.get<CandidatesResponse[]>(`${environment.baseUrl}/Candidates/candidates`)
      .pipe(map((data) => {
        return data;
      }))
  }
}
