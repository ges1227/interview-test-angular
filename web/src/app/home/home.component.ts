import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NotFoundError } from 'rxjs';

interface Student {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  major: string;
  averageGrade: number;
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public students: Student[] = [];
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Student[]>(baseUrl + 'students').subscribe({
      next: (result) => {
        this.students = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() { }

  getGradeClass(averageGrade: number): string {
    const bestGrade = 1;
    const worstGrade = 6;
    const range = worstGrade - bestGrade;
    const bestGradeLimit = bestGrade + range * (1 - 0.8);
    const mediumGradeLimit = bestGrade + range * (1 - 0.5);
    if (mediumGradeLimit < averageGrade) {
      return 'grade-red';
    }

    if (mediumGradeLimit > averageGrade && averageGrade >= bestGradeLimit) {
      return 'grade-orange';
    }

    return 'grade-green';
  }

  deleteStudent(student: Student) {
    // Sent delete request to server
    this.http.delete(this.baseUrl + 'students', { body: student }).subscribe({
      next: (response) => {

        if (response == false) {
          console.error('Failed to delete student', response);
        } else {
          console.log('Student deleted successfully', response);

          // Update the students list on successful delte
          this.http.get<Student[]>(this.baseUrl + 'students').subscribe({
            next: (result) => {
              this.students = result;
            },
            error: (error) => {
              console.error(error);
            },
          });

        }

      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
  }
}
