import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LogoutComponent } from '../pages/authentication/logout/logout.component';
import { AccountService } from '../shared/services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private router: Router, private accountService: AccountService) { }

  ngOnInit() {
  }

  logoff(){
    this.accountService.logoff();
        this.router.navigate(['/login']);
      }

}
