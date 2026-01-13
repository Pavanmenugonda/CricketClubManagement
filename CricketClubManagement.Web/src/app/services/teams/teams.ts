import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Team } from './teams.model';
import { map, catchError } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class TeamService {

  private baseUrl = `${environment.apiBaseUrl}/teams`;

  constructor(private http: HttpClient) { }


  getTeams(): Observable<Team[]> {
    return this.http.get<any>(this.baseUrl).pipe(
      map(res => {
        // Normalize different possible API shapes to Team[]
        if (Array.isArray(res)) return res as Team[];
        if (Array.isArray(res?.data)) return res.data as Team[];
        if (Array.isArray(res?.items)) return res.items as Team[];
        if (Array.isArray(res?.teams)) return res.teams as Team[];
        return [];
      }),
      catchError(err => {
        console.error('getTeams error', err);
        return of([]); // Return empty array so component won’t crash
      })
    );
  }

}
