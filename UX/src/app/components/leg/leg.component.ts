
import { Component, OnInit, ViewChild, Inject, enableProdMode, NgModule } from '@angular/core';
import { DataFoundation } from 'src/app/models/dataFoundation';
import { LegRunner } from 'src/app/models/legRunner';
import { RagnarService } from '../../service/RagnarService.service';
import { BrowserModule } from '@angular/platform-browser';
import { CollectionView } from 'wijmo/wijmo';
import * as wjcGrid from 'wijmo/wijmo.grid';

@Component({
  selector: 'app-leg',
  templateUrl: './leg.component.html',
  styleUrls: ['./leg.component.scss']
})
export class LegComponent implements OnInit {

  private _foundation: DataFoundation;
  public _data: CollectionView;
  public _runnerDict: wjcGrid.DataMap;

  constructor(public ragnarService: RagnarService) {
    this.LoadData();
  }

  ngOnInit() {
  }

  public LoadData() {
    this.ragnarService.GetFoundation().subscribe(data => {  
      if (data != null) {
        this._foundation = data.data;
        this._runnerDict = new wjcGrid.DataMap(data.data.runners, "id", "displayName");
        // Leg Runners
        let lr: LegRunner[] = data.data.legRunners;
        lr.forEach(function(value: LegRunner) {
          value.startTime = new Date(value.startTime);
          value.endTime = new Date(value.endTime);
        });
        this._data = new CollectionView(lr);
      } 
    });
  }

  private _formatRatingCell(cell: HTMLElement, rating: number) {
    let html = '<div aria-label="rating:' + rating + ' stars">';
    for (let i = 0; i < rating; i++) {
      html += '<span style="margin-right: 2px;" class="wj-glyph-circle"></span>';
    }
    html += '</div>';
    cell.innerHTML = html;
  }

  public onItemFormatter(panel, r, c, cell) {
    //check if it is a data cell, then check to see if it is the 'sales' column
    if (panel.cellType == wjcGrid.CellType.Cell) {
      if (panel.columns[c].binding == "difficulty")
        cell.style.color = "gold";
    }
  }

  initializeGrid(flex: wjcGrid.FlexGrid) {
    flex.formatItem.addHandler((s: any, e: wjcGrid.FormatItemEventArgs) => {
        if (e.panel == s.cells) {
            var item = s.rows[e.row].dataItem;
            switch (s.columns[e.col].binding) {
                case 'difficulty':
                    this._formatRatingCell(e.cell, item.difficulty);
                break;
                case 'startTime':
                  if (!item.startTimeEstimated)
                    e.cell.style.fontWeight = "900";
                break;
                case 'endTime':
                  if (!item.endTimeEstimated)
                    e.cell.style.fontWeight = "900";
                break;
            }
        }
    });
  }
}
