import { formatDate } from '@angular/common';
export class PastAppointment {
  id: number;
  img: string;
  name: string;
  email: string;
  gender: string;
  date: string;
  time: string;
  mobile: string;
  doctor: string;
  injury: string;
  constructor(appointment: PastAppointment) {
    {
      this.id = appointment.id || this.getRandomID();
      this.img = appointment.img || 'assets/images/user/user1.jpg';
      this.name = appointment.name || '';
      this.email = appointment.email || '';
      this.gender = appointment.gender || 'Masculino';
      this.date = formatDate(new Date(), 'yyyy-MM-dd', 'en') || '';
      this.time = appointment.time || '';
      this.mobile = appointment.mobile || '';
      this.doctor = appointment.mobile || '';
      this.injury = appointment.mobile || '';
    }
  }
  public getRandomID(): number {
    const S4 = () => {
      return ((1 + Math.random()) * 0x10000) | 0;
    };
    return S4() + S4();
  }
}
