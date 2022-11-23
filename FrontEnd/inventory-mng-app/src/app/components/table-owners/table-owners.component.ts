import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { OwnerModel } from 'src/app/model/owner-model';
import { OwnerListService } from 'src/app/services/owner-list.service';

@Component({
  selector: 'app-table-owners',
  templateUrl: './table-owners.component.html',
  styleUrls: ['./table-owners.component.css']
})
export class TableOwnersComponent implements OnInit {

  public page = 1;
  public pageSize = 4;
  public ownerList: OwnerModel[] = [];
  private subscription!: Subscription;

  constructor(private ownerListService: OwnerListService) { }

  ngOnInit(): void {

    this.ownerListService.getOwners().pipe(
      tap(data => this.ownerList = data)
    ).subscribe();

    // this.ownerList = this.ownerListService.getOwners();
    this.subscription = this.ownerListService.ownersChanged.subscribe(
      (owners: OwnerModel[]) => {
        this.ownerList = owners;
      }
    );
  }

  onEditOwner(id: string) {
    this.ownerListService.startedEditing.next(id);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
