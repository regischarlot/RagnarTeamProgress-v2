import { Component, OnInit } from '@angular/core';
import { RagnarService } from '../../service/RagnarService.service';
import { Exchange } from 'src/app/models/exchange';

@Component({
  selector: 'app-exchanges',
  templateUrl: './exchanges.component.html',
  styleUrls: ['./exchanges.component.scss']
})

export class ExchangesComponent implements OnInit {

  public displayedColumns = ["idColumn", "nameColumn", "addressColumn"];
  private selectedRowIndex: number = -1;
  private editedRow = null;
  private _exchanges: Exchange[];
  public lat: number;
  public lng: number;

  constructor(public ragnarService: RagnarService) {
    this.ragnarService.GetFoundation().subscribe(data => { 
      if (data != null) {
        this._exchanges = data.data.exchanges; 
      };
    });
  }

  ngOnInit() {
  }

  public highlight(row) {
    this.selectedRowIndex = row.id;
    this.lat = +row.latitude;
    this.lng = +row.longitude;
  }
}
