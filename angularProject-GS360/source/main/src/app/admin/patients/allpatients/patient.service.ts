import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, throwError } from 'rxjs';
import { Filter, Patient } from './patient.model';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { UnsubscribeOnDestroyAdapter } from '@shared';
import { environment } from 'environments/environment.development';
@Injectable()
export class PatientService extends UnsubscribeOnDestroyAdapter {

  private readonly API_URL = 'assets/data/patient.json';
  isTblLoading = true;
  dataChange: BehaviorSubject<Patient[]> = new BehaviorSubject<Patient[]>([]);
  // Temporarily stores data from dialogs
  dialogData!: Patient;
  constructor(private httpClient: HttpClient) {
    super();
  }
  get data(): Patient[] {
    return this.dataChange.value;
  }
  getDialogData() {
    return this.dialogData;
  }
  /** CRUD METHODS */
  getAllPatients(): void {
    this.subs.sink = this.httpClient.get<Patient[]>(this.API_URL).subscribe({
      next: (data) => {
        this.isTblLoading = false;
        this.dataChange.next(data);
      },
      error: (error: HttpErrorResponse) => {
        this.isTblLoading = false;
        console.log(error.name + ' ' + error.message);
      },
    });
  }
  // Nuevo método para paginación
  getPatientsPage(page: number, pageSize: number, filter: string): Observable<any> {
      const filterParams: Filter ={
        filter: filter,
        page: page,
        pageSize: pageSize
      }
    // Asume que tu API retorna un objeto con los pacientes y el total de filas
    return this.httpClient.post<any>(`${environment.apiAppointment}/person/BuscarPersonasConFiltro`, filterParams)
      .pipe(
        map(response => {
          // Verificar si el status es 1 y si objModel está presente
          if (response.status === 1 && response.objModel) {
            // Extraer y retornar los pacientes y el totalRows de objModel
            return {
              patients: response.objModel.patients,
              totalRows: response.objModel.totalRows
            };
          } else {
            // Si el status no es 1, lanzar un error
            return throwError(() => new Error('Failed to load the patients data'));
          }
        }),
        catchError(error => {
          // Manejar cualquier error de la solicitud HTTP
          console.error('Error fetching patients:', error);
          return throwError(() => new Error('Error fetching patients'));
        })
      );
  }

  addPatient(patient: Patient): void {
    this.dialogData = patient;

    // this.httpClient.post(this.API_URL, patient)
    //   .subscribe({
    //     next: (data) => {
    //       this.dialogData = patient;
    //     },
    //     error: (error: HttpErrorResponse) => {
    //        // error code here
    //     },
    //   });
  }
  updatePatient(patient: Patient): void {
    this.dialogData = patient;

    // this.httpClient.put(this.API_URL + patient.id, patient)
    //     .subscribe({
    //       next: (data) => {
    //         this.dialogData = patient;
    //       },
    //       error: (error: HttpErrorResponse) => {
    //          // error code here
    //       },
    //     });
  }
  deletePatient(id: number): void {
    console.log(id);

    // this.httpClient.delete(this.API_URL + id)
    //     .subscribe({
    //       next: (data) => {
    //         console.log(id);
    //       },
    //       error: (error: HttpErrorResponse) => {
    //          // error code here
    //       },
    //     });
  }
}
