import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { ResponseModel } from "../../shared/models/ResponseModel";
import { environment } from "../../../environments/environment";
import { Vacancy } from "../models/vacancy";
import { VacancyResponse } from "../models/vacancy-response";
import {CandidateView} from "../../candidates/models/candidate-view";

@Injectable({
  providedIn: 'root'
})
export class VacancyService {

  constructor(private httpClient: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public createVacancy(vacancyRequest: Vacancy): Observable<Vacancy> {
    return this.httpClient.post<Vacancy>(`${environment.baseUrl}/Vacancy/create`,  JSON.stringify(vacancyRequest), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }));
  }

  public getVacanciesByRecruiterGID(recruiterGID: string): Observable<VacancyResponse[]> {
    return this.httpClient.get<ResponseModel<VacancyResponse[]>>(`${environment.baseUrl}/Vacancy/vacanciesbyrecruitergid?recruiterGID=${recruiterGID}`)
      .pipe(map((data) => {
        return data.items;
      }));
  }

  public getVacancies(): Observable<VacancyResponse[]> {
    return this.httpClient.get<ResponseModel<VacancyResponse[]>>(`${environment.baseUrl}/Vacancy/vacancies`)
      .pipe(map((data) => {
        return data.items;
      }));
  }

  public getVacanciesNearbyCandidate(userGID: string, maxDistance: number): Observable<VacancyResponse[]> {
    return this.httpClient.get<ResponseModel<VacancyResponse[]>>(`${environment.baseUrl}/Vacancy/vacanciesnearby?userGID=${userGID}&maxDistance=${maxDistance}`)
      .pipe(map((data) => {
        return data.items;
      }));
  }
}
