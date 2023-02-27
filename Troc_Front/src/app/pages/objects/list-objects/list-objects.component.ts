import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ObjectService } from 'src/services/object.service';
import { SearchResult } from 'src/models/search-result';
@Component({
  selector: 'app-list-objects',
  templateUrl: './list-objects.component.html',
  styleUrls: ['./list-objects.component.scss'],
})
export class ListObjectsComponent implements OnInit, OnDestroy {
  constructor(private objectService: ObjectService, private router: Router) {}

  loading: boolean = false;
  results?: any;
  errorMsg?: string;

  ngOnDestroy(): void {
    //Ici on s'assure que les données récupérées par la requête http sont effacées
    //lorsqu'on part de la page, et que le composant list-object est démonté
    this.results = null;
  }
  ngOnInit(): void {
    // this.dataService.getAll('object').subscribe((response) => {
    //   let data: any = response;
    //   this.results = data;
    //   console.log(this.results);
    // });
    console.log('Coucou depuis list-objects');
  }

  async search(text: string) {
    this.loading = true;
    this.errorMsg = undefined;
    this.results = undefined;

    try {
      this.results = await this.objectService.searchItemAsync(text);
      console.log(this.results);
    } catch (error) {
      this.errorMsg = "Attention erreur sur recherche d'objet";
      console.log(error);
    }
    this.loading = false;
  }

  showDetails(r: SearchResult) {
    console.log('test showDetails');
    this.router.navigateByUrl('details-object/' + r.id);
  }
}
