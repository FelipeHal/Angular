import { AccountService } from './../services/account.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    // if (request.url.indexOf(environment.UrlPrincipal) >= 0) {
    //   if (!this.accountService.isTokenExpired()) {

    //     return next.handle(
    //       request.clone({ setHeaders: { 'authorization':  } })
    //     );
    //   }
    // }

    return next.handle(request);
  }
}
