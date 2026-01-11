import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayerList } from './player-list/player-list';

const routes: Routes = [
  {path: '', component:PlayerList}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlayerRoutingModule { }
