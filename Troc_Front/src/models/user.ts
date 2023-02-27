import { Guid } from 'guid-typescript';
import { Object } from './object';

interface Address {
  street: string;
  zipCode: string;
  city: string;
}

export class User {
  //#region Id
  private _id!: string;
  public get id() {
    return this._id;
  }
  public set id(v: string) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._id = v;
  }
  //#endregion

  //#region userName
  private _userName!: string;
  public get userName() {
    return this._userName;
  }
  public set userName(v: string) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._userName = v;
  }
  //#endregion

  //#region token
  private _token!: string;
  public get token() {
    return this._token;
  }
  public set token(v: string) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._token = v;
  }
  //#endregion

  //#region groups
  private _groups!: string[];
  public get groups() {
    return this._groups;
  }
  public set groups(v: string[]) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._groups = v;
  }
  //#endregion

  //#region firstName
  private _firstName: string;
  public get firstName() {
    return this._firstName;
  }
  public set firstName(v: string) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._firstName = v;
  }
  //#endregion

  //#region lastName
  private _lastName: string;
  public get lastName() {
    return this._lastName;
  }
  public set lastName(v: string) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._lastName = v;
  }
  //#endregion

  //#region address
  private _address: Address;
  public get address() {
    return this._address;
  }
  public set address(v: Address) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._address = v;
  }
  //#endregion

  //#region photo
  private _photo: string;
  public get photo() {
    return this._photo;
  }
  public set photo(v: string) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._photo = v;
  }
  //#endregion

  //#region dateInscription
  private _dateInscription: Date;
  public get dateInscription() {
    return this._dateInscription;
  }
  public set dateInscription(v: Date) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._dateInscription = v;
  }
  //#endregion

  //#region objects
  private _objects: Object[];
  public get objects() {
    return this._objects;
  }
  public set objects(v: Object[]) {
    // TODO : Check value of v
    // if(condition){
    // throw new Error('message');
    // }
    this._objects = v;
  }
  //#endregion
}
