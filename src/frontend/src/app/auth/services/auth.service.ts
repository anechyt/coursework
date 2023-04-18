import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { LoginResponse } from "../models/login-response";
import { LoginRequest } from "../models/login-request";
import { RegisterResponse } from "../models/register-response";
import { RegisterRequest } from "../models/register-request";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public login(loginRequest: LoginRequest): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>(`${environment.baseUrl}/Security/login`, JSON.stringify(loginRequest), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }));
  }

  public register(registerRequest: RegisterRequest): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>(`${environment.baseUrl}/Security/register`, JSON.stringify(registerRequest), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }));
  }
}
