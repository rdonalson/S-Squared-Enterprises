import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IPrincipality } from '../shared/models/principality';
import { PrincipalityService } from '../shared/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
})
export class EmployeeComponent implements OnInit{
  pageTitle: string = 'Add New Employee';
  errorMessage!: string;
  itemForm!: FormGroup;
  selectedRole!: any;
  principalities: IPrincipality[] = [];

  constructor(
    private _principalityService: PrincipalityService
  ) {}


  ngOnInit(): void {
    this._principalityService.getIPrincipalities().subscribe({
      next: (principalities: IPrincipality[]) => {
        this.principalities = principalities;
      },
      error: (err) => (this.errorMessage = err),
    });
  }

  getPrincipality(event: any): void {
    console.log(event);
    //const code: number = +event.value.code;
  }

  saveItem(): void {

  }
}
