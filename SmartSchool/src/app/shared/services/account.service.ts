import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, delay, lastValueFrom, map, of } from 'rxjs';

import { environment } from 'src/environments/environment';
import { LoginModel } from '../models/account/login-model';

@Injectable({
    providedIn: 'root'
})
export class AccountService {

    baseUrl = `${environment.UrlPrincipal}/Account`;

    constructor(private router: Router, private http: HttpClient) { }

    public async authenticate(model: LoginModel): Promise<string> {
        return await lastValueFrom(
          this.http
            .post<boolean>(this.baseUrl, model)
            .pipe(
                map((res: boolean) => {

                    localStorage.setItem('username', model.username);

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
}
