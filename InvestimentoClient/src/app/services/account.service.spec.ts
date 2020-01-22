import { TestBed } from '@angular/core/testing';

import { AccountService } from './account.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

describe('AccountService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: HttpClient, useValue: {}},
      { provide: Router, useValue: {}}
    ]
  }));

  it('should be created', () => {
    const service: AccountService = TestBed.get(AccountService);
    expect(service).toBeTruthy();
  });
});
