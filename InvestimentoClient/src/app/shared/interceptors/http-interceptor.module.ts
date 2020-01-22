import { Injectable, NgModule } from '@angular/core';
import {
 HttpEvent,
 HttpInterceptor,
 HttpHandler,
 HttpRequest,
} from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';
import { constantes } from '../constantes';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {
    const token = sessionStorage.getItem(constantes.storageKeys.TOKEN);
    if (token) {
      const dupReq = req.clone({
        headers: req.headers.set('authorization', 'Bearer ' + token),
      });
      return next.handle(dupReq);
    } else {
      return next.handle(req);
    }
  }
}

@NgModule({
  declarations: [],
  imports: [],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
  ],
})
export class HttpInterceptorModule { }
