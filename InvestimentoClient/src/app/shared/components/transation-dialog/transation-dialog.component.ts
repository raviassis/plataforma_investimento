import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface TransationDialogData {
  name: string;
  value: string;
  number: number;
}

@Component({
  selector: 'app-transation-dialog',
  templateUrl: './transation-dialog.component.html',
  styleUrls: ['./transation-dialog.component.scss']
})
export class TransationDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<TransationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TransationDialogData
  ) { }

  ngOnInit() {
  }

}
