import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface ParkedVehicle {
  licensePlate: string;
  dateTimeOfEntry: Date;
  currentAccumulatedCharge: number;
  calculatedDiscount: number;
}

@Injectable({
  providedIn: 'root'
})
export class ParkingService {
  private serviceUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.serviceUrl = `${baseUrl}parkinglot`;
  }

  public GetAvailableSpaces() : Observable<number> {
    return this.http.get<number>(`${this.serviceUrl}/getavailablespaces`).pipe(
    );
  }

  public GetInfoAllParked() : Observable<ParkedVehicle[]> {
    return this.http.get<ParkedVehicle[]>(`${this.serviceUrl}/getinfoallparked`).pipe(
    );
  }
}
