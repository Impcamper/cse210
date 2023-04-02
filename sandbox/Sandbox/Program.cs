using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        Thing test = new Thing();
        var hello = test.Write;
        hello();
    }
}
public class Thing{
    public void Write(){
        Console.WriteLine("Test sucesse");
    }
}