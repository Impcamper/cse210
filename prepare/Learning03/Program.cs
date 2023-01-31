using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction test = new Fraction(4);
        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());
        Console.WriteLine("Enter the two numbers");
        int var1=int.Parse(Console.ReadLine());
        int var2=int.Parse(Console.ReadLine());
        Fraction test2 = new Fraction(var1,var2);
        Console.WriteLine(test2.GetFractionString());
        Console.WriteLine(test2.GetDecimalValue());
    }
}
public class Fraction{
    private int _top;
    private int _bottom;
    public Fraction(){
        _top=1;
        _bottom=1;
    }
    public Fraction(int wholeNumber){
        _top=wholeNumber;
        _bottom=1;
    }
    public Fraction(int top, int bottom){
        _top=top;
        _bottom=bottom;
    }
    public int GetTop(){
        return _top;
    }
    public void SetTop(int top){
        _top=top;
    }
    public int GetBottom(){
        return _bottom;
    }
    public void SetBottom(int bottom){
        _bottom=bottom;
    }
    public string GetFractionString(){
        return _top+"/"+_bottom;
    }
    public double GetDecimalValue(){
        return Convert.ToDouble(_top)/_bottom;
    }
}