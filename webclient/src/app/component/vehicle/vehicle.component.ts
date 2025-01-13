import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GenericService } from '../../service/generic.service';
import { Vehicle } from '../../models/vehicle.model';
import { HttpClient } from '@angular/common/http';
import { Endpoints } from '../../enum/endpoints';

@Component({
  selector: 'app-vehicle',
  standalone: true,
  imports: [NgFor],
  providers: [GenericService],
  templateUrl: './vehicle.component.html',
  styleUrl: './vehicle.component.css'
})
export class VehicleComponent implements OnInit{
  constructor(private service:GenericService<Vehicle>, private http:HttpClient) {}

  vehicles: Vehicle[] = []

  ngOnInit(): void {
    this.service.getall(Endpoints.Vehicle).subscribe(
      data => {
        this.vehicles = data;
        console.log(this.vehicles)
      }
    )
  }
}
