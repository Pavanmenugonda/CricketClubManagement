import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Router } from "@angular/router"; 
import { PlayerService } from '../../services/players/player';
import { Player } from '../../services/players/player.model';
import { FormsModule } from '@angular/forms';
import { Location } from '@angular/common';

@Component({
  selector: 'app-player-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './player-list.html',
  styleUrls: ['./player-list.css']
})
export class PlayerList  {

  players: Player[] = [];
  filteredPlayers: Player[] = [];
  searchText = '';
  loading = true;
  error = '';

  selectedPlayer: Player | null = null;

  constructor(private playerService: PlayerService, private _location: Location, private router: Router) {
    this.loadPlayers();
}

  loadPlayers(): void {
    this.playerService.getPlayers().subscribe({
      next: (data) => {
        this.players = data.items || [];
        this.filteredPlayers = [...this.players];
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load players';
        this.loading = false;
      }
    });
  }
  filterPlayers(): void {
    const text = this.searchText.toLowerCase();
    this.filteredPlayers = this.players.filter(p =>
      p.playerName.toLowerCase().includes(text)
    );
  }

  selectPlayer(player: any) {
    this.selectedPlayer = { ...player }; // clone to avoid accidental changes
  }

  clearSelection(): void {
    this.selectedPlayer = null;
  }

  goBack(): void {
    this._location.back();
  }

  goHome(): void {
    this.router.navigate(['/teams']);
  }

  addPlayer(): void {
    this.router.navigate(['/players/add'])
  }
}
