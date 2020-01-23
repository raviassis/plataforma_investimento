import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SharesComponent } from './shares.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { QuoteService } from 'src/app/services/quote.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { of } from 'rxjs';

describe('SharesComponent', () => {
  let component: SharesComponent;
  let fixture: ComponentFixture<SharesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SharesComponent ],
      imports: [MatTableModule],
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
        {provide: QuoteService, useClass: QuoteServiceMock},
        {provide: MatDialog, useClass: MatDialogMock}
      ],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SharesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get quotes', () => {
    const returnService = [{ id: 'string', name: 'nome', value: 15 }];
    const service = TestBed.get(QuoteService);
    spyOn(service, 'getQuotes').and.returnValue(of(returnService));
    component.getQuotes();

    expect(component.dataSource.data).toBe(returnService);
    expect(component.dataSource.data.length).toBe(returnService.length);
  });

});

class QuoteServiceMock {
  getQuotes() { return of(); }
}

class MatDialogMock {
  open() { }
}
