import { JwtInterceptor } from '@auth0/angular-jwt';
import { AccountService } from './../services/account.service';
import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { from, Observable, switchMap } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  private refreshTokenRequest: Observable<string> | null  = null;

  constructor(private accountService: AccountService, private jwtInterceptor: JwtInterceptor) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    if (this.jwtInterceptor.isAllowedDomain(request) && !this.jwtInterceptor.isDisallowedRoute(request)
      && this.accountService.isTokenExpired())
    {
      if (!this.refreshTokenRequest) {
        this.refreshTokenRequest = from(this.accountService.tryRefreshToken());
      }

      return this.refreshTokenRequest
        .pipe(
          switchMap(token => {
            this.refreshTokenRequest = null;
            return next.handle(
              request.clone({ setHeaders: { 'authorization': `Bearer ${token}`} })
            );
          })
        );
    }
    return next.handle(request);
  }
}
