import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { PatientService } from '../../patient.service';
import {
  UntypedFormControl,
  Validators,
  UntypedFormGroup,
  UntypedFormBuilder,
} from '@angular/forms';
import { Patient } from '../../patient.model';

export interface DialogData {
  id: number;
  action: string;
  patient: Patient;
}

@Component({
  selector: 'app-form-dialog:not(i)',
  templateUrl: './form-dialog.component.html',
  styleUrls: ['./form-dialog.component.scss'],
})
export class FormDialogComponent {
  action: string;
  dialogTitle: string;
  patientForm: UntypedFormGroup;
  patient: Patient;
  constructor(
    public dialogRef: MatDialogRef<FormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    public patientService: PatientService,
    private fb: UntypedFormBuilder
  ) {
    // Set the defaults
    this.action = data.action;
    if (this.action === 'edit') {
      this.dialogTitle = data.patient.name;
      this.patient = data.patient;
    } else {
      this.dialogTitle = 'New Patient';
      const blankObject = {} as Patient;
      this.patient = new Patient(blankObject);
    }
    this.patientForm = this.createContactForm();
  }
  formControl = new UntypedFormControl('', [
    Validators.required,
    // Validators.email,
  ]);
  getErrorMessage() {
    return this.formControl.hasError('required')
      ? 'Required field'
      : this.formControl.hasError('email')
      ? 'Not a valid email'
      : '';
  }
  createContactForm(): UntypedFormGroup {
    return this.fb.group({
      id: [this.patient.personId],
      img: [this.patient.personImage64],
      name: [this.patient.name],
      gender: [this.patient.sexTypeId],
      date: [this.patient.birthdate],
      bGroup: [this.patient.docNumber],
      mobile: [this.patient.telephoneNumber],
      address: [this.patient.addressLocation],
      treatment: [''],
    });
  }
  submit() {
    // emppty stuff
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  public confirmAdd(): void {
    this.patientService.addPatient(this.patientForm.getRawValue());
  }
}
