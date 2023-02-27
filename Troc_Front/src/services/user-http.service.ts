import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from './user.service';
import { Guid } from 'guid-typescript';
import { User } from 'src/models/user';
import { SearchResult } from 'src/models/search-result';
import { SearchResultDTO } from 'src/models/search-result-dto';
import { environment } from 'src/environments/environements';
import { lastValueFrom } from 'rxjs';
import { Object } from 'src/models/object';

@Injectable({
  providedIn: 'root',
})
export class UserHttpService implements UserService {
  constructor(private httpClient: HttpClient) {}

  async addObjectAsync(item: Object, id: Guid): Promise<Guid> {
    let guid = Guid.create();
    let dto = {
      id: guid.toString(),
      l: item.label,
      s: item.objectState,
      dn: item.description,
      ido: id,
      v: item.value,
      ud: new Date(),
    };
    var req = this.httpClient.post(
      environment.serviceUrl + `/User/${id.toString()}/Objects/add`,
      dto
    );
    var promise = lastValueFrom(req);
    var resultPromise = (await promise) as boolean;
    return guid;
  }

  saveItemAsync(item: User): Promise<Guid> {
    throw new Error('Method not implemented.');
  }
  deleteItemAsync(id: Guid): Promise<void> {
    throw new Error('Method not implemented.');
  }
  updateItemAsync(id: Guid, item: User): Promise<void> {
    throw new Error('Method not implemented.');
  }

  async getUserObjectsAsync(id: Guid): Promise<SearchResult[]> {
    let req = this.httpClient.get<SearchResultDTO[]>(
      environment.serviceUrl + `/User/${id.toString()}/Objects`
    );

    let promise = lastValueFrom(req);
    let dtos = await promise;

    let results = dtos.map(
      (dto) =>
        ({
          id: Guid.parse(dto.id),
          indication: dto.i,
          label: dto.l,
          shortDescription: dto.sd,
        } as SearchResult)
    );

    return results;
  }

  async getItemAsync(id: Guid): Promise<User> {
    let req = this.httpClient.get(
      environment.serviceUrl + `/User/${id.toString()}`
    );
    let promise = lastValueFrom(req);
    let dto = (await promise) as {
      id: string;
      Fn: string;
      Ln: string;
      A: any;
      P: string;
      DI: Date;
    };

    let result = new User();
    result.firstName = dto.Fn;
    result.lastName = dto.Ln;
    result.address = dto.A;
    result.photo = dto.P;
    result.dateInscription = new Date(dto.DI);
    return result;
  }

  async searchItemAsync(searchText: string = ''): Promise<SearchResult[]> {
    let req = this.httpClient.get<SearchResultDTO[]>(
      environment.serviceUrl + '/User?searchText=' + searchText
    );

    let reg = new RegExp(searchText, 'gi');

    let promise = lastValueFrom(req);

    let dtos = await promise;

    let results = dtos
      .filter((dto) => reg.test(dto.l))
      .map(
        (dto) =>
          ({
            id: Guid.parse(dto.id),
            indication: dto.sd,
            label: dto.l,
            shortDescription: dto.i,
          } as SearchResult)
      );

    return results;
  }
}
