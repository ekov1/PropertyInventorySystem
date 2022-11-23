import { Route } from '@angular/router';
import { OwnersListComponent } from './owners-list.component';

export const routeOwnersListPage: Route = {
  path: 'owners',
  component: OwnersListComponent,
  data: {
    name: 'Owners',
  },
};
