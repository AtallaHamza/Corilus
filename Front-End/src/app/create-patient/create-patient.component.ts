import { Component, OnInit } from '@angular/core';
import { Patient } from '../models/patient.model';
import { Router } from '@angular/router';
import { PatientService } from '../patient.service';
import { PatientListComponent } from '../patient-list/patient-list.component';

@Component({
  selector: 'app-create-patient',
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.css']
})
export class CreatePatientComponent implements OnInit {
  patient: Patient = new Patient();
  submitted = false;

  constructor(private patientService: PatientService,
    private router: Router) { }

  ngOnInit() {
  }

  newPatient(): void {
    this.submitted = false;
    this.patient = new Patient();
  }

  save() {
    this.patientService.createPatient(this.patient)
      .subscribe(data => {
        PatientListComponent.call,                       

        console.log(data)
        this.redirectTo('/patients');

      }
      
      , error => console.log(error));
    this.patient = new Patient();
    //this.gotoList();
  }

  onSubmit() {
    this.submitted = true;
    this.save();    
  }

  gotoList() {
    this.router.navigate(['/patients']);
  }
  redirectTo(uri) {
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() =>
    this.router.navigate([uri]));
  }

}
