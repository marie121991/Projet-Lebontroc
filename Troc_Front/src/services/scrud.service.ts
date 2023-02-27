import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { SearchResult } from 'src/models/search-result';

@Injectable({
  providedIn: 'root',
})
export abstract class ScrudService<T> {
  abstract saveItemAsync(item: T): Promise<Guid>; // Create
  abstract deleteItemAsync(id: Guid): Promise<void>; // Delete
  abstract updateItemAsync(id: Guid, item: T): Promise<void>; // Update
  abstract getItemAsync(id: Guid): Promise<T>; // Read
  abstract searchItemAsync(searchText: string): Promise<SearchResult[]>; // Search
}
