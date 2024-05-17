using System;
using System.Collections.Generic;
using System.Linq;
// 引入必要的命名空間

internal sealed class CPersonData
{
    public string name { get; set; } // 人員姓名
    public string degree { get; set; } // 人員職稱
    private string p_id { get; set; } // 人員身分證字號
    private int salary { get; set; } // 人員月薪資

    internal int GetSalary()
    {
        return salary; // 取得月薪資
    }

    public CPersonData()
    {
        // 預設建構函式，初始化屬性為虛擬值
        name = "~~~~~~~";
        degree = "~~~~~~~";
        p_id = "~~~~~~~";
        salary = 0;
    }

    public CPersonData(string name, string degree, string p_id, int salary)
    {
        // 建構函式，接受參數初始化屬性
        this.name = name;
        this.degree = degree;
        this.p_id = p_id;
        this.salary = salary;
    }
}

internal class CPersonAccount
{
    private IList<CPersonData> _personList; // 存儲人員資料的列表

    public CPersonAccount()
    {
        _personList = new List<CPersonData>(); // 初始化列表
    }

    public void MockData()
    {
        // 添加一些預設的人員資料
        _personList.Add(new CPersonData());
        _personList.Add(new CPersonData("胡金龍", "2Base", "A123456789", 80000));
        _personList.Add(new CPersonData("潘威倫", "Pitcher", "B123456789", 350000));
        _personList.Add(new CPersonData("郭泓志", "Pitcher", "C123456789", 1600000));
        _personList.Add(new CPersonData("王建民", "Pitcher", "D123456789", 1200000));
    }

    public void InputData()
    {
        // 提示使用者輸入人員資料並添加到列表中
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
        // 顯示人員資料列表
        Console.WriteLine("{0,-15}{1,-15}{2,-15}", "姓名", "職別", "月薪資");
        Console.WriteLine(new string('-', 45));
        foreach (var person in _personList)
        {
            Console.WriteLine("{0,-15}{1,-15}{2,-15}", person.name, person.degree, person.GetSalary());
        }
    }

    public void sortBySalary()
    {
        // 依月薪資排序人員資料列表
        _personList = _personList.OrderBy(x => x.GetSalary()).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var personAccount = new CPersonAccount(); // 建立人員資料管理物件

        do
        {
            Console.WriteLine("請選擇作業(i=輸入資料, s=依照月薪排序, d=顯示資料, q=結束, m=匯入基本資料):");
            var inputKey = Console.ReadKey(); // 讀取使用者輸入的選項
            Console.WriteLine();

            if (inputKey.Key == ConsoleKey.Q)
            {
                Console.WriteLine("結束程式");
                break; // 結束程式
            }

            if (inputKey.Key == ConsoleKey.I)
            {
                personAccount.InputData(); // 輸入人員資料
            }

            if (inputKey.Key == ConsoleKey.D)
            {
                personAccount.DisplayData(); // 顯示人員資料
            }

            if (inputKey.Key == ConsoleKey.S)
            {
                personAccount.sortBySalary(); // 依月薪資排序
                Console.WriteLine("依照月薪排序完成");
            }

            if (inputKey.Key == ConsoleKey.M)
            {
                personAccount.MockData(); // 匯入預設的人員資料
            }
        } while (true); // 無限迴圈，直到使用者選擇結束
    }
}