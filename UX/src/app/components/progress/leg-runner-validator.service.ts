import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidatorService } from 'angular4-material-table';

@Injectable()
export class LegRunnerValidatorService implements ValidatorService {
  getRowValidator(): FormGroup {
    return new FormGroup({
      'legMap': new FormControl(),
      'difficulty': new FormControl(),
      'distance': new FormControl(),
      'runner1Name': new FormControl(),
      'runner2Name': new FormControl(),
      'runner1Cell': new FormControl(),
      'pace': new FormControl(),
      'startTime': new FormControl(),
      'endTime': new FormControl(),
      'legTime': new FormControl(),
      'truePace': new FormControl()
    });
  }
}
