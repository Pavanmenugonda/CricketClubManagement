import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { SeasonsService } from '../services/seasons/seasons'
import { Season } from '../services/seasons/seasons.model'

@Component({
  selector: 'app-season-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './season-list.html',
  styleUrl: './season-list.css',
})
export class SeasonList implements OnInit {

  seasons: Season[] = [];
  filteredSeasons: Season[] = [];
  searchText = '';
  loading = true;
  error = '';

  selectedSeason: Season | null = null;

  constructor(private SeasonService: SeasonsService) {
  }

  ngOnInit(): void {
    this.loadSeasons();
  }

  loadSeasons(): void {
    this.loading = true;

    this.SeasonService.getSeasons().subscribe({
      next: (data) => {
        this.seasons = data;
        this.filteredSeasons = [...this.seasons];
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load Seasons';
        this.loading = false;
      }
    });
  }
  filterSeasons(): void {
    const text = this.searchText.toLowerCase();
    this.filteredSeasons = this.seasons.filter(p =>
      p.seasonTitle.toLowerCase().includes(text)
    );
  }

  selectSeason(season: Season): void {
    this.selectedSeason = season;
  }

  clearSelection(): void {
    this.selectedSeason = null;
  }
}
