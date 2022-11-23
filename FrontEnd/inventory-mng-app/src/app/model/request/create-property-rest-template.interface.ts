import { CreateOwnerRestTemplate } from "./create-owner-rest-template.interface";

export interface CreatePropertyRestTemplate {
  name: string,
  address: string,
  price: number,
  registrationDate: Date,
  owner?: CreateOwnerRestTemplate []
}
