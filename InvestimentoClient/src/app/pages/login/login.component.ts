import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { constantes } from 'src/app/shared/constantes';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginSpinnerName = 'login';
  email: string;
  password: string;
  msgError: any;
  returnUrl: string;

  constructor(
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  public login() {
    this.msgError = '';
    this.spinner.show(this.loginSpinnerName);
    this.authService.login(this.email, this.password)
        .subscribe(
          (res) => {
            this.router.navigateByUrl(this.returnUrl);
            this.spinner.hide(this.loginSpinnerName);
          },
          (err) => {
            if (err.status === 401) {
              this.msgError = constantes.texts.INCORRECT_LOGIN;
            } else {
              this.msgError = err.error.message;
            }
            this.spinner.hide(this.loginSpinnerName);
          },
          () => { this.spinner.hide(this.loginSpinnerName); },
        );
  }

}
