using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    internal class Player
    {
        public char DisplayCharacter;
        public int playerx;
        public int playery;

        public Player(char displayCharacter, int x, int y)
        {
            DisplayCharacter = displayCharacter;
            playerx = x;
            playery = y;
        }

        public void moveplayerright(char[,] maze)
        {
            if (maze[playerx, playery + 1] == ' ')
            {

                maze[playerx, playery] = ' ';
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(" ");
                playery = playery + 1;
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(DisplayCharacter);
            }
        }
        public void printplayer()
        {
            Console.SetCursorPosition(playery, playerx);
            Console.WriteLine(DisplayCharacter);
        }
        public void moveplayerleft(char[,] maze)
        {
            if (maze[playerx, playery - 1] == ' ')
            {
                maze[playerx, playery] = ' ';
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(" ");
                playery = playery - 1;
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(DisplayCharacter);
            }
        }
        public void moveplayerup(char[,] maze)
        {
            if (maze[playerx - 1, playery] == ' ')
            {
                maze[playerx, playery] = ' ';
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(" ");
                playerx = playerx - 1;
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(DisplayCharacter);
            }
        }
        public void moveplayerdown(char[,] maze)
        {
            if (maze[playerx + 1, playery] == ' ')
            {
                maze[playerx, playery] = ' ';
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(" ");
                playerx = playerx + 1;
                Console.SetCursorPosition(playery, playerx);
                Console.WriteLine(DisplayCharacter);
            }
        }

    }
}
