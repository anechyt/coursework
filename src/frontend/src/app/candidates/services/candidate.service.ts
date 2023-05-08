import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Candidate } from "../models/candidate";

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private httpClient: HttpClient) { }

}
