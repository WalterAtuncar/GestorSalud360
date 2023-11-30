import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgScrollbarModule } from 'ngx-scrollbar';
import { NgChartsModule } from 'ng2-charts';
import { NgxEchartsModule } from 'ngx-echarts';
import { NgApexchartsModule } from 'ng-apexcharts';
import { PatientRoutingModule } from './patient-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ComponentsModule } from '../shared/components/components.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    NgChartsModule,
    NgxEchartsModule.forRoot({
      echarts: () => import('echarts'),
    }),
    NgScrollbarModule,
    PatientRoutingModule,
    NgApexchartsModule,
    ComponentsModule,
    SharedModule,
  ],
})
export class PatientModule {}
