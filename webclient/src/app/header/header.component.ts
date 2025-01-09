import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    var toggleOpen = document.getElementById('toggleOpen');
    var toggleClose = document.getElementById('toggleClose');
    var collapseMenu = document.getElementById('collapseMenu');

    function handleClick() {
      if (collapseMenu?.style.display === 'block') {
        collapseMenu.style.display = 'none';
      } else {
        if (collapseMenu) {
          collapseMenu.style.display = 'block';
        }
      }
    }

    toggleOpen?.addEventListener('click', handleClick);
    toggleClose?.addEventListener('click', handleClick);
  }

}
