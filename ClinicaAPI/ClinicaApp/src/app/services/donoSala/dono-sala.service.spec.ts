import { TestBed } from '@angular/core/testing';

import { DonoSalaService } from './dono-sala.service';

describe('DonoSalaService', () => {
  let service: DonoSalaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DonoSalaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
