import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
 
  title = 'The Dating App';

  constructor(private http: HttpClient, private accountService: AccountService){}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser(){
    var storageUser = localStorage.getItem('user');
    if(storageUser != "undefined" && storageUser != null)
    {
      const user: User = JSON.parse(storageUser);
      this.accountService.setCurrentUser(user);
    }
    else
    {
      this.accountService.setCurrentUser(undefined);
    }
  }

}
