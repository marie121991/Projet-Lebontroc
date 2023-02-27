import {
  Component,
  SimpleChanges,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { SearchResult } from 'src/models/search-result';

@Component({
  selector: 'app-list-search-result',
  templateUrl: './list-search-result.component.html',
  styleUrls: ['./list-search-result.component.scss'],
})
export class ListSearchResultComponent {
  @Output()
  searchResultClick = new EventEmitter<SearchResult>();

  @Input()
  searchResults?: SearchResult[];

  ngOnChanges(changes: SimpleChanges) {
    console.log(changes['searchResults']);
  }

  onSearchResultClick(r: SearchResult) {
    this.searchResultClick.emit(r);
  }
}
