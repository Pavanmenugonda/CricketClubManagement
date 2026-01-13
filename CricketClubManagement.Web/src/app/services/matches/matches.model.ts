export interface Matches {
  matchId: number;
  matchName: string;
  matchDate: Date; // API returns a string; we can convert to Date in the service
  seasonId?: number;      
}

