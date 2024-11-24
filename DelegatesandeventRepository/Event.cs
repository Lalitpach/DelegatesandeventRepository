using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public delegate void DisplayMessage();

namespace DelegatesandeventRepository

    public class Student
{

    public event DisplayMessage Pass;
    public event DisplayMessage Fail;
    public void AcceptMarks(int marks)
    {
        if (marks >= 40)
        {
            Pass?.Invoke();
            else
            {
                Fail?.Invoke();
            }
        }

    public class Program
    {
        static void PassMsg()
        {
            Console.WriteLine("Congratulations! You passed with a good score.");
        }

        static void FailMsg()
        {
            Console.WriteLine("Oops! You failed.");
        }

        static void Main(string[] args)
        {
            Student stud = new Student();

            // Bind the events to the delegate methods
            stud.Pass += PassMsg;
            stud.Fail += FailMsg;

            // Test by calling AcceptMarks
            stud.AcceptMarks(30); // Test with a failing score
        }
    }
}
}
