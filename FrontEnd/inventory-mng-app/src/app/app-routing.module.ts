import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { routeOwnersListPage } from './components/owners-list/owners-list.route';
import { routePropertyListPage } from './components/property-list/property-list.route';

const routes: Routes = [
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full',
  },
  routePropertyListPage,
  routeOwnersListPage,
  {
    path: '**',
    redirectTo: '',
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
