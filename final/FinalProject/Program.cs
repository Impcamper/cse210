using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
    }
}

public class Player{
    protected int hp;
    int power;
    public void Attack(){

 }
}
public class Melee:Player{
    public void Defend(){

    }
}
public class Ranged:Player{
    public void Retreat(){
        
    }
}
public class Skill:Player{
    public void Recover(){
        
    }
}
public class Monster{
    int _counter;
    int _hp;
    int _attack;
    public Monster(){
        _counter=0;
    }
    public virtual void Attackloop(){

    }
}
public class TypeA: Monster{
    public override void Attackloop(){

    }
}
public class TypeB: Monster{
    public override void Attackloop(){

    }
}
public class TypeC: Monster{
    public override void Attackloop(){

    }
}