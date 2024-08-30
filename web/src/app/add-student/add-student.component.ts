import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
})
export class AddStudentComponent {
  studentForm: FormGroup;
  submitted = false;
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.studentForm = this.formBuilder.group({
      firstName: ['', Validators['required']],
      lastName: ['', Validators['required']],
      email: ['', [Validators['required'], Validators.email]],
      major: ['', [Validators['required']]],
      averageGrade: ['', [Validators['required'], Validators.min(1), Validators.max(6)]],
    });
    this.http = http;
    this.baseUrl = baseUrl;
  }

  onSubmit() {
    this.submitted = true;

    if (this.studentForm.invalid) {
      console.log('Form is invalid.')
      return;
    }

    // If form is valid, log the data or send to a server
    this.http.post(this.baseUrl + 'students', this.studentForm.value).subscribe({
      next: (response) => {
        console.log('Student added successfully', response);
        
        // Reset the form after successful submission
        this.studentForm.reset();
        this.submitted = false;
      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
  }
}
