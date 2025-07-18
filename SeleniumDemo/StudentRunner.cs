using System;
using System.Collections.Generic;

namespace StudentDemo
{
    public class StudentRunner
    {
        public static void Main(string[] args)
        {
            Student objStud1 = new Student(1001, "Jack", "jack@gmail.com", 45.2f);
            Student objStud2 = new Student(1002, "Peter", "peter@gmail.com", 85.2f);
            Student objStud3 = new Student(1003, "Mark", "mark@gmail.com", 56.5f);

            List<Student> listStudents = new List<Student>();
            listStudents.Add(objStud1);
            listStudents.Add(objStud2);
            listStudents.Add(objStud3);

            System.Console.WriteLine("Student Details Printing Started");
            Console.WriteLine("===============================");
            StudentRunner objStudRun = new StudentRunner();
            objStudRun.printStudDetails(listStudents);
            Console.WriteLine("===============================");
            System.Console.WriteLine("Student Details Printing Completed");
        }

        //Print the details of Student in Console
        public void printStudDetails(List<Student> listStudents)
        {
            int studCounter = 0;

            try
            {
                foreach (Student objStud in listStudents)
                {
                    studCounter++;
                    Console.WriteLine($"Details of Student No : {studCounter}");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Student Roll No : " + objStud.StudentRollNo.ToString());
                    Console.WriteLine("Student Name : " + objStud.StudentName);
                    Console.WriteLine("Student Email ID : " + objStud.StudentMailId);
                    Console.WriteLine("School Name : " + Student.SchoolName);
                    Console.WriteLine("School City : " + Student.SchoolAddress);
                    Console.WriteLine("-------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in printing the Student : " + studCounter.ToString() + " with error message: " + e.Message);
            }
        }
    }
}