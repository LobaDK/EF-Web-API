import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Character } from '../models/character.model';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  private selectedCharacterSubject = new BehaviorSubject<Character | null>(null);
  selectedCharacter$ = this.selectedCharacterSubject.asObservable();

  /**
   * Sets the selected character and emits the new value to all subscribers.
   * 
   * @param character - The character to be selected.
   */
  setSelectedCharacter(character: Character) {
    this.selectedCharacterSubject.next(character);
  }

  /**
   * Retrieves the currently selected character.
   *
   * @returns {Character | null} The selected character if available, otherwise null.
   */
  getSelectedCharacter(): Character | null {
    return this.selectedCharacterSubject.getValue();
  }
}
