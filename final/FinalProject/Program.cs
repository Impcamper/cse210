using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("testing that punching eachother works");
        Player A = new Player(5,2);
        Monster B = new Monster(8,1);
        //figure out a better way of doing this, perhaps feeding the monster to player?
        int choice=-1;
        while(choice!=0){
            Console.WriteLine("weee attackinggggg! enter 0 to end");
            B.Damage(A.Attack());
            A.Damage(B.Attackloop());
            choice=int.Parse(Console.ReadLine());
        }
    }
}

public class Player{
    int _hp;
    int _attack;
    public Player(int hp, int attck){
        _hp=hp;
        _attack=attck;
    }
    public int Attack(){
        //Make it random within 1 or two points of the value
        return _attack;
    }
    public void Damage(int dmg){
        _hp=-dmg;
        if(_hp>=0){
            Console.WriteLine("ded");
        }
    }
}
public class Melee:Player{
    public Melee(int hp, int attck):base(hp,attck){

    }
    public void Defend(){

    }
}
public class Ranged:Player{
    public Ranged(int hp, int attck):base(hp,attck){

    }
    public void Retreat(){
        
    }
}
public class Skill:Player{
    public Skill(int hp, int attck):base(hp,attck){

    }
    public void Recover(){
        
    }
}
public class Monster{
    protected int _counter;
    protected int _hp;
    protected int _attack;
    public Monster(int hp, int attack){
        _counter=0;
        _hp=hp;
        _attack=attack;
    }
    public virtual int Attackloop(){
        if (_counter==0){
            _counter++;
            //Make it random within 1 or two points of the value
            return _attack;
        }
        else{
            _counter=0;
            return 0;
        }
    }
    public void Damage(int dmg){
        _hp=-dmg;
        if(_hp>=0){
            Console.WriteLine("ded");
        }
    }
}
public class TypeA: Monster{
    public TypeA(int hp, int attack): base(hp,attack){

    }
    public override int Attackloop(){
        return _attack;
    }
}
public class TypeB: Monster{
    public TypeB(int hp, int attack): base(hp,attack){

    }
    public override int Attackloop(){
        return _attack;
    }
}
public class TypeC: Monster{
    public TypeC(int hp, int attack): base(hp,attack){

    }
    public override int Attackloop(){
        return _attack;
    }
}