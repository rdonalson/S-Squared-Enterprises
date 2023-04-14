import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of, tap } from 'rxjs';
import { IPrincipality } from '../models/principality';

@Injectable({
  providedIn: 'root',
})
export class PrincipalityService {

  private url = 'https://localhost:5001/api/principalities';

  private principalities!: IPrincipality[];

  constructor(private http: HttpClient) {}

  getIPrincipalities(): Observable<IPrincipality[]> {
    if (this.principalities) {
      return of(this.principalities);
    }
    return this.http.get<IPrincipality[]>(this.url).pipe(
      tap((data) => console.log(JSON.stringify(data))),
      tap((data) => (this.principalities = data)),
      catchError((err) => {
        console.log('getIPrincipalities - Error');
        throw new Error(err);
      })
    );
  }
}
