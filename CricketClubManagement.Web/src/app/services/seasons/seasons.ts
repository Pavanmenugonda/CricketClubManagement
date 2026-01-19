import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SeasonsService {

  private baseUrl = `${environment.apiBaseUrl}/seasons`;

  constructor(private http: HttpClient) { }

  getSeasons(page = 1, pageSize = 10): Observable<any> {
    const params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize);

    return this.http.get<any>(this.baseUrl, { params });
  }
}
