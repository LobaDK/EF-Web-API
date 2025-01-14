import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GenericService } from '../../service/generic.service';
import { weapon } from '../../models/weapon.model';
import { HttpClient } from '@angular/common/http';
import { Endpoints } from '../../enum/endpoints';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ammoTypes, supportedAttachments, weaponTypes } from '../../enum/weapon';

@Component({
  selector: 'app-weapon',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule],
  providers: [GenericService],
  templateUrl: './weapon.component.html',
  styleUrl: './weapon.component.css'
})
export class WeaponComponent implements OnInit {
  weapons: weapon[] = []
  isLoading: boolean = false;
  errorMessage: string = '';
  isFormVisible: boolean = false;
  weaponForm: FormGroup;
  
  constructor(private service:GenericService<weapon>, private http:HttpClient) {
    this.weaponForm = new FormGroup({
      name: new FormControl('', Validators.required),
      type: new FormControl('', Validators.required),
      damage: new FormControl(0),
      rangeInMeters: new FormControl(0),
      magazineSize: new FormControl(0),
      fireRate: new FormControl(0),
      reloadTime: new FormControl(0),
      supportedAmmoTypes: new FormControl([]),
      supportedAttachments: new FormControl([]),
      characterLevelRequirement: new FormControl(0),
      price: new FormControl(0)
    });
  }

  ngOnInit(): void {
    this.fetchWeapons();
  }

  addWeapon() {
    this.isFormVisible = true;
  }

  closeForm() {
    this.isFormVisible = false;
  }

  fetchWeapons() {
    this.isLoading = true;
    this.service.getAll(Endpoints.Weapon).subscribe({
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
  
  onSubmit() {
    if (this.weaponForm?.valid) {
      this.weapons.push(this.weaponForm.value);
      this.isFormVisible = false;
    }
  }

  get weaponTypes() {
    return Object.values(weaponTypes).filter((value) => typeof value === 'string');
  }

  get ammoTypes() {
    return Object.values(ammoTypes).filter((value) => typeof value === 'string');
  }

  get attachments() {
    return Object.values(supportedAttachments).filter((value) => typeof value === 'string');
  }
}
