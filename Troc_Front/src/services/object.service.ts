import { Injectable } from '@angular/core';
import { Object } from '../models/object';
import { ScrudService } from './scrud.service';

@Injectable({
  providedIn: 'root',
})
export abstract class ObjectService extends ScrudService<Object> {}
