import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { OwnerDto } from '../model/api/owner-dto.interface';
import { OwnerModel } from '../model/owner-model';
import { OwnerClient } from './owner.client';
import { ApiService } from './api/api.service';
import { map } from 'rxjs/operators';
import { CreateOwnerRestTemplate } from '../model/request/create-owner-rest-template.interface';
import { UpdateOwnerRestTemplate } from '../model/request/update-owner-rest-template.interface';


@Injectable({
  providedIn: 'root'
})
export class OwnerListService {

  ownersChanged = new Subject<OwnerModel[]>();
  startedEditing = new Subject<string>();
  
  constructor(
    private ownerClient: OwnerClient,
    private apiService: ApiService) {
  }

  getOwners(): Observable<OwnerModel[]> {
    return this.ownerClient.getAllOwners().pipe(
      map<OwnerDto[], OwnerModel[]>(
        ownerList => ownerList.map(ownerDto => this.apiService.toOwnerModel(ownerDto))
      )
    );
  }

  public getOwnerById(id: string): Observable<OwnerModel> {
    
    return this.ownerClient
      .getOwnerById(id)
      .pipe(
        map<OwnerDto, OwnerModel>((ownerDto) =>
          this.apiService.toOwnerModel(ownerDto)
        )
      );
  }

  addOwner(owner: CreateOwnerRestTemplate): Observable<OwnerModel> {
    return this.ownerClient.addOwner(owner)
      .pipe(
        map<OwnerDto, OwnerModel>((ownerDto) =>
          this.apiService.toOwnerModel(ownerDto)
        )
      )
  }

  updateOwner(owner: UpdateOwnerRestTemplate): Observable<OwnerModel> {
    return this.ownerClient.updateOwner(owner)
      .pipe(
        map<OwnerDto, OwnerModel>((ownerDto) =>
          this.apiService.toOwnerModel(ownerDto)
        )
      )
  }

  deleteOwner(id: string) {
    return this.ownerClient.deleteOwner(id);
  }

}
