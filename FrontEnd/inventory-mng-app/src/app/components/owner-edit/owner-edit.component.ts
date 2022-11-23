import { OwnerModel } from './../../model/owner-model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { OwnerListService } from 'src/app/services/owner-list.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-owner-edit',
  templateUrl: './owner-edit.component.html',
  styleUrls: ['./owner-edit.component.css']
})
export class OwnerEditComponent implements OnInit {

  @ViewChild('f', { static: false }) slForm!: NgForm;

  subscription!: Subscription;
  editMode = false;
  editedOwnerId: string = '';
  editedOwner!: OwnerModel;
  property!: number;

  constructor(private ownerListService: OwnerListService) { }

  ngOnInit() {

    this.subscription = this.ownerListService.startedEditing.subscribe(
      (ownerId: string) => {
        console.log(ownerId);
        
        this.editedOwnerId = ownerId;
        this.editMode = true;
        this.ownerListService.getOwnerById(ownerId).pipe(
          tap((ownerData) => {this.editedOwner = ownerData!, console.log(ownerData) })
        )
        // this.editedOwner = this.ownerListService.getOwnerById(ownerId)!;
        console.log(this.editedOwner, 'edit');
        if (this.editedOwner) {
          this.slForm.setValue({
            id: this.editedOwner.id,
            name: this.editedOwner.name,
            surname: this.editedOwner.surname,
            phoneNumber: this.editedOwner.phoneNumber
          });
        }
      }
    );
  }

  onSubmit(form: NgForm) {
    const value = form.value;
    let newOwner: OwnerModel = {
      id: form.value.id,
      name: form.value.name,
      surname: form.value.surname,
      phoneNumber: form.value.phoneNumber,
    }

    // if (this.editMode) {
    //   this.ownerListService.updateOwner(this.editedOwnerId, newOwner);
    // } else {
    //   this.ownerListService.addOwner(newOwner);
    // }
    this.editMode = false;
    form.reset();
  }

  onClear() {
    this.slForm.reset();
    this.editMode = false;
  }

  onDelete() {
    // this.ownerListService.deleteOwner(this.editedOwnerId);
    this.onClear();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
