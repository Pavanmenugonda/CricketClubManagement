import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Player } from './player.model';
import { BehaviorSubject } from 'rxjs'; 

@Injectable({ providedIn: 'root' })

export class PlayerService {

  private baseUrl = `${environment.apiBaseUrl}/players`;

  constructor(private http: HttpClient) { }

  getPlayers(page = 1, pageSize = 10): Observable<any> {
    const params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize);

    return this.http.get<any>(this.baseUrl, { params });
  }
}
