import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { PlayerList } from './pages/player/player-list/player-list';

export const routes: Routes = [

  { path: 'login', component: Login , title : 'Login Page' },          // Login page
  { path: 'players', component: PlayerList, title: 'player-list' },   // Player list page
  { path: '', redirectTo: 'login', pathMatch: 'full' }, // Default route
];

