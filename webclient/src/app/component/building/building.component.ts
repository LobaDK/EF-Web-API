import { Component, OnInit } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { BuildingService } from '../../service/building.service';
import { HttpClient } from '@angular/common/http';
import { Building } from '../../models/building.model';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-building',
  standalone: true,
  imports: [ReactiveFormsModule, NgFor],
  providers: [BuildingService],
  templateUrl: './building.component.html',
  styleUrl: './building.component.css'
})
export class BuildingComponent implements OnInit {
  constructor(private service:BuildingService, private http:HttpClient) { }
  
  buildings: Building[] = [];

  ngOnInit() {
    this.service.getall().subscribe(
      data => {
        this.buildings = data;
        console.log(this.buildings);
      }
    )
  }
}