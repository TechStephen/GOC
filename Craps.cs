using System;

namespace GOC
{
    class Craps
    {
        static int dice1 = 0;
        static int dice2 = 0;
        static Random rand = new Random();
        static int point = 0;
        static int total = 0;
        static int chips = 100;
        static int bet = 0;
        static string response = "";

        // main 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Craps! You have " + chips + " chips! do you want to play? y or n?");
            response = Console.ReadLine();
            while(response == "y")
            {
                checkChips(chips);
                Console.WriteLine("do you want to continue? y or n?");
                response = Console.ReadLine();
                if(response == "n")
                {
                    break;
                }
                play();
            }
            Console.WriteLine("Exited. Chips are " + chips + ".");
        }

        //play
        static void play()
        {
            // takes in bet from user
            Console.WriteLine("How much would you like to bet? You have " + chips + " chips.");
            bet = Int32.Parse(Console.ReadLine());
            dice1 = rand.Next(1, 7);
            dice2 = rand.Next(1, 7);

            total = dice1 + dice2;

            // cases for win lose and point
            if(total == 7 || total == 11)
            {
                playerWin();
            }
            else if(total == 2 || total == 3 || total == 12)
            {
                playerLose();
            }
            else if (total == 4 || total == 5 || total == 6 || total == 8 || total == 9 || total == 10)
            {
                point = total;
                pointThrow(point);
            }

        }

        //player wins
        static void playerWin()
        {
            chips += bet * 2;
            Console.WriteLine("You win! You rolled a " + total + " Chips are now " + chips + " Game is over");
        }

        //player loses
        static void playerLose()
        {
            chips = chips - bet;
            Console.WriteLine("You lose! You rolled a " + total + " Chips are now " + chips + " Game is over");
        }

        // method for when points are rolled
        static void pointThrow(int point)
        {
            Console.WriteLine("You Rolled a Point! Point is " + point);
            while(true)
            {
                dice1 = rand.Next(1, 7);
                dice2 = rand.Next(1, 7);
                total = dice1 + dice2;

                if(total == point)
                {
                    playerWin();
                    break;
                }
                else if(total == 7)
                {
                    playerLose();
                    break;
                }

            }
        }

        // checks to see if chips are more than 0
        static void checkChips(int chips)
        {
            if(chips <= 0)
            {
                Console.WriteLine("You Lose! Out of Chips!");
            }
        }
    }
}
