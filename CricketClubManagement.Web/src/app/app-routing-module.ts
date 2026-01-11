import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './login/login'; 

export const routes: Routes = [
  { path: 'login', component: Login }, 
  { path: 'players', loadChildren: () => import('./pages/player/player-module').then(m => m.PlayerModule) },
  { path: '', redirectTo: 'players', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
