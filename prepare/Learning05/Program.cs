using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> items= new List<Shape>();
        items.Add(new Square(2,"Blue"));
        items.Add(new Rectangle(8,4,"Red"));
        items.Add(new Circle(3,"Green"));
        foreach(Shape x in items){
            Console.WriteLine(x.GetColor());
            Console.WriteLine(x.GetArea());
        }
    }
}
public abstract class Shape{
    public string _color;
    public Shape(string color){
        _color=color;
    }
    public string GetColor(){
        return _color;
    }
    public void SetColor(string color){
        _color=color;
    }
    public abstract double GetArea();
}
public class Square: Shape{
    double _side;
    public Square(double side, string color): base(color){
        _side=side;
    }
    public override double GetArea(){
        return _side*_side;
    }   
}
public class Rectangle: Shape{
    double _side1;
    double _side2;
    public Rectangle(double side1, double side2, string color): base(color){
        _side1=side1;
        _side2=side2;
    }
    public override double GetArea(){
        return _side1*_side2;
    }   
}
public class Circle: Shape{
    double _radius;
    public Circle(double radius, string color): base(color){
        _radius=radius;
    }
    public override double GetArea(){
        return _radius*_radius*Math.PI;
    }   
}