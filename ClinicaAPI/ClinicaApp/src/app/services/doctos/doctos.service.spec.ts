import { TestBed } from '@angular/core/testing';

import { DoctosService } from './doctos.service';

describe('DoctosService', () => {
  let service: DoctosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
