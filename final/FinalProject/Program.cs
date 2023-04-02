using System;

class Program
{
    static void Main(string[] args)
    {
        Monster B = new Monster(1,1);
        int choice=0;
        string special="Why does code skip my do while when checking?";
        Player A = new Player(1,1,B);
        Console.WriteLine("Enter how much health the monster should have: ");
        int health=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter how much damge the monster should do: ");
        int damge=int.Parse(Console.ReadLine());

        //monster type
        while (choice!=1&choice!=2&choice!=3){
            Console.WriteLine("Monster type: 1- charge, 2-consent, 3-Defender");
            choice=int.Parse(Console.ReadLine());
            if(choice==1){
                B = new TypeA(health,damge);
                }
            else if(choice==2){
                B = new TypeB(health,damge);
                }
            else if(choice==3){
                B = new TypeC(health,damge);
                }
        }
        choice=0;

        Console.WriteLine("Enter how much health the player should have: ");
        health=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter how much health the player should do: ");
        damge=int.Parse(Console.ReadLine());
        //player type
        while (choice!=1&choice!=2&choice!=3){
            Console.WriteLine("Player type: 1- defense, 2-ranged, 3-skill");
            choice=int.Parse(Console.ReadLine());
            if(choice==1){
                A = new Melee(health,damge,B);
                special="Defend";
                }
            else if(choice==2){
                A = new Ranged(health,damge,B);
                special="Retreat";
                }
            else if(choice==3){
                A = new Skill(health,damge,B);
                special="Counter";
                }
        }
    
        choice=-1;
        while(choice!=0){
            Console.WriteLine($"Action: 1-attack, 2-{special}, 0-end");
            if(choice==1){A.Attack();}
            if(choice==2){A.Special();}
            //find way to end if someone died.
            choice=int.Parse(Console.ReadLine());
        }
    }
}

public class Player{
    int _hp;
    protected int _attack;
    protected Monster _enemy;
    public Player(int hp, int attck, Monster thing){
        _hp=hp;
        _attack=attck;
        _enemy=thing;
    }
    public virtual void Attack(){
        Random r = new Random();
        _enemy.Damage(r.Next(_attack-1, _attack+1));
        Damage(_enemy.Attackloop());
    }
    public virtual void Special(){

    }
    public void Damage(int dmg){
        //
        if(dmg<0){dmg=0;}
        _hp=_hp-dmg;
        
        if(_hp<=0){
            Console.WriteLine("You are dead");
        }
        else{
            Console.WriteLine($"You took {dmg} damge, {_hp} left");
        }
    }
}
public class Melee:Player{
    int _defense;
    public override void Attack(){
        Random r = new Random();
        _enemy.Damage(r.Next(_attack-1, _attack+1));
        Damage(_enemy.Attackloop()-_defense);
        if(_defense>0){_defense=_defense-1;}
    }
    public Melee(int hp, int attck,Monster thing):base(hp,attck,thing){

    }
    public override void Special(){
        //block damge over turns?
        _defense=3;
        Damage(_enemy.Attackloop()-_defense);
        if(_defense>0){_defense=_defense-1;}
        Console.WriteLine("defended");
    }
}
public class Ranged:Player{
    public Ranged(int hp, int attck,Monster thing):base(hp,attck,thing){

    }
    public override void Special(){
        //avoid damge
        Console.WriteLine("You avoid "+_enemy.Attackloop()+"damge");
    }
}
public class Skill:Player{
    public Skill(int hp, int attck,Monster thing):base(hp,attck,thing){

    }
    public override void Special(){
        int dmg=_enemy.Attackloop();
        Damage(dmg);
        dmg=Convert.ToInt32(Convert.ToDouble(dmg)*.8);
        _enemy.Damage(dmg);
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
            
            Random r = new Random();
            return r.Next(_attack-1, _attack+1);
        }
        else{
            _counter=0;
            return 0;
        }
    }
    public virtual void Damage(int dmg){
        if(dmg<0){dmg=0;}
        _hp=_hp-dmg;
        if(_hp<=0){
            Console.WriteLine("Monster is dead");
            if(_hp<0){
                Console.WriteLine($"{-_hp} points of overkill");
            }
        }
        else{
            Console.WriteLine($"The enemy takes {dmg} damge");
        }
    }
}
public class TypeA: Monster{
    public TypeA(int hp, int attack): base(hp,attack){

    }
    public override int Attackloop(){
        //charge and attck
        Random r = new Random();
        if (_counter==0){
            _counter++;
            
            return r.Next(_attack-1, _attack+1);
        }
        if (_counter==1){
            _counter++;
            Console.WriteLine("The monster is charging up!");
            return 0;
        }
        else{
            
            _counter=0;
            return (r.Next(_attack-1, _attack+1))*3;
        }
    }
}
public class TypeB: Monster{
    public TypeB(int hp, int attack): base(hp,attack){

    }
    public override int Attackloop(){
        //edit
        Random r = new Random();
        return r.Next(_attack-1, _attack+1);
    }
}
public class TypeC: Monster{
    int _defense=0;
    public TypeC(int hp, int attack): base(hp,attack){

    }
    public override int Attackloop(){
        //edit
        Random r = new Random();
        if (_counter==0){
            _counter++;
            
            return r.Next(_attack-1, _attack+1);
        }
        if (_counter==1){
            _counter++;
            
            return (r.Next(_attack-1, _attack+1));
        }
        else{
            
            _counter=0;
            _defense=3;
            return 0;
        }
    }
    public override void Damage(int dmg){
        dmg=dmg-_defense;
        if(_defense>0){_defense=_defense-1;}
        if(dmg<0){dmg=0;}
        _hp=_hp-dmg;
        if(_hp<=0){
            Console.WriteLine("Monster is dead");
            if(_hp<0){
                Console.WriteLine($"{-_hp} points of overkill");
            }
        }
        else{
            Console.WriteLine($"The enemy takes {dmg} damge");
        }
    }
}