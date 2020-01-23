import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QuoteResponse } from './models/quote.response';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {
  private baseUrl = environment.investimentoApiUrl;

  constructor(private http: HttpClient) { }

  getQuotes(): Observable<QuoteResponse[]> {
    const url = this.baseUrl + 'quotes';
    return this.http.get<QuoteResponse[]>(url);
  }

  buy(quote): Observable<any> {
    const url = this.baseUrl + 'quotes/buy';
    return this.http.post(url, quote);
  }
}
