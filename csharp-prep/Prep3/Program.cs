using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        int guess = 0;
        while (guess !=number){
            Console.WriteLine("Guess a number");
            guess = int.Parse(Console.ReadLine());
            if(guess>number){
                Console.WriteLine("Too high.");
            }
            else if(guess<number){
                Console.WriteLine("Too low.");
            }
            else{
                Console.WriteLine("Correct!");
            }
        }
    }
}