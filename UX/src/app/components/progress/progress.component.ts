import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { RagnarService } from '../../service/RagnarService.service';
import { TableDataSource, ValidatorService } from 'angular4-material-table';
import { LegRunnerValidatorService } from './leg-runner-validator.service';

import { DataFoundation } from 'src/app/models/dataFoundation';
import { LegRunner } from 'src/app/models/legRunner';
import { Runner } from 'src/app/models/runner';
import { DataSource } from '@angular/cdk/table';

@Component({
  selector: 'app-progress',
  templateUrl: './progress.component.html',
  styleUrls: ['./progress.component.scss'],
  providers: [{provide: ValidatorService, useClass: LegRunnerValidatorService }]
})
export class ProgressComponent implements OnInit {

  public displayedColumns = ["legOrderColumn", "distanceColumn", "difficultyColumn", "runner1Name", "runner2Name", "runner1Cell", "paceColumn", "startTimeColumn", "endTimeColumn", "legTimeColumn", "truePaceColumn", "actionsColumn"];
  private selectedRowIndex: number = -1;
  private editedRow = null;
  private dataSource: TableDataSource<LegRunner>;
  private _foundation: DataFoundation;

  //@ViewChild(MatTable) table: MatTable<LegRunner>;

  constructor(public ragnarService: RagnarService, private legRunnerValidator: ValidatorService, private changeDetectorRefs: ChangeDetectorRef) {
    this.LoadData();
  }

  ngOnInit() {
  }

  public LoadData() {
    this.ragnarService.GetFoundation().subscribe(data => { 
      if (data != null) {
        this._foundation = data.data;
        this.dataSource = new TableDataSource<LegRunner>(this._foundation.legRunners, LegRunner, this.legRunnerValidator);
        this.changeDetectorRefs.detectChanges();
      };
    });
  }

  public highlight(row) {
    this.selectedRowIndex = row.id;
  }

  public EditRow(row){
    if (this.editedRow != null && this.editedRow != row)
      this.editedRow.cancelOrDelete();
    row.startEdit();
    this.editedRow = row;
  }

  public DeleteRow(row){
    row.cancelOrDelete();
    this.editedRow = null;
  }

  public SaveRowEdit(row){
    row.confirmEditCreate();
    this.AdjustRow(row);
    }

  public CancelRowEdit(row){
    row.cancelOrDelete();
  }

  public AdjustRow(row){

    /*
    var n: number = this.dataSource.currentData.find(x => x == row);

    this.dataSource.currentData[n].difficulty = 5;
    this.table.renderRows();

    var r: Runner = this._foundation.runners.find(x => x.id == row.currentData.runner1Id);
    if (r != null)
    {
      row.currentData.runner1Name = r.displayName;
      row.currentData.runner1Pace = r.pace;
      row.currentData.runner1Cell = r.cell;
    }
    r = this._foundation.runners.find(x => x.id == row.currentData.runner2Id);
    if (r != null)
    {
      row.currentData.runner2Name = r.displayName;
      row.currentData.runner2Pace = r.pace;
      row.currentData.runner2Cell = r.cell;
    }
    row.currentData.pace = Math.min(row.currentData.runner1Pace, row.currentData.runner2Pace);
    */
  }
}

