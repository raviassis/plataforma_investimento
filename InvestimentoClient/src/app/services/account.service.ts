import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AccountResponse } from './models/account.response';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl = environment.investimentoApiUrl;

  constructor(private http: HttpClient) { }

  getAccount(): Observable<AccountResponse> {
    const url = this.baseUrl + 'account/';
    return this.http.get<AccountResponse>(url);
  }

  deposit(id: string, value: number): Observable<AccountResponse> {
    const url = this.baseUrl + 'account/deposit';
    return this.http.post<AccountResponse>(url, {id, value});
  }

  drawOut(id: string, value: number): Observable<AccountResponse> {
    const url = this.baseUrl + 'account/drawout';
    return this.http.post<AccountResponse>(url, {id, value});
  }
}
