```c#
/ See https://aka.ms/new-console-template for more information

using ConsoleTables;

var personAccount = new CPersonAccount();
do
{
    Console.WriteLine("請選擇作業(i=輸入資料, s=依照月薪排序, d=顯示資料, q=結束, m=匯入基本資料):d <Enter>");
    var inputKey = Console.ReadKey();

    if (inputKey.Key == ConsoleKey.Q)
    {
        Console.WriteLine("結束程式");
        break;
    }

    if (inputKey.Key == ConsoleKey.I)
    {
        personAccount.InputData();
    }

    if (inputKey.Key == ConsoleKey.D)
    {
        personAccount.DisplayData();
    }

    if (inputKey.Key == ConsoleKey.S)
    {
        personAccount.sortBySalary();
        Console.WriteLine("依照月薪排序完成");
    }

    if (inputKey.Key == ConsoleKey.M)
    {
        personAccount.MockData();
    }
} while (true);


internal sealed class CPersonData
{
    public string name { get; set; }
    public string degree { get; set; }
    private string p_id { get; set; }
    private int salary { get; set; }

    internal int GetSalary()
    {
        return salary;
    }

    public CPersonData()
    {
        name = "~~~~~~~";
        degree = "~~~~~~~";
        p_id = "~~~~~~~";
        salary = 0;
    }

    public CPersonData(string name, string degree, string p_id, int salary)
    {
        this.name = name;
        this.degree = degree;
        this.p_id = p_id;
        this.salary = salary;
    }
}

internal class CPersonAccount
{
    private IList<CPersonData> _personList;

    public CPersonAccount()
    {
        _personList = new List<CPersonData>();
    }

    public void MockData()
    {
        _personList.Add(new CPersonData("胡金龍", "2Base", "A123456789", 80000));
        _personList.Add(new CPersonData("潘威倫", "Pitcher", "B123456789", 350000));
        _personList.Add(new CPersonData("郭泓志", "Pitcher", "C123456789", 1600000));
        _personList.Add(new CPersonData("王建名", "Pitcher", "D123456789", 1200000));
    }

    public void InputData()
    {
        Console.WriteLine("請輸入姓名:");
        var name = Console.ReadLine();
        Console.WriteLine("請輸入身分證字號:");
        var p_id = Console.ReadLine();
        Console.WriteLine("請輸入職別:");
        var degree = Console.ReadLine();
        Console.WriteLine("請輸入月薪資:");
        var salary = int.Parse(Console.ReadLine() ?? string.Empty);

        var person = new CPersonData(name, degree, p_id, salary);
        _personList.Add(person);
    }

    public void DisplayData()
    {
        var consoleTable = new ConsoleTable("姓名", "職別", "月薪資");
        foreach (var person in _personList)
        {
            consoleTable.AddRow(person.name, person.degree, person.GetSalary());
        }

        consoleTable.Write();
    }

    public void sortBySalary()
    {
        _personList = _personList.OrderBy(x => x.GetSalary()).ToArray();
    }
}
原本的作業範例是用 Java
所以命名規範也是Java的樣子
如果有需要可以參考官方調整命名規範
```
