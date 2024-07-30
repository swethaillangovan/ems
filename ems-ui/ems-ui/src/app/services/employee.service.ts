import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee, EmployeeAllResponse } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = `${environment.apiUrl}/Employee`;

  constructor(private http: HttpClient) { }

  getEmployees(page: number, pageSize: number): Observable<EmployeeAllResponse> {
    let params = new HttpParams().set('page', page.toString()).set('pageSize', pageSize.toString());
    return this.http.get<EmployeeAllResponse>(this.apiUrl, { params });
  }

  getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }

  addEmployee(employee: Employee): Observable<boolean> {
    return this.http.post<boolean>(this.apiUrl, employee);
  }

  updateEmployee(id: number, employee: Employee): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}/${id}`, employee);
  }

  deleteEmployee(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
  getEmployeesBySearch(text:string): Observable<EmployeeAllResponse> {
    let params = new HttpParams().set('text', text);
    return this.http.get<EmployeeAllResponse>(this.apiUrl, { params });
  }
}
