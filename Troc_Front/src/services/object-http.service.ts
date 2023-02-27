import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ObjectService } from './object.service';
import { Guid } from 'guid-typescript';
import { Object } from 'src/models/object';
import { SearchResult } from 'src/models/search-result';
import { SearchResultDTO } from 'src/models/search-result-dto';
import { environment } from 'src/environments/environements';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ObjectHttpService implements ObjectService {
  constructor(private httpClient: HttpClient) {}

  saveItemAsync(item: Object): Promise<Guid> {
    throw new Error('Method not implemented.');
  }
  deleteItemAsync(id: Guid): Promise<void> {
    throw new Error('Method not implemented.');
  }
  updateItemAsync(id: Guid, item: Object): Promise<void> {
    throw new Error('Method not implemented.');
  }

  async getItemAsync(id: Guid): Promise<Object> {
    let req = this.httpClient.get(
      environment.serviceUrl + `/object/${id.toString()}`
    );
    let promise = lastValueFrom(req);
    let dto = (await promise) as {
      id: string;
      l: string;
      s: number;
      d: string;
      ido: Guid;
      v: number;
      ud: string;
      p: any[];
      owner: any;
    };

    let result = new Object();
    result.label = dto.l;
    result.objectState = dto.s;
    result.description = dto.d;
    result.idOwner = dto.ido;
    result.value = dto.v;
    result.uploadDate = new Date(dto.ud);
    result.photos = dto.p;
    result.owner = dto.owner;
    return result;
  }

  async searchItemAsync(searchText: string = ''): Promise<SearchResult[]> {
    let req = this.httpClient.get<SearchResultDTO[]>(
      environment.serviceUrl + '/object?searchText=' + searchText
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
            indication: dto.i,
            label: dto.l,
            shortDescription: dto.sd,
          } as SearchResult)
      );

    return results;
  }
}
