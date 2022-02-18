using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
         public static Int32 x = 1; 
         public static Int32 y = 1;        
         public static  string dir; // Rover direction
         public static  string[] str_dir = { "N", "E", "S", "W" };
         public static Int32 row_max;
         public static Int32 col_max;

         static void Main(string[] args)
        {

            bool isValid = false;
            while (!isValid) // Check the input is valid or not
            {
                Console.WriteLine("Grid Size: ");
                string grid = Console.ReadLine();  // Input Grid Size            
                char[] spearator = { '*', ' ' };
                string[] str = grid.Split(spearator);

                row_max = Int32.Parse(str[0]);    //Maximum Rows
                col_max = Int32.Parse(str[1]);    //Maximum Columns    

                // checking the gridsize is greater than zero
                if (row_max <= 0 || col_max <= 0)
                {
                    Console.WriteLine("Grid size must be greater than zero");
                    grid = Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }
            // We leave the while loop here once validInput == true
                Console.WriteLine("Robot Command: ");
                string cmd_str = Console.ReadLine();    // Robot Command

                dir = "N"; // Initial Robot direction
                Move(cmd_str); // Call the Move function with Robot Command
            
        }

         public static void Move(string strMessages)
         {
             char[] messages = strMessages.ToCharArray();

             for (int i = 0; i < messages.Length; i++)
             {
                 switch (messages[i])
                 {
                     case 'L':
                         TurnLeft();
                         break;
                     case 'R':
                         TurnRight();
                         break;
                     case 'F': // Move Forward
                         MoveForward();
                         break;
                     default:
                         // throw new ArgumentException();
                         break;
                 }
             }
                          
             if (dir == "N") dir = "North";
             if (dir == "S") dir = "South";
             if (dir == "W") dir = "West";
             if (dir == "E") dir = "East";
             Console.WriteLine(x + ", " + y + ", " + dir );
             Console.ReadLine();
         }

         public static void TurnLeft()
         {
             int index = Array.IndexOf(str_dir, dir);
             if (index > -1 && index < str_dir.Length)
             {
                 dir = str_dir[(index - 1 + str_dir.Length) % str_dir.Length];
             }
             else
             {
                 // throw new ArgumentException();  
             }
         }

         public static  void TurnRight()
         {
             int index = Array.IndexOf(str_dir, dir);
             if (index > -1 && index < str_dir.Length)
             {
                 dir = str_dir[(index + 1) % str_dir.Length];
             }
             else
             {
                 // throw new ArgumentException();  
             }
         }

         public static void MoveForward()
         {
             switch (dir)
             {
                 case "N":
                     if (y < row_max)
                         y = y + 1;
                     break;
                 case "W":
                     if (x  > 0)
                         x = x - 1;
                     break;
                 case "S":
                     if (y > 0)
                         y = y - 1;
                     break;
                 case "E":
                     if (x < col_max)
                         x = x + 1;
                     break;
                 default:
                     //throw new ArgumentException();
                     break;
             }
         }        
    }
}

