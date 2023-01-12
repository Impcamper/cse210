using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter list of numbers. Enter 0 when finished");
        List<int> numbers = new List<int>();
        int x=9999;
        int temp=0;
        while(x!=0){
            Console.Write("Enter number");
            x = int.Parse(Console.ReadLine());
            numbers.Add(x);
        }
        foreach(int num in numbers){
            temp=temp+num;
        }
        Console.WriteLine("The sum is "+temp);
        temp=0;
        foreach(int num in numbers){
            temp=temp+num;
        }
        temp=temp/numbers.Count;
        Console.WriteLine("The avrage is "+temp);
        temp=0;
        foreach(int num in numbers){
            if (num>temp){
                temp=num;
            }
        }
        Console.WriteLine("The largest number is "+temp);
    }
}