import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { IEmpire } from '../models/empire';
import { BaseHttpService } from './base-http.service';

@Injectable({
  providedIn: 'root',
})
export class EmpireService extends BaseHttpService<IEmpire> {
  constructor(httpClient: HttpClient,@Inject('BASE_URL') private baseUrl: string) {
    super(httpClient,baseUrl,'api/v1/empire');
  }

  getEmpires() {
    return this.get();
  }
}
