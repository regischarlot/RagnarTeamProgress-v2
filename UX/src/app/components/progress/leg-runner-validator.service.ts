import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidatorService } from 'angular4-material-table';

@Injectable()
export class LegRunnerValidatorService implements ValidatorService {
  getRowValidator(): FormGroup {
    return new FormGroup({
      'id': new FormControl(),
      'order': new FormControl(),
      'van': new FormControl(),
      'distance': new FormControl(),
      'difficulty': new FormControl(),
      'teamId': new FormControl(),
      'legRunnerId': new FormControl(),
      'runner1Id': new FormControl(),
      'runner1Name': new FormControl(),
      'runner1Pace': new FormControl(),
      'runner1Cell': new FormControl(),
      'runner2Id': new FormControl(),
      'runner2Name': new FormControl(),
      'runner2Pace': new FormControl(),
      'runner2Cell': new FormControl(),
      'pace': new FormControl(),
      'truePace': new FormControl(),
      'startTime': new FormControl(),
      'startTimeEstimated': new FormControl(),
      'endTime': new FormControl(),
      'endTimeEstimated': new FormControl(),  
      'legTime': new FormControl(),
      'legMap': new FormControl()
      });
  }
}
