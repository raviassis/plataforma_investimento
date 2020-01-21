import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterComponent } from './register.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { of } from 'rxjs';

describe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterComponent ],
      providers: [
        { provide: NgxSpinnerService, useClass: NgxSpinnerServiceMock},
        { provide: Router, useClass: RouterMock},
        { provide: AuthService, useClass: AuthServiceMock}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Deve registrar Usuario', () => {
    const email = 'ravi@gmail.com';
    const token = 'token';
    component.email = email;
    component.password = '123';

    const spinnerService = TestBed.get(NgxSpinnerService);
    const spySpinnerShow = spyOn(spinnerService, 'show');
    const spySpinnerHide = spyOn(spinnerService, 'hide');

    const authService = TestBed.get(AuthService);
    spyOn(authService, 'register').and.returnValue(of({email, token}));

    const router = TestBed.get(Router);
    const spyRouter = spyOn(router, 'navigateByUrl');

    component.register();

    expect(spySpinnerShow).toHaveBeenCalled();
    expect(spySpinnerHide).toHaveBeenCalled();
    expect(spyRouter).toHaveBeenCalled();
  });
});

class NgxSpinnerServiceMock {
  show(): any {}
  hide(): any {}
}

class AuthServiceMock {
  register(): any {}
}

class RouterMock {
  navigateByUrl() {}
}
