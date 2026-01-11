import { Component, OnInit } from '@angular/core';
import { PlayerService } from '../../../services/player';

@Component({
  selector: 'app-player-list',
  standalone: false,
  templateUrl: './player-list.html',
  styleUrl: './player-list.css',
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

