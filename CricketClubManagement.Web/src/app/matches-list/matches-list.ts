import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Router } from "@angular/router";
import { MatchesService } from '../services/matches/matches';
import { Matches } from '../services/matches/matches.model';
import { FormsModule } from '@angular/forms';
import { filter } from 'rxjs';

@Component({
  selector: 'app-matches-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './matches-list.html',
  styleUrl: './matches-list.css',
})
export class MatchesList implements OnInit  {

  matches: Matches[] = [];
  filteredMatches: Matches[] = [];
  searchText = '';
  loading = true;
  error = '';

  selectedMatch: Matches | null = null;

  constructor(private matchesService: MatchesService) { }
  

  ngOnInit(): void {
    this.loadMatches();
  }

  loadMatches(): void {
    this.loading = true;

    this.matchesService.getMatches().subscribe({
      next: (data: Matches[]) => {
        console.log('matches received:', data);
        this.matches = data;
        this.filteredMatches = [...data];
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Failed to load matches';
        console.error('Failed to load matches:', err);
        this.loading = false;
      }
    });
  }

    filterMatches(): void {
      const text = this.searchText.toLowerCase();
      this.filteredMatches = this.matches.filter(m =>
        m.matchName.toLowerCase().includes(text)
      );
    }

  selectMatch(match: Matches): void {
    this.selectedMatch = match;
  }
      clearSelection(): void {
        this.selectedMatch = null;
      }

}
