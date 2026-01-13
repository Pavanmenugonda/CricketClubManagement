import { Routes } from '@angular/router';
import { authGuard } from './Auth/auth.guard';
import { Login } from './login/login';
import { Home } from './home/home';
import { PlayerList } from './player/player-list/player-list';
import { TeamList } from './teams/teams-list';
import { MatchesList } from './matches-list/matches-list';

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
    path: 'teams',
    component: TeamList,
    canActivate: [authGuard],
    title: 'teams-list'
  },
  {
    path: 'matches',
    component: MatchesList,
    canActivate: [authGuard],
    title: 'matches-list'
  },

  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }, // Default route
];

