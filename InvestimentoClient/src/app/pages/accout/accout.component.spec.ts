import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccoutComponent } from './accout.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { of } from 'rxjs';
import { AccountResponse } from 'src/app/services/models/account.response';
import { MatTableModule } from '@angular/material/table';
import { QuoteService } from 'src/app/services/quote.service';
import { MatDialog } from '@angular/material/dialog';

describe('AccoutComponent', () => {
  let component: AccoutComponent;
  let fixture: ComponentFixture<AccoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccoutComponent ],
      schemas: [ NO_ERRORS_SCHEMA ],
      imports: [MatTableModule],
      providers: [
        { provide: AccountService, useClass: AccountServiceMock },
        { provide: QuoteService, useClass: QuoteServiceMock },
        { provide: MatDialog, useClass: MatDialogMock }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    const accountService = TestBed.get(AccountService);
    spyOn(accountService, 'getAccount').and.returnValue(of({}));

    const quoteService = TestBed.get(QuoteService);
    spyOn(quoteService, 'getOwnQuotes').and.returnValue(of([]));

    expect(component).toBeTruthy();
  });

  it('should get account', () => {
    const account = {id: 'string', balance: 0, userId: 'string'} as AccountResponse;
    const accountService = TestBed.get(AccountService);
    spyOn(accountService, 'getAccount').and.returnValue(of(account));

    component.getAccount();
    expect(component.account).toEqual(account);
  });

  it('should deposit value', () => {
    component.depositValue = 100;
    component.account = {id: 'string', balance: 0, userId: 'string'} as AccountResponse;
    const account = {id: 'string', balance: 100, userId: 'string'} as AccountResponse;

    const accountService = TestBed.get(AccountService);
    spyOn(accountService, 'deposit').and.returnValue(of(account));

    component.deposit();

    expect(component.account).toEqual(account);
    expect(component.depositValue).toBeFalsy();
  });

  it('should drawout value', () => {
    component.drawValue = 100;
    component.account = {id: 'string', balance: 500, userId: 'string'} as AccountResponse;
    const account = {id: 'string', balance: 400, userId: 'string'} as AccountResponse;

    const accountService = TestBed.get(AccountService);
    spyOn(accountService, 'drawOut').and.returnValue(of(account));

    component.drawOut();

    expect(component.account).toEqual(account);
    expect(component.drawValue).toBeFalsy();
  });
});

class AccountServiceMock {
  getAccount() {
    return of();
  }

  deposit() {
    return of();
  }

  drawOut() {  }
}

class QuoteServiceMock {
  getOwnQuotes() {
    return of();
  }
  sell(data) {}
}

class MatDialogMock {
  open() { }
}
