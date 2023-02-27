import { Guid } from 'guid-typescript';

export interface SearchResult {
  label: string;
  shortDescription: string;
  indication: string;
  id: Guid;
}
