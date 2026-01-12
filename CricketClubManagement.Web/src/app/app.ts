import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RouterModule } from '@angular/router'; 
import { provideRouter } from '@angular/router';
import { routes } from './app-routing-module';
import { Login } from './login/login';
import { Home } from './home/home';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: true,
  imports: [RouterOutlet]
})
export class App {
  //isLoggedIn = true;
  protected readonly title = signal('CricketClubManagement.Web');
}
