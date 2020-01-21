import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { constantes } from 'src/app/shared/constantes';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerSpinnerName = 'register';
  email: string;
  password: string;
  msgError: any;
  returnUrl = '/';

  constructor(
    private spinner: NgxSpinnerService,
    private router: Router,
    private authService: AuthService
  ) { }

  ngOnInit() {
  }

  public register() {
    this.msgError = '';
    this.spinner.show(this.registerSpinnerName);
    this.authService.register(this.email, this.password)
        .subscribe(
          (res) => {
            this.router.navigateByUrl(this.returnUrl);
            this.spinner.hide(this.registerSpinnerName);
          },
          (err) => {
            if (Array.isArray(err.error)) {
              err.error.forEach(e => {
                this.msgError += e.description + '\n';
              });
            } else {
              this.msgError = err.error;
            }

            this.spinner.hide(this.registerSpinnerName);
          },
          () => { this.spinner.hide(this.registerSpinnerName); },
        );
  }

}
