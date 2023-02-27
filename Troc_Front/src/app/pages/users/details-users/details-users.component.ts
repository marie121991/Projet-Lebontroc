import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { UserService } from 'src/services/user.service';
import { SearchResult } from 'src/models/search-result';
import { User } from 'src/models/user';

@Component({
  selector: 'app-details-users',
  templateUrl: './details-users.component.html',
  styleUrls: ['./details-users.component.scss'],
})
export class DetailsUsersComponent implements OnInit, OnDestroy {
  constructor(
    private userService: UserService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  user?: User;
  objects?: any;
  userId: Guid = this.activatedRoute.snapshot.params['id'];

  ngOnDestroy(): void {
    //this.user = null;
  }

  async ngOnInit() {
    // let guid = Guid.parse(this.activatedRoute.snapshot.params['id']);
    this.user = await this.userService.getItemAsync(this.userId);
    this.objects = await this.userService.getUserObjectsAsync(this.userId);
    console.log('Test user-details');
  }

  showDetails(r: SearchResult) {
    console.log('test showDetails');
    this.router.navigateByUrl('details-object/' + r.id);
  }
}
