import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/router';
import { routeOwnersListPage } from '../owners-list/owners-list.route';
import { routePropertyListPage } from '../property-list/property-list.route';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  routeOwnerListPage: Route = routeOwnersListPage;
  routePropertyListPage: Route = routePropertyListPage;


  constructor() { }

  ngOnInit(): void {
  }

}
