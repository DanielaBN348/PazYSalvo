import { Component, output } from '@angular/core';
import {  MatIconModule } from '@angular/material/icon';
import { EventsEmitter } from 'stream';

@Component({
    selector: 'app-navbar',
    standalone: true,
    imports:[
        MatIconModule
    ],

    templateUrl:'./navbar.component.html',
    styleUrl: './navbar.componet.css'
})

export class NavbarComponet{
    @output() loginEvent = new EventsEmitter<any>();

    openModalLogin(){
        this.loginEvent.emit();
    }

}