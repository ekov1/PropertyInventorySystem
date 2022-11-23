import { Component, Input, OnInit } from '@angular/core';
import { OwnerModel } from 'src/app/model/owner-model';

@Component({
  selector: 'app-owner-card',
  templateUrl: './owner-card.component.html',
  styleUrls: ['./owner-card.component.css']
})
export class OwnerCardComponent implements OnInit {

  @Input()
  ownerData!: OwnerModel;

  constructor() { }

  ngOnInit(): void {
  }

}
