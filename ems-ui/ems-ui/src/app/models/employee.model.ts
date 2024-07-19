export interface Employee {
    id?: number;
    name: string;
    position: string;
    department: string;
    salary: number;
  }
  
  export interface EmployeeAllResponse {
    totalCount: number;
    employees: Employee[];
  }
  