import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidatorService } from 'angular4-material-table';

@Injectable()
export class RunnerValidatorService implements ValidatorService {
  getRowValidator(): FormGroup {
    return new FormGroup({
      'id': new FormControl(),
      'name': new FormControl(),
      'displayName': new FormControl(),
      'pace': new FormControl(),
      'cell': new FormControl(),
      'email': new FormControl(),
      'emergencyContact': new FormControl(),
      'type': new FormControl()
    });
  }
}
