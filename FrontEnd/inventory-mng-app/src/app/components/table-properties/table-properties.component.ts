import { Observable, Subscription } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { PropertyModel } from 'src/app/model/property.model';
import { PropertyListService } from 'src/app/services/property-list.service';

@Component({
  selector: 'app-table-properties',
  templateUrl: './table-properties.component.html',
  styleUrls: ['./table-properties.component.css']
})
export class TablePropertiesComponent implements OnInit {

  public page = 1;
  public pageSize = 4;

  propertiesList: PropertyModel[] = [];
  private subscription!: Subscription;

  constructor(private propertyListService: PropertyListService) {}

  ngOnInit() {
    this.propertiesList = this.propertyListService.getProperties();
    this.subscription = this.propertyListService.propertiesChanged.subscribe(
      (properties: PropertyModel[]) => {
        this.propertiesList = properties;
      }
    );
  }

  onEditProperty(id: string) {
    this.propertyListService.startedEditing.next(id);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
