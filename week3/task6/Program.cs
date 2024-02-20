using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EZInput;

namespace task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Enemy> enemies = new List<Enemy>();

            char enemycharacter;
            int enemyx, enemyy;
            string enemydirection;
            enemycharacter = 'j';
            enemyx = 1; enemyy=1;
            enemydirection = "right";
            Enemy enemy1 = new Enemy(enemycharacter,enemyx,enemyy,enemydirection);
            enemies.Add(enemy1);
            enemycharacter = 'k';
            enemyx = 2; enemyy = 18;
            enemydirection = "down";
            Enemy enemy2 = new Enemy(enemycharacter, enemyx, enemyy, enemydirection);
            enemies.Add(enemy2);

            Console.WriteLine("Enter character: ");
            char ch=char.Parse(Console.ReadLine());
            Console.WriteLine("Enter x axis: ");
            int x=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter y axis: ");
            int y = int.Parse(Console.ReadLine());
            Player player = new Player(ch, x, y);

            char[,] maze = new char[15, 20]
            {
                {'%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ' ,' ',' ',' ',' ',' ',' ',' ',' ',' ','&'},
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ' ,' ',' ',' ',' ',' ',' ',' ',' ',' ','&'},
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ' ,' ',' ',' ',' ',' ',' ',' ',' ',' ','&'},
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ' ,' ',' ',' ',' ',' ',' ',' ',' ',' ','&'},
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                {'%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%' },
            };
            bool game = true;
            Console.Clear();
            PrintMaze(maze);
            player.printplayer();
            Printenemy(enemies,0);
            Printenemy(enemies,1);

            while (game)
            {
                Thread.Sleep(200);
                if(Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    player.moveplayerright(maze);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    player.moveplayerleft(maze);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    player.moveplayerup(maze);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    player.moveplayerdown(maze);
                }
                Moveenemy(enemies, 0);
                enemies[0].direction=changedirection(enemies, 0);
                Moveenemy(enemies,1);
                enemies[1].direction = changedirection(enemies,1);

            }
        }

        
        
        static void PrintMaze(char[,] maze)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Printenemy(List<Enemy> enemies,int i)
        {
           
                int x = enemies[i].enemyx;
                int y = enemies[i].enemyy;
                Console.SetCursorPosition(y,x);
                Console.WriteLine(enemies[i].enemycharacter);
            
        }
        static void Removeenemy(List<Enemy> enemies,int i)
        {
            
                int x = enemies[i].enemyx;
                int y = enemies[i].enemyy;
                Console.SetCursorPosition(y, x);
                Console.WriteLine(" ");
            
        }

        static void Moveenemy(List<Enemy> enemies,int i)
        { 
                
                    Removeenemy(enemies,i);
                    if (enemies[i].direction == "right")
                    {

                        enemies[i].enemyy = enemies[i].enemyy + 1;
                    }
                    if (enemies[i].direction == "left")
                    {

                        enemies[i].enemyy = enemies[i].enemyy - 1;
                    }
                    
                    if (enemies[i].direction == "down")
                    {
                        enemies[i].enemyx = enemies[i].enemyx + 1;
                    }
                    if (enemies[i].direction == "up")
                    {
                        
                        enemies[i].enemyx = enemies[i].enemyx - 1;
                    }
                    Printenemy(enemies,i);
                
            
        }

        static string changedirection(List<Enemy> enemies,int i)
        {
            if (enemies[i].direction == "right" && enemies[i].enemyy >= 18)
            {
                enemies[i].direction = "left";
            }
            if (enemies[i].direction == "left" && enemies[i].enemyy <= 1)
            {
                enemies[i].direction = "right";
            }
            if (enemies[i].direction == "down" && enemies[i].enemyx >= 13)
            {
                enemies[i].direction = "up";
            }
            if (enemies[i].direction == "up" && enemies[i].enemyx <= 2)
            {
                enemies[i].direction = "down";
            }
            return enemies[i].direction;
        }

    }
    
}
