import { OwnerDto } from "./owner-dto.interface";

export interface PropertyDto {
   id: string,
   name: string,
   address: string,
   price: number,
   registrationDate: string,
   owner: OwnerDto []
}
