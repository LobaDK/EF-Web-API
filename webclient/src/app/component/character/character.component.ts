import { Component, OnInit } from '@angular/core';
import { GenericService } from '../../service/generic.service';
import { Character } from '../../models/character.model';
import { Endpoints } from '../../enum/endpoints';
import { CharacterService } from '../../service/character.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-character',
  standalone: true,
  imports: [NgFor],
  providers: [GenericService],
  templateUrl: './character.component.html',
  styleUrl: './character.component.css'
})
export class CharacterComponent implements OnInit {
  characters: Character[] = []

  constructor(private service:GenericService<Character>, private characterService:CharacterService) {}
  
  ngOnInit(): void {
    this.fetchCharacters();
  }

  fetchCharacters() {
    this.service.getAll(Endpoints.PlayerCharacter).subscribe({
      next: (data) => {
        this.characters = data;
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  selectCharacter(character: Character) {
    this.characterService.setSelectedCharacter(character);
  }
}
