import { Component, OnInit } from '@angular/core';
import { RagnarService } from '../../service/RagnarService.service';
import { LegRunner } from 'src/app/models/legRunner';
import { TableDataSource, ValidatorService } from 'angular4-material-table';
import { LegRunnerValidatorService } from './leg-runner-validator.service';

@Component({
  selector: 'app-progress',
  templateUrl: './progress.component.html',
  styleUrls: ['./progress.component.scss'],
  providers: [{provide: ValidatorService, useClass: LegRunnerValidatorService }]
})
export class ProgressComponent implements OnInit {

  public displayedColumns = ["legMapColumn", "distanceColumn", "difficultyColumn", "runner1Name", "runner2Name", "runner1Cell", "pace", "startTime", "endTime", "legTime", "truePace", "actionsColumn"];
  private selectedRowIndex: number = -1;
  private editedRow = null;
  private dataSource: TableDataSource<LegRunner>;
  private _legRunners: LegRunner[];

  constructor(public ragnarService: RagnarService, private legRunnerValidator: ValidatorService) {
    this.ragnarService.GetFoundation().subscribe(data => { 
      if (data != null) {
        this._legRunners = data.data.legRunners; 
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
}
