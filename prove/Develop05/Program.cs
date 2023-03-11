using System;

class Program
{
    static void Main(string[] args)
    {
        Player user;

        Console.WriteLine("Are you a returning user? Y or N");
        string input=Console.ReadLine();
        if(input.ToUpper()=="Y"){
            user=new Player();
        }
        else{
            Console.WriteLine("Please enter a Username");
            input=Console.ReadLine();
            user=new Player(input);
        }
        int choice=0;
        while (choice!=7){
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create new Goal\n  2. List Goals\n  3. Save\n  4. Load\n  5.Record activity\n 6. Player Info\n 7. Quit");
            Console.Write("Select a Choice: ");
            choice=int.Parse(Console.ReadLine());
            Console.WriteLine();
            if(choice==1){user.NewGoal();}
            else if(choice==2){user.ListGoals();}
            else if(choice==3){user.Save();}
            else if(choice==4){user.Load();}
            else if(choice==5){user.update();}
            else if(choice==6){user.PlayerInfo();}
        }
    }
}
public class Goal{
    //do i make them list or single string?
    protected string _Goal;
    protected string _Actions;
    protected int _times=0;
    public Goal(string goal, string action){
        _Goal=goal;
        _Actions=action;
    }
    public virtual void DispayGoal(){
        Console.WriteLine("You should never see this line.");
    }
    public void SetGoal(string goal, string action, int times){
        _Goal=goal;
        _Actions=action;
        _times=times;
    }
    public virtual void Record(Experience bar){
        _times++;
    }
}
public class Simple :Goal{
    //need to check if compleated somehow

    public Simple(string goal, string action):base(goal,action){

    }
    public override void DispayGoal()
    {
        Console.Write($"{_Goal} ({_Actions})");
        if(_times>=1){Console.WriteLine(", Incomplete");}
        else{Console.WriteLine(", Complete!");}
    }
    public override void Record(Experience bar){
        if(_times>=1){
            Console.WriteLine("You have already done this task");
        }
        else{
            _times++;
            bar.AddXP(20);
        }
    }
}
public class Eternal :Goal{
    
    public Eternal(string goal, string action):base(goal,action){
        
    }
    public override void DispayGoal()
    {
        Console.WriteLine($"{_Goal} ({_Actions}), done {_times} times");
    }
    public override void Record(Experience bar){
        _times++;
        bar.AddXP(20);
    }
}
public class Checklist :Goal{

    int _total;
    public Checklist(string goal, string action, int total):base(goal,action){
        _total=total;
    }
    public override void DispayGoal()
    {
        Console.WriteLine($"{_Goal} ({_Actions}), {_times}/{_total}");
    }
    public override void Record(Experience bar){
        _times++;
        if(_times>=_total){
            bar.AddXP(20*_total);
            _times=0;
        }
        else{
            bar.AddXP(20);
        }
    }
    public void SetCheck(string goal, string action, int times, int total){
        _Goal=goal;
        _Actions=action;
        _times=times;
        _total=total;
    }
}
public class Experience{
        int _xpbar;
    public int AddXP(int xp){

        int newxp=_xpbar=+xp;
        if(newxp/100>_xpbar/100){
            Levelup();
        }
        _xpbar=newxp;
        return _xpbar/100;
    }
    public void Levelup(){
        Console.WriteLine("Congrates! you have leveled up!");
    }
}
public class Player{
    List<Goal> _goals;
    Experience xp;
    string _username;
    int _level=0;
    public Player(string name){
        _username=name;
        xp=new Experience();
    }
    public Player(){
        //if nothing is given, then its loading from file
        Load();
    }
    public void PlayerInfo(){
        _level=xp.AddXP(0);
        Console.WriteLine($"{_username}\n  level: {_level}");
    }
    public void ListGoals(){
        int num=1;
        foreach (Goal x in _goals){
            Console.Write($"{num}. ");
            x.DispayGoal();
        }
    }
    public void NewGoal(){
        Console.WriteLine("What type of goal are you making?");
        Console.WriteLine("  1. Simple goal: A goal that is one and done");
        Console.WriteLine("  2. Eternal goal: A goal that never ends");
        Console.WriteLine("  3. Checklist goal: A goal that has a number of times to be fully complete");
        Console.Write("Choice: ");
        int choice=int.Parse(Console.ReadLine());
        Console.WriteLine("Give a title for the goal: ");
        string goal=Console.ReadLine();
        string discription=Console.ReadLine();
        if(choice==1){_goals.Add(new Simple(goal,discription));}
        else if(choice==2){_goals.Add(new Eternal(goal,discription));}
        else if(choice==3){
            Console.WriteLine("Give how many times it you want to do it");
            int times=int.Parse(Console.ReadLine());
            _goals.Add(new Checklist(goal,discription, times));}
    }
    public void update(){
        ListGoals();
        Console.Write("Enter the number of the goal you wish you record progress in: ");
        int item=int.Parse(Console.ReadLine());
        _goals[item-1].Record(xp);
    }
    public void Load(){
        //would load the goals and player data into program
        //Might want to move this out?
        
    }
    public void Save(){
        //Saves goals and player data into a file
    }
}