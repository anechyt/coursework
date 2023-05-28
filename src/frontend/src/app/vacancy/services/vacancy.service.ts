import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { ResponseModel } from "../../shared/models/ResponseModel";
import { environment } from "../../../environments/environment";
import { Vacancy } from "../models/vacancy";

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

  public createVacancy(): Observable<Vacancy> {
    return this.httpClient.get<ResponseModel<Vacancy>>(`${environment.baseUrl}/Vacancy/`)
      .pipe(map((data) => {
        return data.items;
      }));
  }
}
