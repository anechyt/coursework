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
}
