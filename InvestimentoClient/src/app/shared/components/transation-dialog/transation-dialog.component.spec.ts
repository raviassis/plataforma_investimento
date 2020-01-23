import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TransationDialogComponent } from './transation-dialog.component';

describe('TransationDialogComponent', () => {
  let component: TransationDialogComponent;
  let fixture: ComponentFixture<TransationDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TransationDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TransationDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
