import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SideMenuComponent } from './Components/side-menu/side-menu.component';
import { NavbarComponet } from './Components/navbar/navbar.component';
import { logincomponent } from './Components/login/login.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [
    RouterOutlet,
    SideMenuComponent,
    NavbarComponet
  ]
  
})

export class AppComponent {
  title = 'PazYSalvoAppClient';

  constructor(
    public dialog: MatDialog
  ){}
  openModal() {
    const dialogRef = this.dialog.open(logincomponent);
  }
}
