import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GenericService } from '../../service/generic.service';
import { weapon } from '../../models/weapon.model';
import { HttpClient } from '@angular/common/http';
import { Endpoints } from '../../enum/endpoints';

@Component({
  selector: 'app-weapon',
  standalone: true,
  imports: [NgFor, NgIf],
  providers: [GenericService],
  templateUrl: './weapon.component.html',
  styleUrl: './weapon.component.css'
})
export class WeaponComponent implements OnInit {
  constructor(private service:GenericService<weapon>, private http:HttpClient) {}

  weapons: weapon[] = []
  isLoading: boolean = false;
  errorMessage: string = '';

  ngOnInit(): void {
    this.fetchWeapons();
  }

  fetchWeapons() {
    this.isLoading = true;
    this.service.getall(Endpoints.Weapon).subscribe({
      next: (data) => {
        this.weapons = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = error.message;
        this.isLoading = false;
      }
    })
  }
}
