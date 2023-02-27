import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { SearchResult } from 'src/models/search-result';
import { User } from 'src/models/user';
import { Object } from 'src/models/object';
import { ScrudService } from './scrud.service';

@Injectable({
  providedIn: 'root',
})
export abstract class UserService extends ScrudService<User> {
  abstract getUserObjectsAsync(id: Guid): Promise<SearchResult[]>;
  abstract addObjectAsync(item: Object, id: Guid): Promise<Guid>;
}
