import { Component } from "@angular/core";
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatDialog } from '@angular/material/dialog';

@Component({
    selector: 'css-Login',
    standalone: true,
    imports:[
        MatFormFieldModule
    ],
    templateUrl:'./login.component.html',
    styleUrl: './login.componet.css'
})

export class logincomponent{
    constructor (public dialog: MatDialog) {} 
    modalLogin():any{
        let dialogRef = this.dialog.open(logincomponent,{
            height: '400px',
            width: '600px',
        });
        dialogRef.afterClosed().subscribe(result=>{
            console.log('Dialog result:${result}');//pizza//
        });
        dialogRef.close('pizza!');
    }
}
