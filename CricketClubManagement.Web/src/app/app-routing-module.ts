import { Routes } from '@angular/router';
import { Login } from './login/login';
import { PlayerList } from './player/player-list/player-list';

export const routes: Routes = [

  { path: 'login', component: Login, title: 'Login Page' },          // Login page
  { path: 'home', loadComponent: () => import('./home/home').then(m => m.Home), title: 'Home Page' }, // Home page}
  { path: 'players', component: PlayerList, title: 'player-list' },   // Player list page
  { path: '', redirectTo: 'login', pathMatch: 'full' }, // Default route
];

