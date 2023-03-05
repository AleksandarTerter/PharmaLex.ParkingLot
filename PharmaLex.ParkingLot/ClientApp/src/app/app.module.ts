import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgModule } from '@angular/core';
import { ParkingInfoComponent } from './parking-info/parking-info.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ParkingInfoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'parking-info', component: ParkingInfoComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
