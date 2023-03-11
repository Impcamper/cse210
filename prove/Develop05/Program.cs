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
            Console.WriteLine("  1. Create new Goal\n  2. List Goals\n  3. Save\n  4. Load\n  5. Record activity\n  6. Player Info\n  7. Quit");
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
    public virtual void Record(Experience bar){
        _times++;
    }
    public virtual string GetInfo(){
        return _Goal+","+_Actions+","+_times;
    }
}
public class Simple :Goal{
    //need to check if compleated somehow

    public Simple(string goal, string action):base(goal,action){
        
    }
    public Simple(string goal, string action,int times):base(goal,action){
        _times=times;
    }
    public override void DispayGoal()
    {
        Console.Write($"{_Goal} ({_Actions})");
        if(_times<1){Console.WriteLine(", Incomplete");}
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
    public override string GetInfo(){
        return "Simple,"+_Goal+","+_Actions+","+_times;
    }
}
public class Eternal :Goal{
    
    public Eternal(string goal, string action):base(goal,action){
        
    }
    public Eternal(string goal, string action, int times):base(goal,action){
        _times=times;
    }
    public override void DispayGoal()
    {
        Console.WriteLine($"{_Goal} ({_Actions}), done {_times} times");
    }
    public override void Record(Experience bar){
        _times++;
        bar.AddXP(20);
    }
    public override string GetInfo(){
        return "Endless,"+_Goal+","+_Actions+","+_times;
    }
}
public class Checklist :Goal{

    int _total;
    public Checklist(string goal, string action, int total):base(goal,action){
        _total=total;
    }
    public Checklist(string goal, string action, int total, int times):base(goal,action){
        _total=total;
        _times=times;
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
    public override string GetInfo(){
        return "Checklist,"+_Goal+","+_Actions+","+_times+","+_total;
    }
}
public class Experience{
        int _xpbar=0;
    public int AddXP(int xp){

        int newxp=_xpbar+xp;
        if(Convert.ToInt32(Math.Floor(Convert.ToDouble(newxp)/100))>Convert.ToInt32(Math.Floor(Convert.ToDouble(_xpbar)/100))){
            Levelup();
        }
        _xpbar=newxp;
        return Convert.ToInt32(Math.Floor(Convert.ToDouble(_xpbar)/100));
    }
    public void Levelup(){
        Console.WriteLine("Congrates! You have leveled up!");
    }
    public string GetXp(){
        return _xpbar.ToString();
    }
    public void Set(int xp){
        _xpbar=xp;
    }
}
public class Player{
    List<Goal> _goals= new List<Goal>();
    Experience xp= new Experience();
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
        Console.WriteLine("Give a discription for the goal: ");
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
        Console.WriteLine("Give file name to load from: ");
        string name=Console.ReadLine();
        string[] lines=System.IO.File.ReadAllLines(name);
        foreach(string data in lines){
            string[] parts = data.Split(",");
            if(parts[0]=="Simple"){
                _goals.Add(new Simple(parts[1],parts[2],int.Parse(parts[3])));
            }
            else if(parts[0]=="Endless"){
                _goals.Add(new Eternal(parts[1],parts[2],int.Parse(parts[3])));
            }
            else if(parts[0]=="Checklist"){
                _goals.Add(new Checklist(parts[1],parts[2],int.Parse(parts[3]),int.Parse(parts[4])));
            }
            else{
                _username=parts[0];
                xp.Set(int.Parse(parts[1]));
            }
        }
    }
    public void Save(){
        //Saves goals and player data into a file
        Console.WriteLine("Give file name to save to: ");
        string name=Console.ReadLine();
        using (StreamWriter file = new StreamWriter(name)){

            file.WriteLine($"{_username},{xp.GetXp()}");
            foreach (Goal x in _goals){
                file.WriteLine(x.GetInfo());
            }
        }
    }
}