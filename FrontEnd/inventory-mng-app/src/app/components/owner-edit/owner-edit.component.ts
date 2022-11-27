import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { OwnerListService } from 'src/app/services/owner-list.service';
import { OwnerModel } from './../../model/owner-model';

@Component({
  selector: 'app-owner-edit',
  templateUrl: './owner-edit.component.html',
  styleUrls: ['./owner-edit.component.css']
})
export class OwnerEditComponent implements OnInit {

  @ViewChild('f', { static: false }) slForm!: NgForm;

  subscription!: Subscription;
  editMode = false;
  editedOwnerId!: string;
  editedOwner!: OwnerModel;
  property!: number;

  constructor(private ownerListService: OwnerListService) { }

  ngOnInit() {

    this.subscription = this.ownerListService.startedEditing.subscribe(
      (ownerId: string) => {
        this.editedOwnerId = ownerId;

        this.ownerListService.getOwnerById(ownerId)
        .pipe(
          tap(data => {
            this.editedOwner = data;
            this.editMode = true;
            this.slForm.setValue({
              id: this.editedOwner.id,
              name: this.editedOwner.name,
              surname: this.editedOwner.surname,
              phoneNumber: this.editedOwner.phoneNumber
            });
          })
      ).subscribe();
      }
    );

  }

  onSubmit(form: NgForm) {
    const value = form.value;

    if (this.editMode) {
      let updatedOwner: OwnerModel = {
        id: form.value.id,
        name: form.value.name,
        surname: form.value.surname,
        phoneNumber: form.value.phoneNumber,
      }

      this.ownerListService.updateOwner(updatedOwner).subscribe();

    } else {
      let newOwner = {
        name: form.value.name,
        surname: form.value.surname,
        phoneNumber: form.value.phoneNumber,
      }
      this.ownerListService.addOwner(newOwner).subscribe();
    }
    window.location.reload();
    this.editMode = false;
    form.reset();
  }

  onClear() {
    this.slForm.reset();
    this.editMode = false;
  }

  onDelete() {
    if(this.editedOwnerId)
    this.ownerListService.deleteOwner(this.editedOwnerId).subscribe();
    window.location.reload();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
