using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Name");
        string name=Console.ReadLine();
        Console.WriteLine("topic");
        string topic=Console.ReadLine();
        Console.WriteLine("Section");
        string section=Console.ReadLine();
        Console.WriteLine("Proboms");
        string probloms=Console.ReadLine();
        MathAssignent test1 = new MathAssignent(name,topic,section,probloms);
        Console.WriteLine("summary");
        Console.WriteLine(test1.GetSummary());
        Console.WriteLine("list");
        Console.WriteLine(test1.GetHomeworkList());

    }
}
public class Assignment{
    string _studentName;
    string _topic;
    public Assignment(string name, string topic){
        _studentName=name;
        _topic=topic;
    }
    public string GetSummary(){
        return _studentName+" - "+_topic;
    }
}
public class MathAssignent : Assignment{
    string _textbookSection;
    string _problems;
    public MathAssignent(string name, string topic, string book, string probloms) :base(name,topic){
        _textbookSection=book;
        _problems=probloms;
    }
    public string GetHomeworkList(){
        return GetSummary()+"\nSection "+_textbookSection+" Problems "+_problems;
    }
}
public class WrittingAssignent : Assignment{
    string _title;
    public WrittingAssignent(string name, string topic, string title) : base(name, topic){
        _title=title;
    }
    public string GetWritingInformation(){
        return GetSummary()+"\n"+_title;
    }
}