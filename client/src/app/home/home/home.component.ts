import { Component, Input, OnInit } from '@angular/core';
import AOS from 'aos';
import { IProduct } from 'src/app/shared/models/product';
import { HomeServices } from './home.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
 

  products: IProduct[];

  constructor(private homeService: HomeServices ) { }

  ngOnInit(): void {
    AOS.init();
    this.homeService.getProducts().subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log(error);

    })
  }

}
