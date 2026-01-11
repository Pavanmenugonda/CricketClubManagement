import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { PlayerRoutingModule } from './player-routing-module';
import { PlayerList } from './player-list/player-list';

const routes: Routes = [
  { path: '', component: PlayerList }
];

@NgModule({
  declarations: [
    PlayerList
  ],
  imports: [
    CommonModule,
    PlayerRoutingModule
  ]
})
export class PlayerModule { }
