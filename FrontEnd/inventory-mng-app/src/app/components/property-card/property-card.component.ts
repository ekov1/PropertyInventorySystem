import { Component, Input, OnInit } from '@angular/core';
import { PropertyModel } from 'src/app/model/property.model';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.css']
})
export class PropertyCardComponent implements OnInit {

  @Input()
  propertyData!: PropertyModel;

  constructor() { }

  ngOnInit(): void {
  }

}
