import { Component } from '@angular/core';
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
@Component({
  selector: 'app-editappointment',
  templateUrl: './editappointment.component.html',
  styleUrls: ['./editappointment.component.scss'],
})
export class EditappointmentComponent {
  bookingForm: UntypedFormGroup;
  isDisabled = true;
  formdata = {
    first: 'Pooja',
    last: 'Sarma',
    gender: 'Femenino',
    mobile: '123456789',
    address: '101, Elanxa, New Yourk',
    email: 'test@example.com',
    dob: '1987-02-17T14:22:18Z',
    doctor: 'Dr.Rajesh',
    doa: '2018-05-25T14:22:18Z',
    timeSlot: 'slot5',
    injury: 'Fever',
    note: 'No Comments',
    uploadFile: '',
  };
  constructor(private fb: UntypedFormBuilder) {
    this.bookingForm = this.createContactForm();
  }
  onSubmit() {
    console.log('Form Value', this.bookingForm.value);
  }
  createContactForm(): UntypedFormGroup {
    return this.fb.group({
      first: [
        this.formdata.first,
        [Validators.required, Validators.pattern('[a-zA-Z]+')],
      ],
      last: [this.formdata.last],
      gender: [this.formdata.gender, [Validators.required]],
      mobile: [this.formdata.mobile, [Validators.required]],
      address: [this.formdata.address],
      email: [
        this.formdata.email,
        [Validators.required, Validators.email, Validators.minLength(5)],
      ],
      dob: [this.formdata.dob, [Validators.required]],
      doctor: [this.formdata.doctor, [Validators.required]],
      doa: [this.formdata.doa, [Validators.required]],
      timeSlot: [this.formdata.timeSlot, [Validators.required]],
      injury: [this.formdata.injury],
      note: [this.formdata.note],
      uploadFile: [this.formdata.uploadFile],
    });
  }
}
