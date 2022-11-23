import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-sort',
  templateUrl: './sort.component.html',
  styleUrls: ['./sort.component.css']
})
export class SortComponent implements OnInit {

  @Input()
  sortingList: any[] = [];

  @Input()
  key!: string;

  @Input()
  title!: string;

  isDesc = false;

  showSortList = false;

  ngOnInit(): void { };

  public sortByKey(sortingList: any[], key: string, desc: boolean = false) {

    if (desc) {
      sortingList = sortingList.sort(function (a, b) {
        let x = a[key]; let y = b[key];
        return ((x < y) ? -1 : ((x > y) ? 1 : 0));
      }).reverse();

      return sortingList;
    }

    sortingList = sortingList.sort(function (a, b) {
      let x = a[key]; let y = b[key];
      return ((x < y) ? -1 : ((x > y) ? 1 : 0));
    });

    return sortingList;
  }
}
