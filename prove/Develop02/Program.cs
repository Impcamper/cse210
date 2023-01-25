using System;

class Program
{
    static void Main(string[] args)
    {
        Journal Journal1 = new Journal();
        string file;
        int menue=0;
        while( menue !=5){
            Console.WriteLine("1 - Write new Entry");
            Console.WriteLine("2 - Display entries");
            Console.WriteLine("3 - Save to file");
            Console.WriteLine("4 - Load from file");
            Console.WriteLine("5 - Exit");
            menue = int.Parse(Console.ReadLine());
            if (menue==1){Journal1.addEntry();}
            else if(menue==2){Journal1.display();}
            else if(menue==3){
                Console.WriteLine("Enter file name");
                file=Console.ReadLine();
                Journal1.save(file);
            }
            else if(menue==4){
                Console.WriteLine("Enter file name");
                file=Console.ReadLine();
                Journal1.load(file);
            }
        }
    }
}
public class Journal{
    List<Entry> _entries = new List<Entry>();
    public Journal(){}
    public void addEntry(){
        Entry thing = new Entry();
        thing.enterEntry();
        _entries.Add(thing);
    }
    public void load(string filename){
        String[] lines = System.IO.File.ReadAllLines(filename);
        foreach(string x in lines){
            Entry thing = new Entry();
            thing.loadfile(x);
            _entries.Add(thing);
        }
    }
    public void save(string filename){
        using (StreamWriter writter = new StreamWriter(filename)){
            foreach(Entry x in _entries){
                writter.WriteLine(x.asString());
            }
        }
    }
    public void display(){
        foreach(Entry x in _entries){
            x.displayEntry();
        }
    }
}
public class Entry{
    string _entry;
    string[] _prompts= {"How was your day?\n","Is there anything you wish you did today?\n","What was the best part of your day?\n","Is there anything you regret today?\n","What was the worst part of your day?\n"};
    public Entry(){}
    public void enterEntry(){
        var number = new Random();
        _entry = _prompts[number.Next(1,5)];
        Console.Write(_entry);
        _entry= _entry+Console.ReadLine();
        DateTime time = DateTime.Now;
        string shorttime = time.ToShortDateString();
        _entry= "("+shorttime+")"+_entry;

    }
    public void loadfile(string input){
        _entry=input;
    }
    public string asString(){
        return _entry;
    }
    public void displayEntry(){
        Console.WriteLine(_entry);
    }
}