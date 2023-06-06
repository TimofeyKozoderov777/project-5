class Employee
{
    private double _Id;
    private string _fullName;
    private int _Departament;
    private double _Salary;
    private static double count = 0;

    public Employee(string fullName, int deportament, double salary)
    {
        _Id = count++;
        _fullName = fullName;
        _Departament = deportament;
        _Salary = salary; 

    }

    public string fullName
    {
        get { return _fullName; }
        set { _fullName = value; }
    }

    public double Salary
    {
        get => _Salary;
        set => _Salary = value;
    }

    public double Departament
    {
        get => _Departament;
        set => _Departament = (int)value;
    }
    public double Id
    {
        get => _Id;

    }
    public object Department { get; internal set; }
}


