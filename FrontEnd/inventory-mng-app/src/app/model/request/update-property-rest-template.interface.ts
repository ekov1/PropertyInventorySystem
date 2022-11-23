import { CreateOwnerRestTemplate } from "./create-owner-rest-template.interface";

export interface UpdatePropertyRestTemplate {
  name: string,
  address: string,
  price: number,
  registrationDate: Date,
  owner?: CreateOwnerRestTemplate []
}
