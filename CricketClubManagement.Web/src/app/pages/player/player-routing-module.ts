import { PlayerList } from './player-list/player-list';
import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'players', component: PlayerList },
  { path: '', redirectTo: 'players', pathMatch: 'full' }
];
