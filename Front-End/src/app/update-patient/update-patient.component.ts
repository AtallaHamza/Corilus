import { Component, OnInit } from '@angular/core';
import { Patient } from '../models/patient.model';
import { ActivatedRoute, Router, NavigationExtras } from '@angular/router';
import { PatientService } from '../patient.service';
import { PatientListComponent } from '../patient-list/patient-list.component';

@Component({
  selector: 'app-update-patient',
  templateUrl: './update-patient.component.html',
  styleUrls: ['./update-patient.component.css']
})
export class UpdatePatientComponent implements OnInit {
  id: number;
  patient: Patient;
  constructor(private route: ActivatedRoute,private router: Router,
    private  patientService: PatientService) { }
    ngOnInit() {
      this.patient = new Patient();
  
      this.id = this.route.snapshot.params['id'];
      
      this.patientService.getPatient(this.id)
        .subscribe(data => {
          console.log(data)
          this.patient = data;
        }, error => console.log(error));
    }
  
    updatePatient() {
      this.patientService.updatePatient(this.id, this.patient)
        .subscribe(
          data => 
          {
            console.log("data updated :"+JSON.stringify(data)),
            PatientListComponent.call ;                        
            this.redirectTo('/patients');

          },
         error => console.log(error));
      this.patient = new Patient();

    }
  
    onSubmit() {
      this.updatePatient();    
    }

    redirectTo(uri) {
      this.router.navigateByUrl('/', {skipLocationChange: true}).then(() =>
      this.router.navigate([uri]));
    }
  
  }