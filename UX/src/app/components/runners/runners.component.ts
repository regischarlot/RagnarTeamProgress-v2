import { Component, OnInit } from '@angular/core';
import { RagnarService } from '../../service/RagnarService.service';
import { Runner } from 'src/app/models/runner';
import { TableDataSource, ValidatorService } from 'angular4-material-table';
import { RunnerValidatorService } from './runner-validator.service';

@Component({
  selector: 'app-runners',
  templateUrl: './runners.component.html',
  styleUrls: ['./runners.component.scss'],
  providers: [{provide: ValidatorService, useClass: RunnerValidatorService }]
})
export class RunnersComponent implements OnInit {

  public displayedColumns = ["nameColumn", "displayNameColumn", "paceColumn", "cellColumn", "emailColumn", "emergencyContactColumn", "typeColumn", "actionsColumn"];
  private selectedRowIndex: number = -1;
  private editedRow = null;
  private dataSource: TableDataSource<Runner>;
  private _runners: Runner[];

  constructor(public ragnarService: RagnarService, private runnerValidator: ValidatorService) {
    this.LoadData();
  }

  ngOnInit() {
  }

  public LoadData(){
    this.ragnarService.GetFoundation().subscribe(data => { 
      if (data != null) {
        this._runners = data.data.runners; 
        this.dataSource = new TableDataSource<any>(data.data.runners, Runner, this.runnerValidator);
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
    if (row.id > 0)
      this.ragnarService
        .UpdateRunner(row.currentData.id, row.currentData.name, row.currentData.displayName, row.currentData.pace, row.currentData.cell, row.currentData.email, row.currentData.emergencyContact, row.currentData.type)
        .subscribe(data => { 
          row.confirmEditCreate();
      });
    else
    this.ragnarService
      .CreateRunner(row.currentData.name, row.currentData.displayName, row.currentData.pace, row.currentData.cell, row.currentData.email, row.currentData.emergencyContact, row.currentData.type)
      .subscribe(data => { 
        row.confirmEditCreate();
    });
  }


  public CancelRowEdit(row){
    row.cancelOrDelete();
  }
}
