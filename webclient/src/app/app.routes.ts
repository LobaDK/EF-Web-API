import { Routes } from '@angular/router';
import { BuildingComponent } from './building/building.component';

export const routes: Routes = [
    { path: 'category/Buildings', component: BuildingComponent },
    { path: '', redirectTo: 'category/Buildings', pathMatch: 'full' }
];
