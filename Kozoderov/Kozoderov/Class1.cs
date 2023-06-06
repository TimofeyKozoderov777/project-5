using Kozoderov;

List<Employee> emplist = new List<Employee>(10)
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



int lol = int.Parse(Console.ReadLine());

switch (lol)
{
    case 1:
        GetInfoPeople(emplist);
        break;

    case 2:
        double totalSalary = GetSum(emplist);
        Console.WriteLine($"Зарплата всех сотрудников: {totalSalary}");
        break;

    case 3:
        GetMin(emplist);
        break;

    case 4:
        GetMax(emplist);
        break;

    case 5:
        GetAverageSalary(emplist);
        break;

    case 6:
        GetFullNamePeople(emplist);
        break;

    case 7:
        Console.WriteLine("Введите процент");
        int percent = int.Parse(Console.ReadLine());
        IndexSalary(emplist, percent);
        GetInfoPeople(emplist);
        break;

    case 8:
        Console.WriteLine("Введите номер департамента");
        int depNum = int.Parse(Console.ReadLine());
        GetMinSalaryByDep(emplist, depNum);
        break;

    case 9:
        Console.WriteLine("Введите номер департамента");
        int depNum1 = int.Parse(Console.ReadLine());
        GetMaxSalaryByDep(emplist, depNum1);
        break;

    case 10:
        Console.WriteLine("Введите номер департамента");
        int depNum2 = int.Parse(Console.ReadLine());
        GetAverageSalaryByDep(emplist, 4);
        break;

    case 11:
        Console.WriteLine("Введите номер департамента");
        int depNum3 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите процент");
        int percent1 = int.Parse(Console.ReadLine());
        IndexSalary(emplist, percent1);
        GetEmployeesByDepartment(emplist, 4);
        break;

    case 12:
        Console.WriteLine("Введите номер департамента");
        int depNum4 = int.Parse(Console.ReadLine());
        GetEmployeesByDepartment(emplist, 4);
        break;

    case 13:
        Console.WriteLine("Введите сумму для сравнения зарплат сотрудников");
        double threshold = int.Parse(Console.ReadLine());
        GetEmployeesWithSalaryLessThan(emplist, threshold);
        break;

    case 14:
        Console.WriteLine("Введите сумму для сравнения зарплат сотрудников");
        double threshold1 = int.Parse(Console.ReadLine());
        GetEmployeesWithSalaryGreaterOrEqualTo(emplist, threshold1);
        break;
}

void GetInfoPeople(List<Employee> employee)
{
    foreach (Employee emp in employee)
    {
        Console.WriteLine("id: " + emp.Id + " ");
        Console.WriteLine("ФИО: " + emp.fullName + " ");
        Console.WriteLine("Номер департамента: " + emp.Departament + " ");
        Console.WriteLine("Заработная плата: " + emp.Salary + " руб." + "\n");
    }
}

double GetSum(List<Employee> employee)
{
    double sum = 0;
    foreach (Employee emp in employee)
    {
        sum += emp.Salary;
    }
    return sum;
}

void GetMax(List<Employee> employee)
{
    Employee MaxSalary;
    for (int i = 0; i < employee.Count; i++)
    {
        for (int j = i + 1; j < employee.Count; j++)
        {
            if (employee[i].Salary > employee[j].Salary)
            {
                MaxSalary = employee[i];
                employee[i] = employee[j];
                employee[j] = MaxSalary;
            }
        }
    }
    Console.Write("Сотрудник с максимальной заработной платой: " + "id: " + $"{ employee[employee.Count - 1].Id}" + " | ");
    Console.Write($"{employee[employee.Count - 1].fullName}" + " | ");
    Console.Write($"{employee[employee.Count - 1].Departament}" + " | ");
    Console.Write($"{employee[employee.Count - 1].Salary}" + " руб." + "\n");
}

void GetMin(List<Employee> employee)
{
    Employee MinSalary;
    for (int i = 0; i < employee.Count; i++)
    {
        for (int j = i + 1; j < employee.Count; j++)
        {
            if (employee[i].Salary < employee[j].Salary)
            {
                MinSalary = employee[i];
                employee[i] = employee[j];
                employee[j] = MinSalary;
            }
        }
    }
    Console.Write("Сотрудник с минимальной заработной платой: " + "id: " + $"{ employee[employee.Count - 1].Id}" + " | ");
    Console.Write($"{employee[employee.Count - 1].fullName}" + " | ");
    Console.Write($"{employee[employee.Count - 1].Departament}" + " | ");
    Console.Write($"{employee[employee.Count - 1].Salary}" + " руб." + "\n" + "\n");
}

void GetAverageSalary(List<Employee> employee)
{
    var employees = employee.ToList();
    if (employees.Any())
    {
        double sumSalary = employees.Sum(emp => emp.Salary);
        int countEmployee = employees.Count();
        double averageSalary = sumSalary / countEmployee;
        Console.WriteLine($"|Средняя зарплата сотрудников|: {averageSalary} руб." + "\n");
    }
}

void GetFullNamePeople(List<Employee> employee)
{
    foreach (Employee emp in employee)
    {
        Console.WriteLine("ФИО: " + emp.fullName + " ");
    }
}


void IndexSalary(List<Employee> employee, double percent)
{
    employee.ForEach(emp => emp.Salary *= (1 + percent / 100));
}

void IndexSalary1(List<Employee> employee, double percent1)
{
    employee.ForEach(emp => emp.Salary *= (1 + percent1 / 100));
}

void GetMinSalaryByDep(List<Employee> employee, int depNum)
{
    var employees = employee.Where(emp => emp.Departament == depNum);
    if (employees.Any())
    {
        Employee MinSalary = employees.First();
        foreach (Employee emp in employees)
        {
            if (emp.Salary < MinSalary.Salary)
            {
                MinSalary = emp;
            }
        }

        Console.Write("Сотрудник с минимальной заработной платой в этом отделе : id: " + $"{MinSalary.Id}" + " | ");
        Console.Write($"{MinSalary.fullName}" + " | ");
        Console.Write($"{MinSalary.Salary}" + " руб." + "\n");
    }
}



void GetMaxSalaryByDep(List<Employee> employee, int depNum1)
{
    var employees = employee.Where(emp => emp.Departament == depNum1);
    if (employees.Any())
    {
        Employee MaxSalary = employees.First();
        foreach (Employee emp in employees)
        {
            if (emp.Salary > MaxSalary.Salary)
            {
                MaxSalary = emp;
            }
        }
        Console.Write("|Сотрудник с максимальной заработной платой в отделе 4|: id: " + $"{MaxSalary.Id}" + " | ");
        Console.Write($"{MaxSalary.fullName}" + " | ");
        Console.Write($"{MaxSalary.Salary}" + " руб." + "\n" + "\n");
    }
}

void GetAverageSalaryByDep(List<Employee> employee, int depNum2)
{
    var employees = employee.Where(emp => emp.Departament == depNum2);
    if (employees.Any())
    {
        double sumSalary = employees.Sum(emp => emp.Salary);
        int countEmployee = employees.Count();
        double averageSalary = sumSalary / countEmployee;
        Console.WriteLine($"|Средняя зарплата сотрудников в отделе 4|: {averageSalary} руб." + "\n");
    }
}

void GetEmployeesByDepartment(List<Employee> employee, int depNum3)
{
    var employees = employee.Where(emp => emp.Departament == depNum3);
    if (employees.Any())
    {
        foreach (Employee emp in employees)
        {
            Console.WriteLine("Departament 4: ");
            Console.WriteLine("ФИО: " + emp.fullName + " ");
            Console.WriteLine("Заработная плата: " + emp.Salary + " руб." + "\n");
        }
    }
}


void GetEmployeesWithSalaryLessThan(List<Employee> employee, double salary)
{
    var employees = employee.Where(emp => emp.Salary < salary);
    foreach (var emp in employees)
    {
        Console.WriteLine("|Зарплата < 85000 руб.|: " + $"id: {emp.Id}, ФИО: {emp.fullName}, Заработная плата: {emp.Salary}");
    }
}

void GetEmployeesWithSalaryGreaterOrEqualTo(List<Employee> employee, double salary)
{
    var employees = employee.Where(emp => emp.Salary >= salary);
    foreach (var emp in employees)
    {
        Console.WriteLine("|Зарплата > 85000 руб.|: " + $"id: {emp.Id}, ФИО: {emp.fullName}, Заработная плата: {emp.Salary}" + " руб.");
    }
}












