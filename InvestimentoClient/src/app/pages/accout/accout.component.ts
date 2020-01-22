import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { MatDialog } from '@angular/material/dialog';
import { config } from 'rxjs';

@Component({
  selector: 'app-accout',
  templateUrl: './accout.component.html',
  styleUrls: ['./accout.component.scss']
})
export class AccoutComponent implements OnInit {
  account;
  depositValue: number;
  drawValue: number;

  constructor(
    private accountService: AccountService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.getAccount();
  }

  getAccount() {
    this.accountService.getAccount()
        .subscribe(
          (res) => {
            this.account = res;
          },
          () => {},
          () => {}
        );
  }

  deposit() {
    this.accountService.deposit(this.account.id, this.depositValue)
      .subscribe(
        (res) => {
          this.account = res;
          this.depositValue = undefined;
        },
        () => {},
        () => {}
      );

  }

  drawOut() {
    this.accountService.drawOut(this.account.id, this.drawValue)
        .subscribe(
          (res) => {
            this.account = res;
            this.drawValue = undefined;
          },
          () => {},
          () => {}
        );
  }

}
