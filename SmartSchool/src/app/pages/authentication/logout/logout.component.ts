import { AccountService } from 'src/app/shared/services/account.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {

  constructor(private router: Router, private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.logoff();
        this.router.navigate(['/login']);
      }
  }
