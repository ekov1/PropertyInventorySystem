import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OwnerDto } from 'src/app/model/api/owner-dto.interface';
import { CreateOwnerRestTemplate } from '../model/request/create-owner-rest-template.interface';
import { UpdateOwnerRestTemplate } from '../model/request/update-owner-rest-template.interface';

@Injectable({
  providedIn: 'root'
})
export class OwnerClient {

  public readonly apiURL: string = 'https://localhost:7194/api/Owner';

  constructor(private http: HttpClient) { }

  //TODO:
  public getOwnerById(ownerId: string): Observable<OwnerDto> {
    return this.http.get<OwnerDto>(
      this.apiURL + + ownerId
    );
  }

  public getAllOwners(): Observable<OwnerDto[]> {
    return this.http.get<OwnerDto[]>(
      this.apiURL
    );
  }

  public addOwner(createOwnerTemplate: CreateOwnerRestTemplate): Observable<OwnerDto> {
    return this.http.post<OwnerDto>(
      this.apiURL,
      createOwnerTemplate
    );
  }

  public updateOwner(updateOwnerTemplate: UpdateOwnerRestTemplate): Observable<OwnerDto> {
    return this.http.post<OwnerDto>(
      this.apiURL,
      updateOwnerTemplate
    );
  }

  public deleteOwner(id: string): Observable<OwnerDto> {
    return this.http.delete<OwnerDto>(
      this.apiURL
    );
  }
}
