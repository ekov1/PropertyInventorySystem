import { OwnerModel } from "./owner-model";

export interface PropertyModel {
  id: string,
  name: string,
  address: string,
  price: number,
  owners?: OwnerModel[],
  registrationDate?: Date;
}
