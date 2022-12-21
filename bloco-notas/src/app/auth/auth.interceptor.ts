import { Injectable } from '@angular/core';
import {
  HttpHandler,
  HttpHeaders,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { TokenService } from './services/token.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private _tokenService: TokenService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const token = this._tokenService.getToken();
    if (token) {
      var headers = new HttpHeaders();

      headers = new HttpHeaders({
        Authorization: 'Bearer ' + token.value,
      });

      if (headers != null) {
        req = req.clone({ headers: headers });
      }
    }
    return next.handle(req);
  }
}
