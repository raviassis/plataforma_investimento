import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-accout',
  templateUrl: './accout.component.html',
  styleUrls: ['./accout.component.scss']
})
export class AccoutComponent implements OnInit {
  balance: number;
  depositValue: number;
  drawValue: number;

  constructor() { }

  ngOnInit() {
  }

  getAccount() {
    
  }

  deposit() {

  }

}
