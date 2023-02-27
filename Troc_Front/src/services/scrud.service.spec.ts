import { TestBed } from '@angular/core/testing';

import { ScrudService } from './scrud.service';

describe('ScrudService', () => {
  let service: ScrudService<T>;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
