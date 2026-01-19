import {Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { Location } from '@angular/common';
import { PlayerService } from '../../services/players/player';
import { Player } from '../../services/players/player.model';

@Component({
  selector: 'app-player-add',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './player-add.html',
  styleUrl: './player-add.css',
})
export class PlayerAdd {

  player = {
    playerName: '',
    playerAge: null,
    playerContact: '',
    roleId: 1
  };

  loading = false;
  error = '';

  constructor(private playerService: PlayerService,
     private _location: Location, private router: Router) { }
 

  save(): void {
    this.loading = true;
    this.error = '';

    this.playerService.addPlayer(this.player).subscribe({
      next: () => this.router.navigate(['/players']),
      error: () => {
        this.error = 'Failed to add player';
        this.loading = false;
      }
    });
  }
  goBack(): void {
    this._location.back();
  }

}
