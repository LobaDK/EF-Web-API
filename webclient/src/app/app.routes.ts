import { Routes } from '@angular/router';
import { BuildingComponent } from './component/building/building.component';
import { ClothingComponent } from './component/clothing/clothing.component';
import { VehicleComponent } from './component/vehicle/vehicle.component';
import { WeaponComponent } from './component/weapon/weapon.component';

export const routes: Routes = [
    { path: 'category/Buildings', component: BuildingComponent },
    { path: 'category/Clothing', component: ClothingComponent },
    { path: 'category/Vehicles', component: VehicleComponent },
    { path: 'category/Weapons', component: WeaponComponent },
    { path: '', redirectTo: 'category/Buildings', pathMatch: 'full' }
];
