import { ParkedVehicle, ParkingService } from './../parking.service';

import { Component } from '@angular/core';
import { zip } from 'rxjs';

@Component({
  selector: 'app-parking-info',
  templateUrl: './parking-info.component.html',
  styleUrls: ['./parking-info.component.css'],
})
export class ParkingInfoComponent {
  public isRefreshing: boolean = true;
  public freeParkingSpaces: number = 0;
  public parkedVehicles: ParkedVehicle[] = [];

  constructor(private parkingService: ParkingService) {
    this.refreshInfo();
  }

  public refreshInfo(): void {
    this.isRefreshing = true;
    const getAvailableSpaces = this.parkingService.GetAvailableSpaces();
    const getInfoAllParked = this.parkingService.GetInfoAllParked();
    zip(getAvailableSpaces, getInfoAllParked).subscribe((r) => {
      this.freeParkingSpaces = r[0];
      this.parkedVehicles = r[1];
      this.isRefreshing = false;
    });
  }
}
