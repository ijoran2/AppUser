import { Component, OnInit } from '@angular/core';
import { Menu } from 'src/app/Interfaces/menu';
import { MenuService } from 'src/app/Services/menu.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})


export class NavbarComponent implements OnInit {

 menu:Menu[]=[];
  constructor(private serviceMenu:MenuService) { }

  ngOnInit(): void {

    this.CargarMenu();
  }
  CargarMenu(){
  this.serviceMenu.getMenu().subscribe(data=>
    this.menu = data
  );
  };

}
