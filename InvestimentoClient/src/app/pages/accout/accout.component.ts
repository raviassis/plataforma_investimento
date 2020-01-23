import { Component, OnInit, ViewChild } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { QuoteService } from 'src/app/services/quote.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { TransationDialogComponent } from 'src/app/shared/components/transation-dialog/transation-dialog.component';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { constantes } from 'src/app/shared/constantes';

@Component({
  selector: 'app-accout',
  templateUrl: './accout.component.html',
  styleUrls: ['./accout.component.scss']
})
export class AccoutComponent implements OnInit {
  account;
  depositValue: number;
  drawValue: number;

  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ['name', 'value', 'number', 'act'];

  constructor(
    private accountService: AccountService,
    private quoteService: QuoteService,
    public dialog: MatDialog
  ) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.getAccount();
    this.getOwnQuotes();
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

  getOwnQuotes() {
    this.quoteService.getOwnQuotes()
      .subscribe(
        (res) => {
          this.dataSource = new MatTableDataSource<any>(res);
          this.dataSource.paginator = this.paginator;
        }
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

  openModal(data) {
    const dialogRef = this.dialog.open(TransationDialogComponent, {
      width: '250px',
      data: data.quote,
    });

    dialogRef.afterClosed()
      .subscribe((confirm) => {
        if (confirm) {
          this.quoteService.sell(data)
            .subscribe(
              (res) => {
                this.dialog.open(ConfirmDialogComponent, {
                  width: '250px',
                  data: { message: constantes.texts.SELL_QUOTE_EXECUTED }
                });
                this.ngOnInit();
              },
              (err) => {
                this.dialog.open(ConfirmDialogComponent, {
                  width: '250px',
                  data: { message: constantes.texts.SELL_QUOTE_NOT_EXECUTED }
                });
              },
              () => {}
            );
        }
      });
  }

}
