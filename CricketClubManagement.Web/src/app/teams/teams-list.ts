import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TeamService } from '../services/teams/teams';
import { Team } from '../services/teams/teams.model';

@Component({
  selector: 'app-team-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './teams-list.html',
  styleUrls: ['./teams-list.css']
})
export class TeamList implements OnInit {

  teams: Team[] = [];
  filteredTeams: Team[] = [];
  searchText = '';
  loading = true;
  error = '';
  selectedTeam: Team | null = null;

  constructor(private teamService: TeamService) { }

  ngOnInit(): void {
    this.loadTeams();
  }

  loadTeams(): void {
    this.loading = true;

    this.teamService.getTeams().subscribe({
      next: (data: Team[]) => {
        console.log('Teams received:', data);
        this.teams = data;
        this.filteredTeams = [...data];
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Failed to load Teams';
        console.error('Failed to load Teams:', err);
        this.loading = false;
      }
    });
  }


  filterTeams(): void {
    const text = (this.searchText || '').toLowerCase();
    this.filteredTeams = this.teams.filter(t =>
      (t.teamName || '').toLowerCase().includes(text)
    );
  }

  selectTeam(team: Team): void {
    this.selectedTeam = team;
  }

  clearSelection(): void {
    this.selectedTeam = null;
  }
}
