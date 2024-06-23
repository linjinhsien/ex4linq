using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal sealed class CPersonData
{
    public string Name { get; set; }
    public string Degree { get; set; }
    private string PId { get; set; }
    private int Salary { get; set; }
    #region constructor
    // 預設建構函式
    public CPersonData()
    {
        Name = "~~~~~";
        Degree = "~~~~~";
        PId = "~~~~~";
        Salary = 0;
    }

    // 帶參數的建構函式
    public CPersonData(string name, string degree, string pId, int salary)
    {
        Name = name;
        Degree = degree;
        PId = pId;
        Salary = salary;
    }
    #endregion
    internal int GetSalary()
    {
        return Salary;
    }

    // 將人員資料轉換為CSV格式的字串
    public string ToCsvString()
    {
        return $"{Name},{Degree},{PId},{Salary}";
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
        // 使用預設建構函式創建一個新的CPersonData實例
        _personList.Add(new CPersonData());
        // 使用帶參數的建構函式添加模擬資料
        _personList.Add(new CPersonData("胡金龍", "2Base", "A123456789", 80000));
        _personList.Add(new CPersonData("潘威倫", "Pitcher", "B123456789", 350000));
        _personList.Add(new CPersonData("郭泓志", "Pitcher", "C123456789", 1600000));
        _personList.Add(new CPersonData("王建民", "Pitcher", "D123456789", 1200000));
    }

    // 將人員列表轉換為CSV格式的字串
    public string ToCsvContent()
    {
        var csvContent = new StringBuilder();
        csvContent.AppendLine("姓名,職別,身分證字號,月薪資");
        foreach (var person in _personList)
        {
            csvContent.AppendLine(person.ToCsvString());
        }
        return csvContent.ToString();
    }
}

class Program
{
    static void Main()
    {
        var personAccount = new CPersonAccount();
        personAccount.MockData(); // 匯入模擬資料

        var csvContent = personAccount.ToCsvContent(); // 轉換為CSV格式的字串
        File.WriteAllText(@"C:\Data\PersonData.csv", csvContent, Encoding.UTF8); // 寫入檔案

        Console.WriteLine("模擬資料已寫入CSV檔案。");
        Console.WriteLine("按Enter鍵結束。");
        Console.ReadLine();
    }
}
