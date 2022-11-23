import { Route } from '@angular/router';
import { PropertyListComponent } from './property-list.component';

export const routePropertyListPage: Route = {
  path: 'properties',
  component: PropertyListComponent,
  data: {
    name: 'Properties',
  },
};
