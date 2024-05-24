import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Announcement } from '../models/Announcement';
import { ResponseModel } from '../models/responseModel';
import { Observable } from 'rxjs';
import { Response } from '../models/response';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {
  selectedAnnouncement:any;
  constructor(private httpClient:HttpClient) { }

  apiUrl="http://localhost:5278/api/Announcements";

  getAll():Observable<ResponseModel<Announcement>>{
      return this.httpClient.get<ResponseModel<Announcement>>(
        'http://localhost:5278/api/Announcements?PageIndex=0&PageSize=100'
      );
  }

  getById(id:number):Observable<Response<Announcement>>{
    return this.httpClient.get<Response<Announcement>>('http://localhost:5278/api/Announcements/'+id)
  }

  add(announcement:Announcement):Observable<any>{
    const token = localStorage.getItem('Token'); 
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.httpClient.post<any>(this.apiUrl,announcement,{headers:headers})
  }
  editAnnouncement(announcement: Announcement):Observable<any>{
    const token = localStorage.getItem('Token'); 
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.httpClient.put<any>(this.apiUrl,announcement,{headers:headers})
  }

  deleteAnnouncement(announcementId:number){
    return this.httpClient.delete('http://localhost:5278/api/Announcements/'+announcementId);
  }
  
}
