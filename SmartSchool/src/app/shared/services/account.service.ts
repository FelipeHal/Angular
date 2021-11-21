import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { catchError, delay, lastValueFrom, map, of } from 'rxjs';

import { environment } from 'src/environments/environment';
import { LoginModel } from '../models/account/login-model';
import { SignInModel } from '../models/account/signin-model';

@Injectable({
    providedIn: 'root'
})
export class AccountService {

    baseUrl = `${environment.UrlPrincipal}/Account`;

    private get username(): string {
      return localStorage.getItem('username');
    }
    private set username(value: string) {
      if (value) {
        localStorage.setItem('username', value);
      }
      else {
        localStorage.removeItem('username');
      }
    }

    private get token(): string {
      return localStorage.getItem('token');
    }
    private set token(value: string) {
      if (value) {
        localStorage.setItem('token', value);
      }
      else {
        localStorage.removeItem('token');
      }
    }

    private get refreshToken(): string {
      return localStorage.getItem('refreshToken');
    }
    private set refreshToken(value: string) {
      if (value) {
        localStorage.setItem('refreshToken', value);
      }
      else {
        localStorage.removeItem('refreshToken');
      }
    }

    constructor(private router: Router, private http: HttpClient, private jwtHelper: JwtHelperService) { }

    public isAuthenticated(): boolean {
      return this.username !== null;
    }

    public isTokenExpired(): boolean {
      return (this.token !== null && this.jwtHelper.isTokenExpired(this.token))
    }

    public async authenticate(model: LoginModel): Promise<string> {
        return await lastValueFrom(
          this.http
            .post<SignInModel>(this.baseUrl, model)
            .pipe(
                map((res: SignInModel) => {

                  this.username = res.username;
                  this.token = res.token;
                  this.refreshToken = res.refreshToken;

                    if (model.remmeberMe) {
                      console.log('REMEMBER ME!');
                    }

                    setTimeout(() => {
                      this.router.navigate(['/alunos']);
                    }, 2000);

                    return 'ok';
                }),

                catchError((error: HttpErrorResponse) => {
                    switch (error.status) {
                        case 401:
                            return of('invalid');
                        default:
                            console.log(error);
                            return of('error');
                    }
                })
            )
        );
    }

    public async tryRefreshToken(): Promise<string> {
        return await lastValueFrom(
            this.http
              .post<SignInModel>(`${this.baseUrl}/RefreshToken`, {
                username: this.username ?? '',
                refreshToken: this.refreshToken ?? ''
              })
              .pipe(
                  map((res: SignInModel) => {

                    this.token = res.token;
                    this.refreshToken = res.refreshToken;


                      return this.token;
                  }),

                  catchError((error: HttpErrorResponse) => {
                      switch (error.status) {
                          case 401:
                              return of('invalid');
                          default:
                              console.log(error);
                              return of('error');
                      }
                  })
              )
          );
    }

    public logoff(): boolean {
      localStorage.removeItem('token');
      return this.username == null;
    }
}
