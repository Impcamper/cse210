using System;

class Program
{
    static void Main(string[] args)
    {   
        int option;
        do{
        Console.Clear();
        Console.WriteLine("Menu options:\n 1. Start breathing activity\n 2. Start reflecting activity\n 3. Start listing activity\n 4. Quit");
        Console.WriteLine("Select an option: ");
        option=int.Parse(Console.ReadLine());
        if(option==1){Breathing current=new Breathing();
        current.Breath();}
        else if(option==2){Reflection current=new Reflection();
        current.Reflect();}
        else if(option==3){Listing current=new Listing();
        current.Counter();}
        }while(option!=4);
    }
}
public class Activity{
    string _name;
    string _discription;
    int _time;
    protected List<string> _prompts;
    public Activity(string name,string dis){
        _name=name;
        _discription=dis;
    }
    protected void Start(){
        Console.WriteLine(_name);
        Console.WriteLine(_discription);
        Console.Write("Enter time in seconds to do the activity:  ");
        _time=int.Parse(Console.ReadLine());
    }
    protected void End(){
        Console.WriteLine($"Good Job! You have done another {_time} of {_name!}");
        Waiter();
    }
    public int GetTimer(){
        return _time;
    }
    public void Waiter(){
        for(int x=5;x>0;x--){
            Console.Write("/----");
            Thread.Sleep(400);
            Console.Write("\b\b\b\b\b\b");
            Console.Write("-/---");
            Thread.Sleep(400);
            Console.Write("\b\b\b\b\b\b");
            Console.Write("--/--");
            Thread.Sleep(400);
            Console.Write("\b\b\b\b\b\b");
            Console.Write("---/-");
            Thread.Sleep(400);
            Console.Write("\b\b\b\b\b\b");
            Console.Write("----/");
            Thread.Sleep(400);
            Console.Write("\b\b\b\b\b\b");
        }
    }

}
public class Breathing : Activity{
    public Breathing() : base("Breathing","Relax using deep breathing exersises."){
    }
    public void Breath(){
        //prep
        Start();
        Console.WriteLine("Please prepare");
        Waiter();
        int time=GetTimer();
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(time);
        Console.Clear();
        while(now<end){
            Console.WriteLine("\nBreath in ");
            Console.Write("5");
            Thread.Sleep(1000);
            Console.Write("\b\b4");
            Thread.Sleep(1000);
            Console.Write("\b\b3");
            Thread.Sleep(1000);
            Console.Write("\b\b2");
            Thread.Sleep(1000);
            Console.Write("\b\b1");
            Thread.Sleep(1000);
            Console.WriteLine("\nBreath out");
            Console.Write("5");
            Thread.Sleep(1000);
            Console.Write("\b\b4");
            Thread.Sleep(1000);
            Console.Write("\b\b3");
            Thread.Sleep(1000);
            Console.Write("\b\b2");
            Thread.Sleep(1000);
            Console.Write("\b\b1");
            Thread.Sleep(1000);
            now = DateTime.Now;
        }
        End();
    }
}
public class Reflection : Activity{
    public Reflection() : base("Reflection","Reflect on past exsperinces where you showed strength."){
        _prompts = new List<string>(){"How did you feel?","What was your favorite part of the experience?","Do you wish you could do it again?","What did you learn from this experience?","What could you apply from this experience in other situations?","Have you ever done somthing similar before?"};
    }
    public void Reflect(){
        Start();
        Console.WriteLine("Please prepare");
        Waiter();
        int time=GetTimer();
        Random ran = new Random();
        List<string> starter = new List<string>(){"Think of a time when you stood up for someone else.","Think of a time when you did something really difficult.","Think of a time when you helped someone in need.","Think of a time when you realy pushed yourself."};
        Console.Clear();
        Console.WriteLine(starter[ran.Next(starter.Count-1)]);
        Console.WriteLine("Press enter when ready");
        Console.ReadLine();
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(time);
        while(now<end){
            Console.WriteLine(_prompts[ran.Next(_prompts.Count-1)]);
            Waiter();
            now = DateTime.Now;
        }
        End();
    }
}
public class Listing : Activity{
    public Listing() : base("Listing","See the good in life by creating a list based on a prompt."){
        _prompts = new List<string>(){"What are your strangths?","Who do you look up to?","When have you felt the holy ghost recently?","What have you enjoyed this week?"};
    }
    public void Counter(){
        Start();
        Console.WriteLine("Please prepare");
        Waiter();
        int counter=0;
        int time=GetTimer();
        Random ran = new Random();
        Console.Clear();
        Console.WriteLine(_prompts[ran.Next(_prompts.Count-1)]);
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(time);
        while(now<end){
            Console.ReadLine();
            counter++;
            now = DateTime.Now;
        }
        Console.WriteLine($"You listed {counter} items!");
        End();
    }
}