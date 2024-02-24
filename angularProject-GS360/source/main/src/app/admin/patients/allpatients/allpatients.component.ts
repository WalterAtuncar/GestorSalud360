import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PatientService } from './patient.service';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Patient } from './patient.model';
import { DataSource } from '@angular/cdk/collections';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
} from '@angular/material/snack-bar';
import { FormDialogComponent } from './dialog/form-dialog/form-dialog.component';
import { DeleteComponent } from './dialog/delete/delete.component';
import { BehaviorSubject, fromEvent, merge, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { SelectionModel } from '@angular/cdk/collections';
import { Direction } from '@angular/cdk/bidi';
import {
  UnsubscribeOnDestroyAdapter,
} from '@shared';

@Component({
  selector: 'app-allpatients',
  templateUrl: './allpatients.component.html',
  styleUrls: ['./allpatients.component.scss'],
})
export class AllpatientsComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  displayedColumns = [
    'select',
    'img',
    'name',
    'gender',
    'address',
    'mobile',
    'date',
    'bGroup',
    'actions',
  ];
  exampleDatabase?: PatientService;
  dataSource!: ExampleDataSource;
  selection = new SelectionModel<Patient>(true, []);
  index?: number;
  id?: string;
  patient?: Patient;
  patients: Patient[] = [];
  isTblLoading = false;
  constructor(
    public httpClient: HttpClient,
    public dialog: MatDialog,
    public patientService: PatientService,
    private snackBar: MatSnackBar
  ) {
    super();
  }
  @ViewChild(MatPaginator, { static: true })
  paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true })
  sort!: MatSort;
  @ViewChild('filter', { static: true }) filter?: ElementRef;
  ngOnInit() {
    this.paginator.pageSize = 10;
    this.loadData();
  }
  override ngOnDestroy() {
    this.dataSource.disconnect();
  }
  refresh() {
    this.loadData();
  }
  addNew() {
    let tempDirection: Direction;
    if (localStorage.getItem('isRtl') === 'true') {
      tempDirection = 'rtl';
    } else {
      tempDirection = 'ltr';
    }
    const dialogRef = this.dialog.open(FormDialogComponent, {
      data: {
        patient: this.patient,
        action: 'add',
      },
      direction: tempDirection,
    });
    this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
      if (result === 1) {
        // After dialog is closed we're doing frontend updates
        // For add we're just pushing a new row inside DataService
        this.exampleDatabase?.dataChange.value.unshift(
          this.patientService.getDialogData()
        );
        this.refreshTable();
        this.showNotification(
          'snackbar-success',
          'Add Record Successfully...!!!',
          'bottom',
          'center'
        );
      }
    });
  }
  editCall(row: Patient) {
    this.id = row.personId;
    let tempDirection: Direction;
    if (localStorage.getItem('isRtl') === 'true') {
      tempDirection = 'rtl';
    } else {
      tempDirection = 'ltr';
    }
    const dialogRef = this.dialog.open(FormDialogComponent, {
      data: {
        patient: row,
        action: 'edit',
      },
      direction: tempDirection,
    });
    this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
      if (result === 1) {
        // When using an edit things are little different, firstly we find record inside DataService by id
        const foundIndex = this.exampleDatabase?.dataChange.value.findIndex(
          (x) => x.personId === this.id
        );
        // Then you update that record using data from dialogData (values you enetered)
        if (foundIndex != null && this.exampleDatabase) {
          this.exampleDatabase.dataChange.value[foundIndex] =
            this.patientService.getDialogData();
          // And lastly refresh table
          this.refreshTable();
          this.showNotification(
            'black',
            'Edit Record Successfully...!!!',
            'bottom',
            'center'
          );
        }
      }
    });
  }
  deleteItem(row: Patient) {
    this.id = row.personId;
    let tempDirection: Direction;
    if (localStorage.getItem('isRtl') === 'true') {
      tempDirection = 'rtl';
    } else {
      tempDirection = 'ltr';
    }
    const dialogRef = this.dialog.open(DeleteComponent, {
      data: row,
      direction: tempDirection,
    });
    this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
      if (result === 1) {
        const foundIndex = this.exampleDatabase?.dataChange.value.findIndex(
          (x) => x.personId === this.id
        );
        // for delete we use splice in order to remove single object from DataService
        if (foundIndex != null && this.exampleDatabase) {
          this.exampleDatabase.dataChange.value.splice(foundIndex, 1);

          this.refreshTable();
          this.showNotification(
            'snackbar-danger',
            'Delete Record Successfully...!!!',
            'bottom',
            'center'
          );
        }
      }
    });
  }
  private refreshTable() {
    this.paginator._changePageSize(this.paginator.pageSize);
  }
  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    /*const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.renderedData.length;
    return numSelected === numRows;*/
    return false;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    /*this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.renderedData.forEach((row) =>
          this.selection.select(row)
        );*/
  }
  removeSelectedRows() {
   /*const totalSelect = this.selection.selected.length;
    this.selection.selected.forEach((item) => {
      const index: number = this.dataSource.renderedData.findIndex(
        (d) => d === item
      );
      // console.log(this.dataSource.renderedData.findIndex((d) => d === item));
      this.exampleDatabase?.dataChange.value.splice(index, 1);
      this.refreshTable();
      this.selection = new SelectionModel<Patient>(true, []);
    });
    this.showNotification(
      'snackbar-danger',
      totalSelect + ' Record Delete Successfully...!!!',
      'bottom',
      'center'
    );*/
  }
  public loadData() {
    this.exampleDatabase = new PatientService(this.httpClient);
    this.dataSource = new ExampleDataSource(
      this.exampleDatabase,
      this.paginator
    );
    this.subs.sink = fromEvent(this.filter?.nativeElement, 'keyup').subscribe(
      () => {
        if (!this.dataSource) {
          return;
        }
        this.dataSource.filter = this.filter?.nativeElement.value;
      }
    );
    this.subscribeToData();
  }
  subscribeToData() {
    this.isTblLoading = true;
    this.dataSource.connect().subscribe(data => {
      this.patients = data;
      this.isTblLoading = false;
    });
  
    // Asegúrate de desuscribirte en ngOnDestroy
  }
  // export table data in excel file
  exportExcel() {
    // key name with space add in brackets
    //const exportData: Partial<TableElement>[] = {}
      /*this.dataSource.filteredData.map((x) => ({
        Name: x.name,
        Gender: x.gender,
        Address: x.address,
        'Birth Date': formatDate(new Date(x.date), 'yyyy-MM-dd', 'en') || '',
        'Blood Group': x.bGroup,
        Mobile: x.mobile,
        Treatment: x.treatment,
      }));*/
    //TableExportUtil.exportToExcel(exportData, 'excel');
  }

  showNotification(
    colorName: string,
    text: string,
    placementFrom: MatSnackBarVerticalPosition,
    placementAlign: MatSnackBarHorizontalPosition
  ) {
    this.snackBar.open(text, '', {
      duration: 2000,
      verticalPosition: placementFrom,
      horizontalPosition: placementAlign,
      panelClass: colorName,
    });
  }
}
export class ExampleDataSource extends DataSource<Patient> {
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private patientsSubject = new BehaviorSubject<Patient[]>([]);

  public loading$ = this.loadingSubject.asObservable();
  
  filterChange = new BehaviorSubject<string>('');
  get filter(): string {
    return this.filterChange.value;
  }
  set filter(filter: string) {
    this.filterChange.next(filter);
  }

  constructor(
    private patientService: PatientService,
    private paginator: MatPaginator
  ) {
    super();
    // Inicializar la carga de datos
    this.loadPatients();
  }

  // Método para cargar pacientes según la paginación y el filtro actual
  loadPatients() {
    // eslint-disable-next-line no-debugger
    //debugger;
    if (this.loadingSubject.value) {
      return; 
    }

    this.loadingSubject.next(true);
    this.patientService.getPatientsPage(
      this.paginator.pageIndex + 1, // Asegúrate de que la paginación en el backend empieza en 1
      this.paginator.pageSize,
      this.filter
    ).subscribe((data) => {
      console.log("data", data)
      this.loadingSubject.next(false);
      this.patientsSubject.next(data.patients);
      this.paginator.length = data.totalRows; // Actualizar el total de elementos para el paginador
    }, (error : unknown)=> {
      this.loadingSubject.next(false);
      console.log("err", error)
    });
  }

  connect(): Observable<Patient[]> {
    // Escuchar cambios en el filtro o en la paginación para recargar los pacientes
    merge(this.filterChange, this.paginator.page)
      .pipe(
        tap(() => this.loadPatients())
      ).subscribe();

    return this.patientsSubject.asObservable();
  }

  disconnect(): void {
    this.patientsSubject.complete();
    this.loadingSubject.complete();
  }
}

