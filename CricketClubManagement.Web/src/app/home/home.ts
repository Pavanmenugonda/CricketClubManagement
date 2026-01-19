import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthService } from '../Auth/auth.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  clubName: string = 'NT Cricket Club';
  userName: string = 'John Doe - Admin';

  constructor(private auth: AuthService) { }

  logout() {
    this.auth.logout();
  }

}
