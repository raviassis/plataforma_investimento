import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserResponse } from './models/user.response';
import { map, tap } from 'rxjs/operators';
import { constantes } from '../shared/constantes';
import * as jwt_decode from 'jwt-decode';

const helper = new JwtHelperService();

interface UserToken {
  email: string;
  id: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = environment.investimentoApiUrl;

  user: UserToken;

  constructor(
    private http: HttpClient,
    private router: Router) { }

  public login(email, password): Observable<UserResponse> {
    const url = this.baseUrl + 'usuarios/login';
    return this.authenticate(url, email, password);
  }

  public register(email, password): Observable<UserResponse> {
    const url = this.baseUrl + 'usuarios/criar';
    return this.authenticate(url, email, password);
  }

  private authenticate(url, email, password): Observable<UserResponse> {
    return this.http.post<UserResponse>(url, {email, password})
                      .pipe(
                        map((res) => {
                          if (res && res.token) {
                            this.carregarDadosToken();
                            sessionStorage.setItem(constantes.storageKeys.TOKEN, res.token);
                          }
                          return res;
                        }),
                      );
  }
  public carregarDadosToken() {
    const token = sessionStorage.getItem(constantes.storageKeys.TOKEN);
    if (token) {
      this.user = jwt_decode(token) as UserToken;
    } else {
      sessionStorage.removeItem(constantes.storageKeys.TOKEN);
    }
  }

  public logout() {
    sessionStorage.removeItem(constantes.storageKeys.TOKEN);
    this.router.navigateByUrl('/login');
  }

  public isAuthenticated(): boolean {
    const token = sessionStorage.getItem(constantes.storageKeys.TOKEN);
    // Check whether the token is expired and return
    // true or false
    return token && !helper.isTokenExpired(token);
  }
}
