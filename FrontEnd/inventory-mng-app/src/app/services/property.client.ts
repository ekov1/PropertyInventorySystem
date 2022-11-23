import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyDto } from 'src/app/model/api/property-dto.interface';
import { CreatePropertyRestTemplate } from '../model/request/create-property-rest-template.interface';
import { UpdatePropertyRestTemplate } from '../model/request/update-property-rest-template.interface';

@Injectable({
  providedIn: 'root'
})
export class PropertyClient {

  public readonly apiURL: string = 'http://localhost:4200/properties/';

  constructor(private http: HttpClient) {
  }

  public getPropertyById(propertyId: string): Observable<PropertyDto> {
    return this.http.get<PropertyDto>(
      this.apiURL + propertyId
    );
  }

  public getAllProperties(): Observable<PropertyDto[]> {
    return this.http.get<PropertyDto[]>(
      this.apiURL + 'get/all'
    );
  }

  public getPropertyByOwnerId(ownerId: string): Observable<PropertyDto[]> {
    return this.http.get<PropertyDto[]>(
      this.apiURL + 'owner/' + ownerId
    );
  }

  public deleteProperty(propertyId: string): Observable<PropertyDto> {
    return this.http.delete<PropertyDto>(
      this.apiURL + 'delete/by/id/' + propertyId
    );
  }

  public createProperty(createPropertyTemplate: CreatePropertyRestTemplate): Observable<PropertyDto> {
    return this.http.post<PropertyDto>(
      this.apiURL + 'property/create',
      createPropertyTemplate
    );
  }

  public updateProperty(updatePropertyTemplate: UpdatePropertyRestTemplate): Observable<PropertyDto> {
    return this.http.put<PropertyDto>(
      this.apiURL + 'property/update',
      updatePropertyTemplate
    );
  }
}
