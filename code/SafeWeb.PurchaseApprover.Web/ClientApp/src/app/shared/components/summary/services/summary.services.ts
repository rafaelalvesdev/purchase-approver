import { Injectable, Output, ComponentFactoryResolver, ViewChild } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { FormGroup } from '@angular/forms';

export const IconType = {
  success: 'fa-edit',
  danger: 'fa-edit'
};
export interface IErrorApi {
  Context: any;
  ErrorCode: string;
  ErrorGroup: string;
  ErrorMessage: string
  HelpEntry: string
  Key: string
}
export interface ISuccessApi {
  Context: any;
  SuccessCode: string;
  SuccessGroup: string;
  SuccessMessage: string
  HelpEntry: string
  Key: string
}
export interface IWarningApi {
  Context: any;
  WarningCode: string;
  WarningGroup: string;
  WarningMessage: string
  HelpEntry: string
  Key: string
}

export interface ISummary {
  errors: Array<any>,
  success: Array<any>,
  warnings: Array<any>,
  FormGroup: FormGroup
}

@Injectable()
export class SummaryService {
  private objObservable = new Subject<ISummary>();
  constructor() { }

  summary(summary: ISummary) {
    this.objObservable.next(summary);
  }

  getSummary(): Observable<ISummary> {
    return this.objObservable.asObservable();
  }
}
