import { Component, OnInit } from '@angular/core';
import { RagnarService } from '../../service/RagnarService.service';
import { LegRunner } from 'src/app/models/legRunner';
import { TableDataSource, ValidatorService } from 'angular4-material-table';
import { LegRunnerValidatorService } from './leg-runner-validator.service';
import { DataFoundation } from 'src/app/models/dataFoundation';
import { Runner } from 'src/app/models/runner';

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
  private _legRunners: LegRunner[];
  private _foundation: DataFoundation;

  constructor(public ragnarService: RagnarService, private legRunnerValidator: ValidatorService) {
    this.ragnarService.GetFoundation().subscribe(data => { 
      if (data != null) {
        this._foundation = data.data;
        this._legRunners = this._foundation.legRunners; 
        this.dataSource = new TableDataSource<any>(data.data.legRunners, LegRunner, this.legRunnerValidator);
      };
    });
  }

  ngOnInit() {
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
  }

  public CancelRowEdit(row){
    row.cancelOrDelete();
  }

  public onRunnerChange($event, runner){
    var r: Runner =  this._foundation.runners.find(x => x.id == $event.value);
    if (r && this.editedRow){
      if (runner == 1)
      {
        this.editedRow.originalData.runner1Id = $event.value;
        this.editedRow.originalData.runner1Name = r.displayName;
        this.editedRow.originalData.runner1Pace = r.pace;
        this.editedRow.originalData.runner1Cell = r.cell;
      }
      if (runner == 2)
      {
        this.editedRow.originalData.runner2Id = $event.value;
        this.editedRow.originalData.runner2Name = r.displayName;
        this.editedRow.originalData.runner2Pace = r.pace;
        this.editedRow.originalData.runner2Cell = r.cell;
      }
      this.editedRow.originalData.pace = Math.min(this.editedRow.originalData.runner1Pace, this.editedRow.originalData.runner2Pace);


    }
  }
}

