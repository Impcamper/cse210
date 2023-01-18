using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume1 = new Resume();
        Job job1 = new Job();
        job1._company="Amaxon";
        job1._JobTitle="Slave labor";
        job1.DisplayJobInfo();
        Job job2 = new Job();
        job2._company="Appel";
        job2._JobTitle="Anti-repair Enginer";
        job2.DisplayJobInfo();
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1._jobs[0].DisplayJobInfo();
        resume1._name="Jim Terry";
        resume1.DisplayResume();
    }
    
}
public class Resume{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();
    public Resume(){
    }
    public void DisplayResume(){
        Console.WriteLine(_name);
        Console.Write("Jobs:");
        foreach(Job x in _jobs){
            x.DisplayJobInfo(); 
        }
    }
    
}
public class Job{
    public string _company ="";
    public string _JobTitle ="";
    public int _StartYear;
    public int _EndYear;


    public Job(){

    }

    public void DisplayJobInfo(){
        Console.WriteLine("Company: "+_company+" Job: "+_JobTitle);
        Console.WriteLine("Start Year: "+_StartYear+" End Year: "+_EndYear);
    }
}