import { Component, OnInit } from '@angular/core';
import { HomeService } from '../shared/services/home.service';
import { IEmployee } from '../shared/models/employee';
import { Item } from '../shared/models/item';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  pageTitle = 'Employees';
  selectedEmp!: any;
  errorMessage!: string;
  employees!: IEmployee[];
  filteredEmployees!: IEmployee[];

  cols: any[] = [];
  items: Item[] = [];

  constructor(private _homeService: HomeService) {}

  ngOnInit(): void {
    this._homeService.getEmployees().subscribe({
      next: (employees: IEmployee[]) => {
        this.employees = employees;
        this.filteredEmployees = this.employees;
        this.createDropdownItems();
      },
      error: (err) => (this.errorMessage = err),
    });

    this.cols = [
      { field: 'id', header: 'Employee ID' },
      { field: 'last', header: 'Last' },
      { field: 'first', header: 'First' },
    ];
  }

  filterEmployees(event: any): void {
    //console.log(event);
    const code: number = +event.value.code;
    if (code > 0) {
      this.filteredEmployees = this.employees.filter(
        (e) => e.manager === event.value.code
      );
    } else {
      this.filteredEmployees = this.employees;
    }
  }

  private createDropdownItems(): void {
    var item: Item = { name: 'All', code: 0 };
    this.items.push(item);
    this.employees.forEach((employee: IEmployee) => {
      var item: Item = { name: employee.last, code: employee.id };
      this.items.push(item);
    });
  }
}
