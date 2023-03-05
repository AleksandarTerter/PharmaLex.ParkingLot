import { ParkingService } from './parking.service';
import { TestBed } from '@angular/core/testing';

describe('ParkingService', () => {
  let service: ParkingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParkingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
