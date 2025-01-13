import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GenericService } from '../../service/generic.service';
import { weapon } from '../../models/weapon.model';
import { HttpClient } from '@angular/common/http';
import { Endpoints } from '../../enum/endpoints';

@Component({
  selector: 'app-weapon',
  standalone: true,
  imports: [NgFor],
  providers: [GenericService],
  templateUrl: './weapon.component.html',
  styleUrl: './weapon.component.css'
})
export class WeaponComponent implements OnInit {
  constructor(private service:GenericService<weapon>, private http:HttpClient) {}

  weapons: weapon[] = []

  ngOnInit(): void {
    this.service.getall(Endpoints.Weapon).subscribe(
      data => {
        this.weapons = data;
        console.log(this.weapons)
      }
    )
  }
}
