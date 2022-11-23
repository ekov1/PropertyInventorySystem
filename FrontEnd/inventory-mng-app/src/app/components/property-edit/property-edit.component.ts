import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { PropertyModel } from 'src/app/model/property.model';
import { PropertyListService } from 'src/app/services/property-list.service';

@Component({
  selector: 'app-property-edit',
  templateUrl: './property-edit.component.html',
  styleUrls: ['./property-edit.component.css']
})
export class PropertyEditComponent implements OnInit {

  @ViewChild('f', { static: false }) slForm!: NgForm;

  subscription!: Subscription;
  editMode = false;
  editedPropertyId: string = '';
  editedProperty!: PropertyModel;
  property!: number;

  constructor(private propertyListService: PropertyListService) { }

  ngOnInit() {
    this.subscription = this.propertyListService.startedEditing.subscribe(
      (propertyId: string) => {
        this.editedPropertyId = propertyId;
        this.editMode = true;
        this.editedProperty = this.propertyListService.getPropertyByPropertyId(propertyId)!;
        if (this.editedProperty) {
          this.slForm.setValue({
            id: this.editedProperty.id,
            name: this.editedProperty.name,
            address: this.editedProperty.address,
            price: this.editedProperty.price
          });
        }
      }
    );
  }

  onSubmit(form: NgForm) {
    const value = form.value;
    let newProperty: PropertyModel = {
      id: form.value.id,
      address: form.value.address,
      name: form.value.name,
      price: form.value.price,
    }

    if (this.editMode) {
      this.propertyListService.updateProperty(this.editedPropertyId, newProperty);
    } else {
      this.propertyListService.addProperty(newProperty);
    }
    this.editMode = false;
    form.reset();
  }

  onClear() {
    this.slForm.reset();
    this.editMode = false;
  }

  onDelete() {
    this.propertyListService.deleteProperty(this.editedPropertyId);
    this.onClear();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
