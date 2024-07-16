export class Patient {
  personId: string;
  personImage64: string | null; // null o la URL de la imagen
  docNumber: string;
  name: string;
  sexTypeId: number;
  gender: string;
  addressLocation: string;
  telephoneNumber: string;
  birthdate: string;

  constructor(patient: any) { // Cambia 'any' por una interfaz más específica si es necesario
    this.personId = patient.personId;
    this.docNumber = patient.docNumber;
    this.name = patient.name;
    this.sexTypeId = patient.sexTypeId;
    this.gender = patient.gender;
    this.addressLocation = patient.addressLocation;
    this.telephoneNumber = patient.telephoneNumber;
    this.birthdate = patient.birthdate;

    // Convertir byte[] a una URL de imagen en Base64 o usar imagen predeterminada si es null
    this.personImage64 ='https://images.freeimages.com/fic/images/icons/766/base_software/256/user1.png';
  }
}

export interface PaginationParams {
  page: number;
  pageSize: number;
}

export interface Filter extends PaginationParams {
  filter: string;
}
