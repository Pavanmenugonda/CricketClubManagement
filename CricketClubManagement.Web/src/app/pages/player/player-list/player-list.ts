// player-list.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayerService } from '../../../services/player';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-player-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './player-list.html',
  styleUrls: ['./player-list.css']
})
export class PlayerList implements OnInit {
  players: any[] = [];
  loading = true;
  error = '';

  constructor(private playerService: PlayerService) { }

  ngOnInit(): void {
    this.playerService.getPlayers().subscribe({
      next: res => {
        this.players = res.items;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load players';
        this.loading = false;
      }
    });
  }
}
