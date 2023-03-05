import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingInfoComponent } from './parking-info.component';

describe('ParkingInfoComponent', () => {
  let component: ParkingInfoComponent;
  let fixture: ComponentFixture<ParkingInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParkingInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParkingInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
