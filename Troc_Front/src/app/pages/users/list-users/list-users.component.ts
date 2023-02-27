import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/services/user.service';
import { SearchResult } from 'src/models/search-result';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.scss'],
})
export class ListUsersComponent implements OnInit, OnDestroy {
  constructor(private userService: UserService, private router: Router) {}

  loading: boolean = false;
  results?: any;
  errorMsg?: string;

  ngOnDestroy(): void {
    this.results = null;
  }
  ngOnInit(): void {
    console.log('Coucou depuis list-users');
  }

  async search(text: string) {
    this.loading = true;
    this.errorMsg = undefined;
    this.results = undefined;

    try {
      this.results = await this.userService.searchItemAsync(text);
      console.log(this.results);
    } catch (error) {
      this.errorMsg = "Attention erreur sur recherche d'utilisateur";
      console.log(error);
    }
    this.loading = false;
  }

  showDetails(r: SearchResult) {
    console.log('test showDetails');
    this.router.navigateByUrl('details-user/' + r.id);
  }
}
