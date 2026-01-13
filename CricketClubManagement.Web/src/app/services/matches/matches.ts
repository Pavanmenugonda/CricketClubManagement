
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Matches } from './matches.model';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class MatchesService {

  private baseUrl = `${environment.apiBaseUrl}/matches`;

  constructor(private http: HttpClient) { }

  getMatches(): Observable<Matches[]> {
    return this.http.get<any[]>(this.baseUrl).pipe(
      map(arr => Array.isArray(arr) ? arr : []),
      map(arr => arr.map(m => ({
        matchId: m.matchId,
        matchName: m.matchName,
        matchDate: new Date(m.matchDate),
        seasonId: m.seasonId
      } as Matches))),
      catchError(err => {
        console.error('getMatches error', err);
        return of([]);
      })
    );
  }
}
