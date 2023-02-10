using System;

class Program
{
    static void Main(string[] args)
    {
        //everything here to do
        Console.WriteLine("Enter name of scripture chapter file:");
        string link=Console.ReadLine();
        Fetch scrip = new Fetch(link);
        Scriptures main = new Scriptures(scrip.fetch());
        Console.WriteLine("Enter the verse like example: Phobe 1:5");
        link=Console.ReadLine();
        main.GetScripture(link);
    }
}
public class Scriptures{
    Dictionary<string,string> _scriptures = new Dictionary<string,string>();
    public Scriptures(Dictionary<string,string> temp){
        _scriptures=temp;
    }
    public void GetScripture(string id){
        List<string> temp = new List<string>();
        temp = convert(_scriptures[id]);
        Memorize mem = new Memorize(temp,id);
        mem.Remove();
    }
    /*public void GetMultiScripture(string id1, string id2){
            Just not doing this, could but it would take a bunch of extra time and i am already doing extra
        Memorize mem = new Memorize(,);
        mem.Remove();
    }*/
    public List<string> convert(string item){
        //70% sure that i should just feed string[] but ehhhhh
        string[] words = item.Split(' ');
        List<string> temp = new List<string>();
        temp.AddRange(words);
        return temp;
    }
}
public class Memorize{
    string _id;
    List<string> _holder;
    List<int> _holderTemp= new List<int>();
    public Memorize(List<string> scripture,string id){
        _holder=scripture;
        _id=id;
    }
    public void Remove(){
        //menu stuff
        string menu="";
        while(menu!="quit" && _holderTemp.Count!=_holder.Count+1){
            Console.Clear();
            Console.Write(_id+": ");
            foreach (string x in _holder)
            {
                Console.Write(x+" ");
            }
            menu=Console.ReadLine();
            ListMesser();
        }
    }
    void ListMesser(){
        //editing arrays for random
        var choser = new Random();
        int item;
        //thing here to make sure it doesn't dupe
        do{
            item =choser.Next(0, _holder.Count);
        } while (_holderTemp.FirstOrDefault(i=>i==item)-1!=-1);
        //thing here to replace the element in main array
        _holderTemp.Add(item);
        string temp="";
        for (int i = 0; i < _holder[item].Length; i++)
        {
            temp+="_";
        }
        _holder[item]=temp;
    }
}
public class Fetch{
    string _file;
    public Fetch(string temp){
        _file=temp;
    }
    public Dictionary<string,string> fetch(){
        //scirptures
        String[] lines = System.IO.File.ReadAllLines(_file);
        int num=0;
        string part="";
        Dictionary<string,string> temp = new Dictionary<string,string>();
        foreach(string current in lines){
            if(num%2==0){
                part=current;
            }
            else{
                temp.Add(part,current);
            }
            num++;
        }
        return temp;
    }
}