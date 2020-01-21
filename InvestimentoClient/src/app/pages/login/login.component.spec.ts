import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent } from './login.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from 'src/app/services/auth.service';
import { of, Observable } from 'rxjs';
import { UserResponse } from 'src/app/services/models/user.response';

class ActivatedRouteMock {
  snapshot = {
    queryParams: {
      returnUrl: '/',
    }
  };
}

class NgxSpinnerServiceMock {
  show(): any {}
  hide(): any {}
}

class AuthServiceMock {
  login(): any {}
}

class RouterMock {
  navigateByUrl() {}
}

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      schemas: [ NO_ERRORS_SCHEMA ],
      providers: [
        { provide: Router, useClass: RouterMock},
        { provide: ActivatedRoute, useClass: ActivatedRouteMock },
        { provide: NgxSpinnerService, useClass: NgxSpinnerServiceMock },
        { provide: AuthService, useClass: AuthServiceMock }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Deve logar usuario', () => {
    const email = 'ravi@gmail.com';
    const token = 'token';
    component.email = email;
    component.password = '123';

    const spinnerService = TestBed.get(NgxSpinnerService);
    const spySpinnerShow = spyOn(spinnerService, 'show');
    const spySpinnerHide = spyOn(spinnerService, 'hide');

    const authService = TestBed.get(AuthService);
    spyOn(authService, 'login').and.returnValue(of({email, token}));

    const router = TestBed.get(Router);
    const spyRouter = spyOn(router, 'navigateByUrl');

    component.login();

    expect(spySpinnerShow).toHaveBeenCalled();
    expect(spyRouter).toHaveBeenCalled();
    expect(spySpinnerHide).toHaveBeenCalled();

  });
});
