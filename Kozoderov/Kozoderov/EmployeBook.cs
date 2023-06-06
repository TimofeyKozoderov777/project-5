using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozoderov
{
    public class EmployeeBook
    {

        private List<Employee> emplist = new List<Employee>(10)
        {
        new Employee("Горбунов Корней Вадимович", 1, 70000.00),
        new Employee("Ермаков Гордей Мэлсович",2, 80000.00),
        new Employee("Попов Афанасий Степанович", 3, 75000.00),
        new Employee("Овчинников Абрам Федосеевич", 4, 75000.00),
        new Employee("Никифоров Трофим Константинович", 4, 85000.00),
        new Employee("Суханов Панкратий Артемович", 5, 100000.00),
        new Employee("Беляева Вероника Григорьевна", 5, 90000.00),
        new Employee("Шевцова Амелия Фёдоровна", 3, 73000.00),
        new Employee("Чистякова Ника Ивановна", 1, 77000.00),
        new Employee("Панков Владимир Артурович", 2, 60000.00),
        };
        public void Info()
        {
            var select = emplist.OrderBy(x => x.Department);
            foreach (Employee e in select)
            {
                Console.WriteLine($"id={e.Id}|{e.fullName}|{e.Salary}|{e.Department} ");

            }
        }
        public double Sum()
        {
            double sum = 0;
            foreach (Employee e in emplist)
            {
                sum += e.Salary;

            }
            return sum;
        }

        public void Max()
        {

            Console.WriteLine($"Человек с самой максимальной зарплатой {emplist.Max(e => e.Salary + " рублей: " + e.fullName)} ");
        }
        public void GetMin()
        {
            Console.WriteLine($"Человек с самой минимальной зарплатой {emplist.Min(e => e.Salary + " рублей: " + e.fullName)} ");

        }
        public void Indexer(double num)
        {

            foreach (Employee e in emplist)
            {
                e.Salary *= num;
            }
            foreach (Employee e in emplist)
            {
                Console.WriteLine($"{e.fullName}|{e.Salary}");


            }

        }
        public void AverageSalary()
        {
            Console.WriteLine($"Среднее значение зарплат: {emplist.Average(e => e.Salary)}");

        }
        public void fullName()
        {
            foreach (Employee e in emplist)
            {
                Console.WriteLine(e.fullName);
            }
        }

        public void MaxSalaryByDep()
        {
            Console.WriteLine("Введите номер отдела");
            double department = double.Parse(Console.ReadLine());
            var employeesInDepartment = emplist.Where(e => e.Departament == department);
            if (employeesInDepartment.Any())
            {
                var employeeWithMinSalary = employeesInDepartment.OrderBy(e => e.Salary).First();
                Console.WriteLine($" {employeeWithMinSalary.fullName}|{employeeWithMinSalary.Salary}");
            }
            else
            {
                Console.WriteLine($"Отдел {department} не найден или не имеет сотрудников.");
            }
        }
        public void MaxSalaryByDep1()
        {
            Console.WriteLine("Введите номер отдела"); double department = double.Parse(Console.ReadLine());
            var employeesInDepartment = emplist.Where(e => e.Departament == department);
            if (employeesInDepartment.Any())
            {
                var employeeWithMaxSalary = employeesInDepartment.OrderBy(e => e.Salary).Last();
                Console.WriteLine($" {employeeWithMaxSalary.fullName}|{employeeWithMaxSalary.Salary}");
            }
            else
            {
                Console.WriteLine($"Отдел {department} не найден или не имеет сотрудников.");
            }

        }

        public void DeprtmentAvgInfo()
        {

            Console.WriteLine("Введите номер отдела");
            int dptChoi = int.Parse(Console.ReadLine());
            var empInDpt = emplist.Where(p => p.Departament == dptChoi);

            var avg = empInDpt.Average(e => e.Salary);

            Console.WriteLine(avg);

        }
        public void DeprtmentInfo()
        {

            Console.WriteLine("Введите номер отдела:");
            int departmentID = int.Parse(Console.ReadLine());

            var empInDpt = emplist.Where(p => p.Departament == departmentID);
            if (empInDpt.Any())
            {
                foreach (var e in empInDpt)
                {
                    Console.WriteLine($"{e.Id}|{e.fullName}|{e.Salary}");
                }
            }

        }

        public void EmployeesWithSalaryLessThan(double num)
        {
            var select = emplist.Where(p => p.Salary < num);

            foreach (var s in select)
            {
                Console.WriteLine($"{s.Id}|{s.fullName}|{s.Salary}");
            }
        }

        public void EmployeesWithSalaryGreaterOrEqualTo(double num)
        {
            var select = emplist.Where(p => p.Salary >= num);

            foreach (var s in select)
            {
                Console.WriteLine($"{s.Id}|{s.fullName}|{s.Salary}");
            }
        }


        public void CreateNewEmployee()
        {
            Console.WriteLine("Введите сотруднику ФИО: ");
            string fio = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите сотруднику отдел: ");
            int dep = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сотруднику зарплату: ");
            double sal = Convert.ToDouble(Console.ReadLine());

            emplist.Add(new Employee(fullName: fio, deportament: dep, salary: sal));
            Console.WriteLine($"Добавлен сотрудник - {fio} в отдел {dep} с зарплатой {sal}");
            foreach (var emp in emplist)
            {
                Console.WriteLine($"{emp.Id}|{emp.fullName}|{emp.Department}|{emp.Salary}");
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Выберите ID человека, которого хотите удалить: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Employee emp in emplist)
            {
                if (emp.Id == id)
                {
                    emplist.Remove(emp);
                    break;
                }
            }
            if (emplist.Count > 0)
            {
                Console.WriteLine("Текущее состояние колекции");
                foreach (Employee emp in emplist)
                {
                    Console.WriteLine($"{emp.Id}. {emp.fullName}, {emp.Department}, {emp.Salary} руб.");
                }
            }
        }
        public void ChangrEmploee()
        {
            Console.WriteLine("Выберите ID человека, которого хотите изменить: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите отдел, в котором будет работать этот человек");
            int newDep = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите зарплату, которую будет получать этот человек");
            double newSal = Convert.ToDouble(Console.ReadLine());
            foreach (Employee emp in emplist)
            {
                if (emp.Id == id)
                {
                    emp.Department = newDep;
                    emp.Salary = newSal;
                    break;
                }
            }
            Console.WriteLine("Список сотрудников после изменения:");
            foreach (Employee emp in emplist)
            {
                Console.WriteLine($"{emp.Id}.{ emp.fullName}, { emp.Department}, { emp.Salary} руб.");
            }
        }
        public void GetInfoInDepts()
        {
            var employeesByDepartment = emplist.OrderBy(e => e.Department);
            foreach (var emp in employeesByDepartment)
            {
                Console.WriteLine($"Сотрудник из отдела {emp.Department} - {emp.fullName}");
            }

            int lol1 = int.Parse(Console.ReadLine());
            switch (lol1)
            {
                case 1:
                    Info(emplist);
                    break;

                case 2:
                    double totalSalary = Sum(emplist);
                    Console.WriteLine($"Зарплата всех сотрудников: {totalSalary}");
                    break;

                case 3:
                    GetMin(emplist);
                    break;

                case 4:
                    GetMax(emplist);
                    break;

                case 5:
                    AverageSalary(emplist);
                    break;

                case 6:
                    FullName(emplist);
                    break;

                case 7:

                    break;

                case 8:
                    Console.WriteLine("Введите номер департамента");
                    int depNum = int.Parse(Console.ReadLine());
                    MinSalaryByDep(emplist, depNum);
                    break;

                case 9:
                    Console.WriteLine("Введите номер департамента");
                    int depNum1 = int.Parse(Console.ReadLine());
                    MaxSalaryByDep1(emplist, depNum1);
                    break;

                case 10:
                    Console.WriteLine("Введите номер департамента");
                    int depNum2 = int.Parse(Console.ReadLine());
                    DeprtmentAvgInfo(emplist, 4);
                    break;

                case 11:

                    break;

                case 12:
                    Console.WriteLine("Введите номер департамента");
                    int depNum4 = int.Parse(Console.ReadLine());
                    DeprtmentInfo(emplist, 4);
                    break;

                case 13:
                    Console.WriteLine("Введите сумму для сравнения зарплат сотрудников");
                    double threshold = int.Parse(Console.ReadLine());
                    EmployeesWithSalaryLessThan(emplist, threshold);
                    break;

                case 14:
                    Console.WriteLine("Введите сумму для сравнения зарплат сотрудников");
                    double threshold1 = int.Parse(Console.ReadLine());
                    EmployeesWithSalaryGreaterOrEqualTo(emplist, threshold1);
                    break;
                case 15:
                    CreateNewEmployee();
                    break;
                case 16:
                    DeleteEmployee();
                    break;
                case 17:
                    ChangrEmploee();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Выберите номер кейса:");

            Console.WriteLine("case 1: 1 - a - Список всех сотрудников со всеми их данными");
            Console.WriteLine("case 2: 1 - b Сумма всех затрат на зарплаты сотрудников");
            Console.WriteLine("case 3: 1 - c Найти сотрудника с минимальной зарплатой");
            Console.WriteLine("case 4: 1 - d Найти сотрудника с максимальной зарплатой");
            Console.WriteLine("case 5: 1 - e Подсчитать среднее значение зарплат");
            Console.WriteLine("case 6: 1 - f Получить ФИО всех сотрудников");

            Console.WriteLine("case 7: 2 - 1 - Проиндексировать зарплату");
            Console.WriteLine("case 8: 2 - 2 - a - Сотрудник с минимальной зарплатой в департаменте");
            Console.WriteLine("case 9: 2 - 2 - b - Сотрудник с максимальной зарплатой в департаменте");
            Console.WriteLine("case 10: 2 - 2 - c - Средняя зарплата по отделу");
            Console.WriteLine("case 11: 2 - 2 - e - Проиндексировать зарплату всех сотрудников в депортаменте");
            Console.WriteLine("case 12: 2 - 2 - f - Напечатать всех сотрудников отдела");
            Console.WriteLine("case 13: 2 - 3 - a - Все сотрудники зарплата которых меньше числа");
            Console.WriteLine("case 14: 2 - 3 - b - Все сотрудники зарплата которых больше числа");

            Console.WriteLine("case 15: 3 - 4 - a - Добавление сотрудника");
            Console.WriteLine("case 16: 3 - 4 - b - Удаление сотрудника");
            Console.WriteLine("case 17: 3 - 5 - a,b - Изменение сотрудника");

        }

        private double Sum(List<Employee> emplist)
        {
            throw new NotImplementedException();
        }

        private void Info(List<Employee> emplist)
        {
            throw new NotImplementedException();
        }

        private void EmployeesWithSalaryGreaterOrEqualTo(List<Employee> emplist, double threshold1)
        {
            throw new NotImplementedException();
        }

        private void EmployeesWithSalaryLessThan(List<Employee> emplist, double threshold)
        {
            throw new NotImplementedException();
        }

        private void DeprtmentInfo(List<Employee> emplist, int v)
        {
            throw new NotImplementedException();
        }

        private void DeprtmentAvgInfo(List<Employee> emplist, int v)
        {
            throw new NotImplementedException();
        }

        private void AverageSalaryByDep1(List<Employee> emplist, int v)
        {
            throw new NotImplementedException();
        }

        private void MaxSalaryByDep1(List<Employee> emplist, int depNum1)
        {
            throw new NotImplementedException();
        }

        private void AverageSalaryByDep(List<Employee> emplist, int v)
        {
            throw new NotImplementedException();
        }

        private void MaxSalaryByDep(List<Employee> emplist, int depNum1)
        {
            throw new NotImplementedException();
        }

        private void MinSalaryByDep(List<Employee> emplist, int depNum)
        {
            throw new NotImplementedException();
        }

        private void FullName(List<Employee> emplist)
        {
            throw new NotImplementedException();
        }

        private void AverageSalary(List<Employee> emplist)
        {
            throw new NotImplementedException();
        }

        private void GetMax(List<Employee> emplist)
        {
            throw new NotImplementedException();
        }

        private void GetMin(List<Employee> emplist)
        {
            throw new NotImplementedException();
        }
    }
}







































