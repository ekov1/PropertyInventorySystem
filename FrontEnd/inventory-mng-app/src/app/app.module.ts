import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PropertyEditComponent } from './components/property-edit/property-edit.component';
import { PropertyListComponent } from './components/property-list/property-list.component';
import { PropertyCardComponent } from './components/property-card/property-card.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SortComponent } from './components/sort/sort.component';
import { OwnersListComponent } from './components/owners-list/owners-list.component';
import { OwnerCardComponent } from './components/owner-card/owner-card.component';
import { TablePropertiesComponent } from './components/table-properties/table-properties.component';
import { TableOwnersComponent } from './components/table-owners/table-owners.component';
import { OwnerEditComponent } from './components/owner-edit/owner-edit.component';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PropertyEditComponent,
    PropertyListComponent,
    PropertyCardComponent,
    SortComponent,
    OwnersListComponent,
    OwnerCardComponent,
    TablePropertiesComponent,
    TableOwnersComponent,
    OwnerEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
