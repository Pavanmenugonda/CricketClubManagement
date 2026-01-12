import { Routes } from '@angular/router';
import { Login } from './login/login';
import { Home } from './home/home';
import { PlayerList } from './player/player-list/player-list';
import { authGuard } from './Auth/auth.guard'; 

export const routes: Routes = [

  { path: 'login', component: Login, title: 'Login Page' },

  {
    path: 'home',
    loadComponent: () => import('./home/home').then(m => m.Home),
    canActivate: [authGuard], 
    title: 'Home Page'
  },

  {
    path: 'players',
    component: PlayerList,
    canActivate: [authGuard],
    title: 'player-list'
  },

  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }, // Default route
];

