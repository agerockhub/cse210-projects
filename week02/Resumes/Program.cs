using System;
using System.ComponentModel.DataAnnotations;

public class Job
{
    public string _company;
    public string _jobTitle;
    public string _startYear;
    public string _endYear;
    public void Display()
    {
        Console.WriteLine($"Name: {_company}");
        Console.WriteLine($"Jobs:{_jobTitle}");
        Console.WriteLine($"Jobs:{_startYear}");
        Console.WriteLine($"Jobs:{_endYear}");

    }

}