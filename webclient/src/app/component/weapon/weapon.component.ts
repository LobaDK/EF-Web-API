import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GenericService } from '../../service/generic.service';
import { weapon } from '../../models/weapon.model';
import { Endpoints } from '../../enum/endpoints';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ammoTypes, supportedAttachments, weaponTypes } from '../../enum/weapon';
import { Character } from '../../models/character.model';
import { CharacterService } from '../../service/character.service';
import { CharacterComponent } from '../character/character.component';

@Component({
  selector: 'app-weapon',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, CharacterComponent],
  providers: [GenericService],
  templateUrl: './weapon.component.html',
  styleUrl: './weapon.component.css'
})
export class WeaponComponent implements OnInit {
  weapons: weapon[] = []
  isLoading: boolean = false;
  fetchErrorMessage: string | null = null;
  isFormVisible: boolean = false;
  isUpdateFormVisible: boolean = false;
  weaponForm!: FormGroup;
  selectedCharacter: Character | null = null;
  updateWeaponId: number | null = null;
  
  constructor(private service:GenericService<weapon>, private characterService: CharacterService) {}

  /**
   * Initializes the component by fetching the list of weapons.
   */
  ngOnInit(): void {
    this.characterService.selectedCharacter$.subscribe(character => {
      this.selectedCharacter = character;
      if (this.selectedCharacter) {
        this.fetchWeapons();
      }
    });
  }
  
  /**
   * Creates a new form group for creating a weapon.
   * 
   * @returns {FormGroup} A new form group for creating a weapon.
   */
  createWeaponForm(): FormGroup {
    return new FormGroup({
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

  /**
   * Opens the weapon form to add a new weapon.
   */
  addWeapon() {
    this.weaponForm = this.createWeaponForm();
    this.isFormVisible = true;
  }

  /**
   * Deletes a weapon by its ID.
   *
   * This method sends a delete request to the server to remove the weapon with the specified ID.
   * Upon successful deletion, it updates the local `weapons` array by filtering out the deleted weapon.
   * If an error occurs during the deletion process, it logs the error to the console.
   *
   * @param {number} id - The ID of the weapon to be deleted.
   */
  deleteWeapon(id: number) {
    this.service.delete(Endpoints.Weapon, id).subscribe({
      next: (data) => {
        console.log(data)
        this.weapons = this.weapons.filter(weapon => weapon.id !== id);
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  /**
   * Buys a weapon for the selected character.
   * 
   * @param id - The ID of the weapon to be purchased.
   * 
   * This method checks if a character is selected, then calls the service to buy the weapon.
   * On success, it logs the response data, updates the selected character's owned weapon IDs,
   * and sets the updated character as the selected character.
   * On error, it logs the error to the console.
   */
  buyWeapon(id: number) {
    if (this.selectedCharacter) {
      this.service.buy(Endpoints.Weapon, id, this.selectedCharacter.id).subscribe({
        next: (data) => {
          console.log(data)
          this.selectedCharacter?.ownedWeaponIds.push(id);
          if (this.selectedCharacter) {
            this.characterService.setSelectedCharacter(this.selectedCharacter);
          }
        },
        error: (error) => {
          console.error(error);
        }
      })
    }
  }
  
  
  /**
   * Updates the weapon form with the data of the weapon specified by the given ID.
   * 
   * This method sets the `updateWeaponId` to the provided ID, initializes the `weaponForm`
   * with a new form instance, and makes the update form visible. It then fetches the weapon
   * data from the server using the provided ID and patches the form with the retrieved data.
   * If an error occurs during the data retrieval, it logs the error to the console.
   * 
   * @param {number} id - The ID of the weapon to be updated.
   */
  updateWeapon(id: number) {
    this.updateWeaponId = id;
    this.weaponForm = this.createWeaponForm();
    this.isUpdateFormVisible = true;
    this.service.get(Endpoints.Weapon, id).subscribe({
      next: (data) => {
        this.weaponForm.patchValue(data);
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  /**
   * Closes the weapon form and resets the form data.
   */
  closeForm() {
    this.isFormVisible = false;
    this.weaponForm.reset();
  }

  /**
   * Closes the weapon update form and resets the form data.
   */
  closeUpdateForm() {
    this.isUpdateFormVisible = false;
    this.weaponForm.reset();
    this.updateWeaponId = null;
  }

  /**
   * Fetches the list of weapons from the server.
   * 
   * This method sets the `isLoading` flag to `true` before making the request
   * to the server. If the request is successful, the list of weapons is updated
   * and the `isLoading` flag is set to `false`. If the request fails, an error
   * message is logged to the console and the `isLoading` flag is set to `false`.
   */
  fetchWeapons() {
    this.isLoading = true;
    this.service.getAll(Endpoints.Weapon).subscribe({
      next: (data) => {
        this.weapons = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.fetchErrorMessage = error.message;
        this.isLoading = false;
      }
    })
  }
  
  /**
   * Submits the weapon form data to the server.
   * 
   * If the form is valid, the data is sent to the server using the `add` method
   * of the `GenericService` class. If the request is successful, the form is closed
   * and the new weapon is added to the list of weapons.
   * 
   * If the request fails, an error message is logged to the console.
   */
  onSubmit() {
    if (this.weaponForm?.valid) {
      this.service.add(Endpoints.Weapon, this.weaponForm.value).subscribe({
        next: (data) => {
          this.closeForm();
          this.weapons.push(data);
        },
        error: (error) => {
          console.error(error);
        }
      });
    }
  }

  /**
   * Submits the updated weapon form data to the server.
   * 
   * If the form is valid and an update weapon ID is set, the data is sent to the server
   * using the `update` method of the `GenericService` class. If the request is successful,
   * the form is closed and the updated weapon is added to the list of weapons.
   * 
   * If the request fails, an error message is logged to the console.
   */
  onUpdate() {
    if (this.weaponForm?.valid && this.updateWeaponId) {
      this.service.update(Endpoints.Weapon, this.updateWeaponId, this.weaponForm.value).subscribe({
        next: (data) => {
          this.closeUpdateForm();
          this.weapons = this.weapons.map(weapon => weapon.id === data.id ? data : weapon);
        },
        error: (error) => {
          console.error(error);
        }
      });
    }
  }

  /**
   * Gets the list of supported weapon types.
   * 
   * This getter filters the values of the `weaponTypes` object,
   * returning only those values that are of type string.
   * 
   * @returns {string[]} An array of supported weapon type strings.
   */
  get weaponTypes(): string[] {
    return Object.values(weaponTypes).filter((value) => typeof value === 'string');
  }

  /**
   * Gets the list of supported ammo types.
   * 
   * This getter filters the values of the `ammoTypes` object,
   * returning only those values that are of type string.
   * 
   * @returns {string[]} An array of supported ammo type strings.
   */
  get ammoTypes(): string[] {
    return Object.values(ammoTypes).filter((value) => typeof value === 'string');
  }

  /**
   * Gets the list of supported attachments.
   * 
   * This getter filters the values of the `supportedAttachments` object,
   * returning only those values that are of type string.
   * 
   * @returns {string[]} An array of supported attachment strings.
   */
  get attachments(): string[] {
    return Object.values(supportedAttachments).filter((value) => typeof value === 'string');
  }

  /**
   * Checks if a given ammo type is selected in the weapon form,
   * and updates the selected ammo types accordingly.
   * 
   * @param event - The event that triggered the change.
   */
  onAmmoTypeChange(event: any): void {
    const selectedAmmoTypes = this.weaponForm.get('supportedAmmoTypes')?.value as string[];
    if (event.target.checked) {
      selectedAmmoTypes.push(event.target.value);
    } else {
      const index = selectedAmmoTypes.indexOf(event.target.value);
      if (index > -1) {
        selectedAmmoTypes.splice(index, 1);
      }
    }
    this.weaponForm.get('supportedAmmoTypes')?.setValue(selectedAmmoTypes);
  }

  /**
   * Checks if a given ammo type is selected in the weapon form,
   * and updates the selected ammo types accordingly.
   * 
   * @param event - The event that triggered the change.
   */
  onAttachmentChange(event: any): void {
    const selectedAttachments = this.weaponForm.get('supportedAttachments')?.value as string[];
    if (event.target.checked) {
      selectedAttachments.push(event.target.value);
    } else {
      const index = selectedAttachments.indexOf(event.target.value);
      if (index > -1) {
        selectedAttachments.splice(index, 1);
      }
    }
    this.weaponForm.get('supportedAttachments')?.setValue(selectedAttachments);
  }

  /**
   * Checks if a given ammo type is selected in the weapon form.
   * 
   * @param ammoType - The ammo type to check.
   * @returns 'true' if the ammo type is selected, otherwise 'false'.
   */
  isAmmoTypeSelected(ammoType: string): boolean {
    return this.weaponForm.get('supportedAmmoTypes')?.value.includes(ammoType);
  }

  /**
   * Checks if a given attachment is selected in the weapon form.
   *
   * @param attachment - The name of the attachment to check.
   * @returns `true` if the attachment is selected, otherwise `false`.
   */
  isAttachmentSelected(attachment: string): boolean {
    return this.weaponForm.get('supportedAttachments')?.value.includes(attachment);
  }
}
