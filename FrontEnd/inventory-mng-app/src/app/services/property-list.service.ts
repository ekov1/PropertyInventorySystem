import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { PropertyModel } from '../model/property.model';

@Injectable({
  providedIn: 'root'
})
export class PropertyListService {

  // constructor(private propertyClient: PropertyClient, private apiService: ApiService) {
  // }

  // public getPropertyById(propertyId: string): Observable<PropertyModel> {
  //   return this.propertyClient.getPropertyById(propertyId).pipe(
  //     map<PropertyDto, PropertyModel>(
  //       propDto => this.apiService.toPropertyModel(propDto)
  //     )
  //   );
  // }

  propertiesChanged = new Subject<PropertyModel[]>();
  startedEditing = new Subject<string>();
  private properties: PropertyModel[] = [
    {
      id: '235',
      address: 'Bulgaria',
      name: 'House',
      price: 100,
    },
    {
      id: '335',
      address: 'Spain',
      name: 'House',
      price: 100,
    },
     {
      id: '135',
      address: 'Malta',
      name: 'Apartment',
      price: 100,
    }
  ];

  getProperties() {
    return this.properties.slice();
  }

  getPropertyByPropertyId(id: string) {
    let prop = this.properties.filter(p => p.id === id)[0];
    return prop;
  }

  addProperty(property: PropertyModel) {
    this.properties.push(property);
    this.propertiesChanged.next(this.properties.slice());
  }

  addProperies(props: PropertyModel[]) {
    this.properties.push(...props);
    this.propertiesChanged.next(this.properties.slice());
  }

  updateProperty(propId: string, newProperty: PropertyModel) {

    let propToUpdateIndex = this.properties.findIndex(p => p.id === propId);

    this.properties[propToUpdateIndex] = newProperty;
    this.propertiesChanged.next(this.properties.slice());
  }

  deleteProperty(id: string) {
    this.properties = this.properties.filter(p => p.id !== id);
    this.propertiesChanged.next(this.properties.slice());
  }
}
