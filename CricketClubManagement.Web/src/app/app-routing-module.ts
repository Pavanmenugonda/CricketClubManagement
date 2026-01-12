import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { PlayerList } from './pages/player/player-list/player-list';

export const routes: Routes = [
  { path: 'login', component: Login },          // Login page
  { path: 'players', component: PlayerList },   // Player list page
  { path: '', redirectTo: 'players', pathMatch: 'full' }, // Default route
  { path: '**', redirectTo: 'players' }         // Fallback route
];
