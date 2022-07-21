using System;

namespace Challenge_TicTacToe
{
    internal class Program
    {
        // THE Board

        static char[,] board = // why char and not string?
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
       

        static void Main(string[] args)
        {
            int player = 2; // WHY "2"? // player 1 starts
            int input = 0; // WHY "0"? isnt the nput gonna be whatever the player inputs??
            bool inputCorrect = true; //CHECKING IF THE INPUT IS CORRECT: FIELDS 1-9 NUMERICALLY, NOT OTHER CHARACTERS, NOT FIELDS SELECTED PREVIOUSLY          

            //run the code as long as the program runs:
            do
            {
                
                // WHILE the input is correct: DO: enforce switching between players
                if (player == 2)
                {
                    player = 1; // IF IT'S PLAYER'S 2 TURN THEN SWITCH TO PLAYER 1
                    // SWITCH THE INPUT A PLAYER INPUTS CORESPONDING TO THE BOARD FIELD INTO "X" OR "O"
                    EnterXorO(player, input); // i need to repeat names of arguments from the method below: "player, input"

                }
                else if (player == 1)
                {
                    player = 2; // IF IT'S PLAYER'S 1 TURN THEN SWITCH TO PLAYER 2
                    EnterXorO(player, input);
                }
                // SetBoard- here instead of above in Main so that the values switch into X or O with each player's input
                //SetBoard is after the if-else loop above that switches players: if it was above but still in the do-while loop
                //         it wouldn't update the board automatically after entering board value and enter but would need to input that 2x 
                //         and then would update. but then the second player entering their input(twice) would disregard their input
                //         value and change Player's 1 value he selected just before from X to Player's 2 "O"
                SetBoard();

                #region
                // CHECKING FOR THE WINNER
                char[] playerChars = { 'X', 'O' };

                foreach(char playerChar in playerChars) // ????how does it know playerChar is a single of PlayerChars????
                {
                    if (((board[0,0] == playerChar) && (board[0,1] == playerChar) && (board[0,2] == playerChar))
                            || ((board[1, 0] == playerChar) && (board[1, 1] == playerChar) && (board[1, 2] == playerChar))
                            || ((board[2, 0] == playerChar) && (board[2, 1] == playerChar) && (board[2, 2] == playerChar))
                            || ((board[0, 0] == playerChar) && (board[1, 0] == playerChar) && (board[2, 0] == playerChar))
                            || ((board[0, 1] == playerChar) && (board[1, 1] == playerChar) && (board[2, 1] == playerChar))
                            || ((board[0, 2] == playerChar) && (board[1, 2] == playerChar) && (board[2, 2] == playerChar))
                            || ((board[0, 0] == playerChar) && (board[1, 1] == playerChar) && (board[2, 2] == playerChar))
                            || ((board[0, 2] == playerChar) && (board[1, 1] == playerChar) && (board[2, 0] == playerChar))
                            )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won! Winner winner chicken dinner!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 has won! Winner winner chicken dinner!");
                        }
                        
                        
                        
                    }
                }


                #endregion

                #region // what does it do??
                // TESTING IF FIELD IS ALREADY TAKEN
                do
                {
                    Console.WriteLine($"Player {player}: write your chosen field number");

                    // TO AVOID program crashing if user inputs a non-digit input, eg a letter
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine()); // trying to convert input to Int
                    }
                    catch
                    {
                        Console.WriteLine("Please only input digits 1-9");
                    }
                    // TO AVOID program crashing if user inputs a non-digit input, eg a letter (PART2)
                    if ((input == 1) && (board[0, 0]) == '1') // isnt input ==1 and (board[0, 0]) == '1' redundant?
                        inputCorrect = true;
                    else if ((input == 2) && (board[0, 1]) == '2')
                        inputCorrect = true;
                    else if ((input == 3) && (board[0, 2]) == '3')
                        inputCorrect = true;
                    else if ((input == 4) && (board[1, 0]) == '4')
                        inputCorrect = true;
                    else if ((input == 5) && (board[1, 1]) == '5')
                        inputCorrect = true;
                    else if ((input == 6) && (board[1, 2]) == '6')
                        inputCorrect = true;
                    else if ((input == 7) && (board[2, 0]) == '7')
                        inputCorrect = true;
                    else if ((input == 8) && (board[2, 1]) == '8')
                        inputCorrect = true;
                    else if ((input == 9) && (board[2, 2]) == '9')
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect input, please use another field");
                        inputCorrect = false;
                    }
                }
                while (!inputCorrect); // WHILE the input is incorrect RUN AGAIN
                #endregion

            } while (true);

            
        }

        public static void SetBoard()
        {
            Console.Clear(); // - so that the values switch into X or O with each player's input (aside from moving the SetBoard method from Main to do-while loop in Main)
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0,0], board[0, 1], board[0, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
        }

        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
                playerSign = 'X';
            else if (player == 2)
                playerSign = 'O';

            switch (input)
            {
                case 1: board[0, 0] = playerSign; break; //after replacing board value with 'X' don't run the rest of the code
                case 2: board[0, 1] = playerSign; break;
                case 3: board[0, 2] = playerSign; break;
                case 4: board[1, 0] = playerSign; break;
                case 5: board[1, 1] = playerSign; break;
                case 6: board[1, 2] = playerSign; break;
                case 7: board[2, 0] = playerSign; break;
                case 8: board[2, 1] = playerSign; break;
                case 9: board[2, 2] = playerSign; break;
            }
            // WHY NO break; HERE??
        } 
    }
}
