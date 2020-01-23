import { TestBed } from '@angular/core/testing';

import { QuoteService } from './quote.service';
import { HttpClient } from '@angular/common/http';

describe('QuoteService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: HttpClient, useValue: {}},
    ]
  }));

  it('should be created', () => {
    const service: QuoteService = TestBed.get(QuoteService);
    expect(service).toBeTruthy();
  });
});
