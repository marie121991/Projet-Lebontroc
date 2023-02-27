import { Guid } from 'guid-typescript';

interface Owner {
  id: Guid;
  Fn: string;
  Ln: string;
}

interface Photo {
  id: Guid;
  f: BinaryData[];
  c: string;
}

export class Object {
  //Id:Guid
  //Label:string
  private _label!: string;
  public get label(): string {
    return this._label;
  }
  public set label(value: string) {
    if (!value || value.length > 150) {
      throw new Error('Label non valide');
    }
    this._label = value;
  }

  //#region objectState
  private _objectState!: number;
  public get objectState() {
    return this._objectState;
  }
  public set objectState(v: number) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._objectState = v;
  }
  //#endregion

  //#region description
  private _description!: string;
  public get description() {
    return this._description;
  }
  public set description(v: string) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._description = v;
  }
  //#endregion

  //#region idOwner
  private _idOwner!: Guid;
  public get idOwner() {
    return this._idOwner;
  }
  public set idOwner(v: Guid) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._idOwner = v;
  }
  //#endregion

  //#region Owner
  private _owner!: Owner;
  public get owner() {
    return this._owner;
  }
  public set owner(v: Owner) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._owner = v;
  }
  //#endregion

  //#region value
  private _value!: number;
  public get value() {
    return this._value;
  }
  public set value(v: number) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._value = v;
  }
  //#endregion

  //#region uploadDate
  private _uploadDate!: Date;
  public get uploadDate() {
    return this._uploadDate;
  }
  public set uploadDate(v: Date) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._uploadDate = v;
  }
  //#endregion

  //Owner:User

  //#region photos
  private _photos!: Photo[];
  public get photos() {
    return this._photos;
  }
  public set photos(v: Photo[]) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._photos = v;
  }
  //#endregion
}
