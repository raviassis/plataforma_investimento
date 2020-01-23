import { Component, OnInit, ViewChild } from '@angular/core';
import { QuoteService } from 'src/app/services/quote.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { TransationDialogComponent } from 'src/app/shared/components/transation-dialog/transation-dialog.component';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { constantes } from 'src/app/shared/constantes';

@Component({
  selector: 'app-shares',
  templateUrl: './shares.component.html',
  styleUrls: ['./shares.component.scss']
})
export class SharesComponent implements OnInit {
  quotes;
  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ['name', 'value', 'act'];
  constructor(private quoteService: QuoteService, public dialog: MatDialog) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.getQuotes();
  }

  getQuotes() {
    this.quoteService.getQuotes()
      .subscribe(
        (res) => {
          this.quotes = res;
          this.dataSource = new MatTableDataSource<any>(res);
          this.dataSource.paginator = this.paginator;
          console.log(res);
        },
        () => {},
        () => {}
      );
  }

  openModal(data) {
    const dialogRef = this.dialog.open(TransationDialogComponent, {
      width: '250px',
      data
    });

    dialogRef.afterClosed()
      .subscribe((confirm) => {
        if (confirm) {
          this.quoteService.buy(data)
            .subscribe(
              (res) => {
                this.dialog.open(ConfirmDialogComponent, {
                  width: '250px',
                  data: { message: constantes.texts.BUY_QUOTE_EXECUTED }
                });
              },
              (err) => {
                this.dialog.open(ConfirmDialogComponent, {
                  width: '250px',
                  data: { message: constantes.texts.BUY_QUOTE_NOT_EXECUTED }
                });
              },
              () => {}
            );
        }
      });
  }

}
