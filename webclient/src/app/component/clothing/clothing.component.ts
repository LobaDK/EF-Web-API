import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GenericService } from '../../service/generic.service';
import { HttpClient } from '@angular/common/http';
import { Clothing } from '../../models/clothing.model';
import { Endpoints } from '../../enum/endpoints';

@Component({
  selector: 'app-clothing',
  standalone: true,
  imports: [NgFor],
  providers: [GenericService],
  templateUrl: './clothing.component.html',
  styleUrl: './clothing.component.css'
})
export class ClothingComponent implements OnInit {
  constructor(private service:GenericService<Clothing>, private http:HttpClient) { }

  clothings: Clothing[] = []

  ngOnInit(): void {
    this.service.getall(Endpoints.Clothing).subscribe(
      data => {
        this.clothings = data;
        console.log(this.clothings)
      }
    )
  }
}
