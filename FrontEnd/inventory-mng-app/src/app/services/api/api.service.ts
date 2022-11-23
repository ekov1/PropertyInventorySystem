import { Injectable } from '@angular/core';
import { OwnerDto } from 'src/app/model/api/owner-dto.interface';
import { PropertyDto } from 'src/app/model/api/property-dto.interface';
import { OwnerModel } from 'src/app/model/owner-model';
import { PropertyModel } from 'src/app/model/property.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }

  toOwnerModel(ownerDto: OwnerDto): OwnerModel {
    return <OwnerModel>{
      id: ownerDto.id,
      name: ownerDto.name,
      phoneNumber: ownerDto.phoneNumber,
      surname: ownerDto.surname
    }
  }

  toPropertyModel(propertyDto: PropertyDto): PropertyModel {
    return <PropertyModel>{
      id: propertyDto.id,
      address: propertyDto.address,
      name: propertyDto.name,
      owner: propertyDto.owner,
      price: propertyDto.price,
      registrationDate: new Date(propertyDto.registrationDate)
    }
  }
}
