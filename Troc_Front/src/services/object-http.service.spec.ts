import { TestBed } from '@angular/core/testing';

import { ObjectHttpService } from './object-http.service';

describe('ObjectHttpService', () => {
  let service: ObjectHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ObjectHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
