import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayerService } from '../../../services/player';
import { RouterModule } from '@angular/router';
import { Router } from "@angular/router"; 
import { Player } from '../../../services/player.model';

@Component({
  selector: 'app-player-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './player-list.html',
  styleUrls: ['./player-list.css']
})
export class PlayerList implements OnInit {

  players: Player[] = [];
  loading = true;
  error = '';

  constructor(private playerService: PlayerService) { }

  ngOnInit(): void {
    this.playerService.getPlayers().subscribe({
      next: (res) => {
        this.players = res.items;   // IMPORTANT
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load players';
        this.loading = false;
      }
    });
  }
}

