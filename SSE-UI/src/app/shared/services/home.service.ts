import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of, tap } from 'rxjs';
import { IEmployee } from '../models/employee';

//const config = require('../../assets/data/config.json');
//import * as config from '../../../assets/data/config.json';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  //private url = config.resources.api.resourceUri + '/employees';
  private url = 'https://localhost:5001/api/employees';

  private employees!: IEmployee[];

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<IEmployee[]> {
    if (this.employees) {
      return of(this.employees);
    }
    return this.http.get<IEmployee[]>(this.url).pipe(
      tap((data) => console.log(JSON.stringify(data))),
      tap((data) => (this.employees = data)),
      catchError((err) => {
        console.log('getEmployees - Error');
        throw new Error(err);
      })
    );
  }
}
