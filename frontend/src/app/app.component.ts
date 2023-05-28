import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BreakpointObserver } from '@angular/cdk/layout';
import { NbSidebarService } from '@nebular/theme';
import { AuthGuardService } from './shared/auth-guard.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  isCollapsable = true;
  private menuCollapsableBreakPoint = '820px';

  constructor(private router: Router, private observer: BreakpointObserver, private sidebarService: NbSidebarService,
      public readonly authService: AuthGuardService) {
    this.observer.observe(`(min-width: 0px) and (max-width: ${this.menuCollapsableBreakPoint})`).subscribe(result => {
      if (result.matches) {
        this.sidebarService.collapse('menu');
        this.isCollapsable = true;
      }
    });

    this.observer.observe(`(min-width: ${this.menuCollapsableBreakPoint}) and (max-width: 5000px)`).subscribe(result => {
      if (result.matches) {
        this.sidebarService.expand('menu');
        this.isCollapsable = false;
      }
    });

    this.router.events.subscribe(_ => {
      if (this.observer.isMatched(`(min-width: 0px) and (max-width: ${this.menuCollapsableBreakPoint})`)) {
        this.sidebarService.collapse('menu');
        this.isCollapsable = true;
      }
    });
  }

  ngOnInit(): void {
    if (this.observer.isMatched(`(min-width: 0px) and (max-width: ${this.menuCollapsableBreakPoint})`)) {
      this.sidebarService.collapse('menu');
    }
  }

  getCollapsableMenuIcon(): string {
    return this.isCollapsable ? 'menu-outline' : 'close-outline';
  }

  showMenu(): void {
    this.sidebarService.toggle(undefined, 'menu');
    this.isCollapsable = !this.isCollapsable;
  }

  isTemplatePage(): boolean {
    return this.router.url !== '/identity/login' && this.router.url !== '/identity/register';
  }

  getAuthenticatedUserName(): string {
    return localStorage.getItem('firstName') + ' ' + localStorage.getItem('lastName');
  }
}
