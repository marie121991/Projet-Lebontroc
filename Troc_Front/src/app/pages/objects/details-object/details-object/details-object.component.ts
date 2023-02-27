import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { ObjectService } from 'src/services/object.service';
import { Object } from 'src/models/object';

@Component({
  selector: 'app-details-object',
  templateUrl: './details-object.component.html',
  styleUrls: ['./details-object.component.scss'],
})
export class DetailsObjectComponent implements OnInit, OnDestroy {
  constructor(
    private objectService: ObjectService,
    private activatedRoute: ActivatedRoute
  ) {}

  object?: Object;
  state?: string;

  ngOnDestroy(): void {
    // this.object = null;
  }

  async ngOnInit() {
    let guid = Guid.parse(this.activatedRoute.snapshot.params['id']);

    this.object = await this.objectService.getItemAsync(guid);

    console.log('Test');
  }
}
