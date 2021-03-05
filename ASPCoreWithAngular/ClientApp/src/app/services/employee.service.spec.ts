import { TestBed } from '@angular/core/testing';

import { PersonalService } from './personal.service';

describe('EmployeeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PersonalService = TestBed.get(PersonalService);
    expect(service).toBeTruthy();
  });
});
