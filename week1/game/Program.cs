using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    internal class Program
    {
        static public int playerx = 42, playery = 10;
        static public int enemy1x = 2, enemy1y = 28;
        static public int enemy2x = 99, enemy2y = 1;
        static public int enemy3x = 1, enemy3y = 1;
        static public int enemy4x = 64, enemy4y = 11;
        static public int score = 0;
        static public int enemy1health = 200;
        static public char bullet = '*';
        static public char enemybullet = '+';
        static public char bullet2 = '@';
        static public char enemybullet1 = '&';
        static public int live = 6;
        static public bool check = true;
        public const int mazeheight = 33, mazewidth = 156;
        static public char[][] maze = new char[mazeheight][];
        static void Main(string[] args)
        {
            
            InitializeMaze(maze);
            while (true)
            {
                string option;
                Console.Clear();
                Header();
                option = Option1();
                if (option == "1")
                {
                    Console.Clear();
                    PrintMaze();
                    Player();
                    Enemy1();
                    Enemy2();
                    Enemy3();
                    Enemy4();
                    PrintScore(score);
                    PrintEnemy1Health(enemy1health);
                    string enemy1direction = "right";
                    string enemy2direction = "right";
                    string enemy3direction = "down";
                    string enemy4direction = "down";

                    while (check)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);

                            if (key.Key == ConsoleKey.LeftArrow)
                                MovePlayerLeft();
                            else if (key.Key == ConsoleKey.RightArrow)
                                MovePlayerRight();
                            else if (key.Key == ConsoleKey.UpArrow)
                                MovePlayerUp();
                            else if (key.Key == ConsoleKey.DownArrow)
                                MovePlayerDown();
                            else if (key.Key == ConsoleKey.NumPad4)
                                PrintBullet();

                            MoveEnemy1(enemy1direction);
                            enemy1direction = ChangeDirection1(enemy1direction);
                            MoveEnemy2(enemy2direction);
                            enemy2direction = ChangeDirection2(enemy2direction);
                            MoveEnemy3(enemy3direction);
                            enemy3direction = ChangeDirection3(enemy3direction);
                            MoveEnemy4(enemy4direction);
                            enemy4direction = ChangeDirection4(enemy4direction);
                            PrintEnemyBullet();
                            MoveBullet();
                            MoveUpBullet();
                            MoveEnemyBullet();
                            PrintEnemyUpBullet();
                            PrintLives();

                            if (live < 0)
                            {
                                check = false;
                                Console.Clear();
                                Console.WriteLine("You lose");
                                Console.WriteLine("Your score: " + score);
                                Console.ReadKey();
                            }

                            if (enemy1health < 0)
                            {
                                check = false;
                                Console.Clear();
                                Console.WriteLine("You win");
                                Console.WriteLine("Your score: " + score);
                                Console.ReadKey();
                            }
                        }
                    }
                }
                else if (option == "2")
                {
                    Instructions();
                }
                else if (option == "3")
                {
                    check = false;// exit or break from loop
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered the wrong option. Press any key to try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
        static void InitializeMaze(char[][] maze)
        {
            maze[0] = "##########################################################################################################################################################".ToCharArray();
            maze[1] = "!                                                #                                                #                                                       !".ToCharArray();
            maze[2] = "!                                      O         #                                                #                                                       !".ToCharArray();
            maze[3] = "!                                                #                                O               #                                                       !".ToCharArray();
            maze[4] = "!                                                #                                                #                                                       !".ToCharArray();
            maze[5] = "!                                                #                                                #                                                       !".ToCharArray();
            maze[6] = "!                                                #                                                #                                                       !".ToCharArray();
            maze[7] = "!            ################                    #                ##############                  #                 #######################       O       !".ToCharArray();
            maze[8] = "!            #                                   #       O                     #                                    #              #                      !".ToCharArray();
            maze[9] = "!            #                                   #                             #                                    #              #                      !".ToCharArray();
            maze[10] = "!            #      O                            #                             #                                    #      o       #                      !".ToCharArray();
            maze[11] = "!            #                                   #                             #                                    #              #                      !".ToCharArray();
            maze[12] = "!            #                                   #                             #                                    #              #                      !".ToCharArray();
            maze[13] = "!            ###################################################               ###################                                 #            ##########!".ToCharArray();
            maze[14] = "!                            #                                 #                                 #                                 #             #        !".ToCharArray();
            maze[15] = "!          O                 #                                 #                                 #                                 #             #        !".ToCharArray();
            maze[16] = "!                            #                   O             #                         O       #                                 #             #        !".ToCharArray();
            maze[17] = "!                            #                                 #                                 #                                 #             #        !".ToCharArray();
            maze[18] = "!                            #                                 #                                 #                                 #             #        !".ToCharArray();
            maze[19] = "!###########                                     ###############                                 ###################################                      !".ToCharArray();
            maze[20] = "!                                                #                             #                                     #      O                             !".ToCharArray();
            maze[21] = "!                   O                            #                             #                                     #                           O        !".ToCharArray();
            maze[22] = "!                                                #                             #                                     #                                    !".ToCharArray();
            maze[23] = "!                                                #                             #                                     #                                    !".ToCharArray();
            maze[24] = "!                                                #                             #                                     #                                    !".ToCharArray();
            maze[25] = "!  O         ####################################               #              #######################################                ####################!".ToCharArray();
            maze[26] = "!                                         O                     #                                 #                                                       !".ToCharArray();
            maze[27] = "!                                                               #        O                        #                                          O            !".ToCharArray();
            maze[28] = "!                                                               #                                 #                O                                      !".ToCharArray();
            maze[29] = "!                                                               #                                 #                                                       !".ToCharArray();
            maze[30] = "!                                                               #                                 #                                                       !".ToCharArray();
            maze[31] = "!                                                               #                                 #                                                       !".ToCharArray();
            maze[32] = "!##########################################################################################################################################~~~GAME-OVER~~~!".ToCharArray();
        }

        static void Header()
        {
            int a = 50, b = 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(a, b + 0);
            Console.WriteLine(" $$$$$$\\  $$\\   $$\\  $$$$$$\\  $$$$$$$\\  $$$$$$$\\   $$$$$$\\  $$\\   $$\\  $$$$$$\\   $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\ $$$$$$$\\  ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 1);
            Console.WriteLine("$$  __$$\\ $$ |  $$ |$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$ |  $$ |$$  __$$\\ $$  __$$\\__$$  __|$$  _____|$$  __$$\\ ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 2);
            Console.WriteLine("$$ /  \\__|$$ |  $$ |$$ /  $$ |$$ |  $$ |$$ |  $$ |$$ /  \\__|$$ |  $$ |$$ /  $$ |$$ /  $$ |  $$ |   $$ |      $$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 3);
            Console.WriteLine("\\$$$$$$\\  $$$$$$$$ |$$$$$$$$ |$$$$$$$  |$$$$$$$  |\\$$$$$$\\  $$$$$$$$ |$$ |  $$ |$$ |  $$ |  $$ |   $$$$$\\    $$$$$$$  |");
            Thread.Sleep(70);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(a, b + 4);
            Console.WriteLine(" \\____$$\\ $$  __$$ |$$  __$$ |$$  __$$< $$  ____/  \\____$$\\ $$  __$$ |$$ |  $$ |$$ |  $$ |  $$ |   $$  __|   $$  __$$< ");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 5);
            Console.WriteLine("$$\\   $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$\\   $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |  $$ |   $$ |      $$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 6);
            Console.WriteLine("\\$$$$$$  |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      \\$$$$$$  |$$ |  $$ | $$$$$$  | $$$$$$  |  $$ |   $$$$$$$$\\ $$ |  $$ |");
            Thread.Sleep(70);
            Console.SetCursorPosition(a, b + 7);
            Console.WriteLine(" \\______/ \\__|  \\__|\\__|  \\__|\\__|  \\__|\\__|       \\______/ \\__|  \\__| \\______/  \\______/   \\__|   \\________|\\__|  \\__|");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static string Option1()
        {
            string option;
            Console.WriteLine("  1. New game      ");
            Console.WriteLine("  2. Instructions  ");
            Console.WriteLine("  3. Exit          ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  Enter your option:    ");
            option = Console.ReadLine();
            return option;
        }

        static void PrintMaze()
        {
            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < 156; j++)
                {
                    Console.Write(maze[i][j]);
                }
                Console.WriteLine();
            }
        }

        static string ChangeDirection1(string direction)
        {
            if (direction == "right" && enemy1x >= 56)
            {
                direction = "left";
            }
            if (direction == "left" && enemy1x <= 2)
            {
                direction = "right";
            }
            return direction;
        }

        static void MoveEnemy1(string direction)
        {
            RemoveEnemy1();
            if (direction == "right")
            {
                enemy1x = enemy1x + 1;
            }
            if (direction == "left")
            {
                enemy1x = enemy1x - 1;
            }
            Enemy1();
        }

        static string ChangeDirection2(string direction)
        {
            if (direction == "right" && enemy2x >= 148)
            {
                direction = "left";
            }
            if (direction == "left" && enemy2x <= 99)
            {
                direction = "right";
            }
            return direction;
        }

        static void MoveEnemy2(string direction)
        {
            RemoveEnemy2();
            if (direction == "right")
            {
                enemy2x = enemy2x + 1;
            }
            if (direction == "left")
            {
                enemy2x = enemy2x - 1;
            }
            Enemy2();
        }

        static string ChangeDirection3(string direction)
        {
            if (direction == "down" && enemy3y >= 15)
            {
                direction = "up";
            }
            if (direction == "up" && enemy3y <= 1)
            {
                direction = "down";
            }
            return direction;
        }

        static void MoveEnemy3(string direction)
        {
            RemoveEnemy3();
            if (direction == "down")
            {
                enemy3y = enemy3y + 1;
            }
            if (direction == "up")
            {
                enemy3y = enemy3y - 1;
            }
            Enemy3();
        }

        static string ChangeDirection4(string direction)
        {
            if (direction == "down" && enemy4x >= 92)
            {
                direction = "up";
            }
            if (direction == "up" && enemy4x <= 64)
            {
                direction = "down";
            }
            return direction;
        }

        static void MoveEnemy4(string direction)
        {
            RemoveEnemy4();
            if (direction == "down")
            {
                enemy4x = enemy4x + 3;
                enemy4y = enemy4y + 1;
            }
            if (direction == "up")
            {
                enemy4x = enemy4x - 3;
                enemy4y = enemy4y - 1;
            }
            Enemy4();
        }

        static void PrintScore(int score)
        {
            int scorex = 160, scorey = 15;
            Console.SetCursorPosition(scorex, scorey);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("SCORE: " + score);
        }

        static void PrintLives()
        {
            int livesx = 160, livesy = 21;
            Console.SetCursorPosition(livesx, livesy);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("LIVES: " + live);
        }

        static void Player()
        {
            Console.SetCursorPosition(playerx, playery);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" 0 ");
            Console.SetCursorPosition(playerx, playery + 1);
            Console.Write("<|>");
            Console.SetCursorPosition(playerx, playery + 2);
            Console.Write("^ ^");
        }

        static void RemovePlayer()
        {
            Console.SetCursorPosition(playerx, playery);
            Console.Write("    ");
            Console.SetCursorPosition(playerx, playery + 1);
            Console.Write("    ");
            Console.SetCursorPosition(playerx, playery + 2);
            Console.Write("    ");
        }

        static void MovePlayerRight()
        {
            if (GetCharAtXY(playerx + 4, playery) == ' ' && GetCharAtXY(playerx + 4, playery + 1) == ' ' && GetCharAtXY(playerx + 4, playery + 2) == ' ')
            {
                RemovePlayer();
                playerx = playerx + 1;
                Player();
            }

            if (GetCharAtXY(playerx + 4, playery) == 'O' || GetCharAtXY(playerx + 4, playery + 1) == 'O' || GetCharAtXY(playerx + 4, playery + 2) == 'O')
            {
                RemovePlayer();
                playerx = playerx + 1;
                score++;
                Player();
                PrintScore(score);
            }
            if (GetCharAtXY(playerx + 4, playery) == '+' || GetCharAtXY(playerx + 4, playery + 1) == '+' || GetCharAtXY(playerx + 4, playery + 2) == '+')
            {
                RemovePlayer();
                playerx = playerx + 1;
                live--;
                Player();
                PrintLives();
            }
            if (GetCharAtXY(playerx + 4, playery) == '&' || GetCharAtXY(playerx + 4, playery + 1) == '&' || GetCharAtXY(playerx + 4, playery + 2) == '&')
            {
                RemovePlayer();
                playerx = playerx + 1;
                live--;
                Player();
                PrintLives();
            }

            if (GetCharAtXY(playerx + 4, playery + 3) == '~')
            {
                Console.Clear();
                Console.ReadKey();
                check = false;
                Console.Clear();
                Console.WriteLine("Game over");
                Console.WriteLine("Your score: " + score);
                Console.ReadKey();
            }
        }

        static void MovePlayerLeft()
        {
            if (GetCharAtXY(playerx - 1, playery) == ' ' && GetCharAtXY(playerx - 1, playery + 1) == ' ' && GetCharAtXY(playerx - 1, playery + 2) == ' ')
            {
                RemovePlayer();
                playerx = playerx - 1;
                Player();
            }

            if (GetCharAtXY(playerx - 1, playery) == 'O' || GetCharAtXY(playerx - 1, playery + 1) == 'O' || GetCharAtXY(playerx - 1, playery + 2) == 'O')
            {
                RemovePlayer();
                playerx = playerx - 1;
                score++;
                Player();
                PrintScore(score);
            }
            if (GetCharAtXY(playerx - 1, playery) == '+' || GetCharAtXY(playerx - 1, playery + 1) == '+' || GetCharAtXY(playerx - 1, playery + 2) == '+')
            {
                RemovePlayer();
                playerx = playerx - 1;
                live--;
                Player();
                PrintLives();
            }
            if (GetCharAtXY(playerx - 1, playery) == '&' || GetCharAtXY(playerx - 1, playery + 1) == '&' || GetCharAtXY(playerx - 1, playery + 2) == '&')
            {
                RemovePlayer();
                playerx = playerx - 1;
                live--;
                Player();
                PrintLives();
            }
        }

        static void MovePlayerUp()
        {
            if (GetCharAtXY(playerx, playery - 1) == ' ' && GetCharAtXY(playerx + 1, playery - 1) == ' ' && GetCharAtXY(playerx + 2, playery - 1) == ' ' && GetCharAtXY(playerx + 3, playery - 1) == ' ')
            {
                RemovePlayer();
                playery = playery - 1;
                Player();
            }

            if (GetCharAtXY(playerx, playery - 1) == 'O' || GetCharAtXY(playerx + 1, playery - 1) == 'O' || GetCharAtXY(playerx + 2, playery - 1) == 'O' || GetCharAtXY(playerx + 3, playery - 1) == 'O')
            {
                RemovePlayer();
                playery = playery - 1;
                score++;
                Player();
                PrintScore(score);
            }
            if (GetCharAtXY(playerx, playery - 1) == '+' || GetCharAtXY(playerx + 1, playery - 1) == '+' || GetCharAtXY(playerx + 2, playery - 1) == '+' || GetCharAtXY(playerx + 3, playery - 1) == '+')
            {
                RemovePlayer();
                playery = playery - 1;
                live--;
                Player();
                PrintLives();
            }
            if (GetCharAtXY(playerx, playery - 1) == '&' || GetCharAtXY(playerx + 1, playery - 1) == '&' || GetCharAtXY(playerx + 2, playery - 1) == '&' || GetCharAtXY(playerx + 3, playery - 1) == '&')
            {
                RemovePlayer();
                playery = playery - 1;
                live--;
                Player();
                PrintLives();
            }
        }

        static void MovePlayerDown()
        {
            if (GetCharAtXY(playerx, playery + 3) == ' ' && GetCharAtXY(playerx + 1, playery + 3) == ' ' && GetCharAtXY(playerx + 2, playery + 3) == ' ' && GetCharAtXY(playerx + 3, playery + 3) == ' ')
            {
                RemovePlayer();
                playery = playery + 1;
                Player();
            }

            if (GetCharAtXY(playerx, playery + 3) == 'O' || GetCharAtXY(playerx + 1, playery + 3) == 'O' || GetCharAtXY(playerx + 2, playery + 3) == 'O' || GetCharAtXY(playerx + 3, playery + 3) == 'O')
            {
                RemovePlayer();
                playery = playery + 1;
                score++;
                Player();
                PrintScore(score);
            }
            if (GetCharAtXY(playerx, playery + 3) == '+' || GetCharAtXY(playerx + 1, playery + 3) == '+' || GetCharAtXY(playerx + 2, playery + 3) == '+' || GetCharAtXY(playerx + 3, playery + 3) == '+')
            {
                RemovePlayer();
                playery = playery + 1;
                live--;
                Player();
                PrintLives();
            }
            if (GetCharAtXY(playerx, playery + 3) == '&' || GetCharAtXY(playerx + 1, playery + 3) == '&' || GetCharAtXY(playerx + 2, playery + 3) == '&' || GetCharAtXY(playerx + 3, playery + 3) == '&')
            {
                RemovePlayer();
                playery = playery + 1;
                live--;
                Player();
                PrintLives();
            }

            if (GetCharAtXY(playerx, playery + 3) == '~' || GetCharAtXY(playerx + 1, playery + 3) == '~' || GetCharAtXY(playerx + 2, playery + 3) == '~')
            {
                Console.Clear();
                Console.ReadKey();
                check = false;
                Console.Clear();
                Console.WriteLine("Game over");
                Console.WriteLine("Your score: " + score);
                Console.ReadKey();
            }
        }

        static private char GetCharAtXY(int playerx, int v)
        {
            throw new NotImplementedException();
        }

        static void PrintBullet()
        {
            Console.SetCursorPosition(playerx, playery);
            if (GetCharAtXY(playerx - 1, playery + 1) == ' ')
            {
                maze[playery + 1][playerx - 1] = bullet;
            }
        }

        static void PrintUpBullet()
        {
            Console.SetCursorPosition(playerx, playery);
            if (GetCharAtXY(playerx + 1, playery - 1) == ' ')
            {
                maze[playery - 1][playerx + 1] = bullet2;
            }
        }

        static void PrintEnemyBullet()
        {
            Console.SetCursorPosition(enemy1x, enemy1y);
            if (GetCharAtXY(enemy1x - 1, enemy1y + 2) == ' ')
            {
                maze[enemy1y + 2][enemy1x - 1] = enemybullet;
            }
            Console.SetCursorPosition(enemy2x, enemy2y);
            if (GetCharAtXY(enemy2x - 1, enemy2y + 2) == ' ')
            {
                maze[enemy2y + 2][enemy2x - 1] = enemybullet;
            }
        }

        static void PrintEnemyUpBullet()
        {
            Console.SetCursorPosition(enemy3x, enemy3y);
            if (GetCharAtXY(enemy3x + 2, enemy3y - 1) == ' ')
            {
                maze[enemy3y - 1][enemy3x + 2] = enemybullet1;
            }
        }

        static void MoveBullet()
        {
            for (int i = 0; i < 156; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (maze[j][i] == bullet && GetCharAtXY(i - 1, j) == ' ')
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                        maze[j][i - 1] = bullet;
                        Console.SetCursorPosition(i - 1, j);
                        Console.Write(maze[j][i - 1]);
                    }
                    else if (bullet == maze[j][i] && (GetCharAtXY(i - 1, j) == '#' || GetCharAtXY(i - 1, j) == '!' || GetCharAtXY(i - 1, j) == 'O'))
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                    }
                    if (bullet == maze[j][i] && (GetCharAtXY(i - 1, j) == '|' || GetCharAtXY(i - 1, j) == '_' || GetCharAtXY(i - 1, j) == '/' || GetCharAtXY(i - 1, j) == '\\' || GetCharAtXY(i - 1, j) == '.' || GetCharAtXY(i - 1, j) == '(' || GetCharAtXY(i - 1, j) == ')' || GetCharAtXY(i - 1, j) == '-'))
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                        enemy1health -= 10;
                        PrintEnemy1Health(enemy1health);
                    }
                }
            }
        }

        static void MoveUpBullet()
        {
            int c = enemy3x, d = enemy3y;
            for (int i = 0; i < 156; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (maze[j][i] == bullet2 && GetCharAtXY(i, j - 1) == ' ')
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                        maze[j - 1][i] = bullet2;
                        Console.SetCursorPosition(i, j - 1);
                        Console.Write(maze[j - 1][i]);
                        System.Threading.Thread.Sleep(70);
                    }
                    else if (bullet2 == maze[j][i] && (GetCharAtXY(i, j - 1) == '#' || GetCharAtXY(i, j - 1) == '!' || GetCharAtXY(i - 1, j) == 'O'))
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                    }
                    if (bullet == maze[j][i] && (GetCharAtXY(i, j - 1) == '|' || GetCharAtXY(i, j - 1) == '_' || GetCharAtXY(i, j - 1) == '/' || GetCharAtXY(i, j - 1) == '\\' || GetCharAtXY(i, j - 1) == '.' || GetCharAtXY(i, j - 1) == '(' || GetCharAtXY(i, j - 1) == ')' || GetCharAtXY(i, j - 1) == '-'))
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                        enemy1health -= 10;
                        PrintEnemy1Health(enemy1health);
                    }
                }
            }
        }

        static void MoveEnemyBullet()
        {
            for (int i = 0; i < 156; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (maze[j][i] == enemybullet && GetCharAtXY(i - 1, j) == ' ')
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                        maze[j][i - 1] = enemybullet;
                        Console.SetCursorPosition(i - 1, j);
                        Console.Write(maze[j][i - 1]);
                    }
                    else if (enemybullet == maze[j][i] && (GetCharAtXY(i - 1, j) == '#' || GetCharAtXY(i - 1, j) == '!' || GetCharAtXY(i - 1, j) == 'O'))
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                    }
                }
            }
        }

        static void MoveUpEnemyBullet()
        {
            int c = enemy3x, d = enemy3y;
            for (int i = 0; i < 156; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (maze[j][i] == enemybullet1 && GetCharAtXY(i, j - 1) == ' ')
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                        maze[j - 1][i] = enemybullet1;
                        Console.SetCursorPosition(i, j - 1);
                        Console.Write(maze[j - 1][i]);
                        System.Threading.Thread.Sleep(70);
                    }
                    else if (enemybullet1 == maze[j][i] && (GetCharAtXY(i, j - 1) == '#' || GetCharAtXY(i, j - 1) == '!' || GetCharAtXY(i - 1, j) == 'O'))
                    {
                        maze[j][i] = ' ';
                        Console.SetCursorPosition(i, j);
                        Console.Write(maze[j][i]);
                    }
                }
            }
        }

        static void PrintEnemy1Health(int enemy1health)
        {
            int enemy1healthx = 160, enemy1healthy = 18;
            Console.SetCursorPosition(enemy1healthx, enemy1healthy);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ENEMYHEALTH: ");
            Console.SetCursorPosition(enemy1healthx + 14, enemy1healthy);
            Console.Write(enemy1health);
            if (enemy1health == 90)
            {
                Console.SetCursorPosition(enemy1healthx + 16, enemy1healthy);
                Console.Write(" ");
            }
        }

        static void Enemy1()
        {
            Console.SetCursorPosition(enemy1x, enemy1y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" _  ");
            Console.SetCursorPosition(enemy1x, enemy1y + 1);
            Console.Write("/ \\");
            Console.SetCursorPosition(enemy1x, enemy1y + 2);
            Console.Write("|()|");
            Console.SetCursorPosition(enemy1x, enemy1y + 3);
            Console.Write("\\_/");
        }

        static void RemoveEnemy1()
        {
            Console.SetCursorPosition(enemy1x, enemy1y);
            Console.Write("    ");
            Console.SetCursorPosition(enemy1x, enemy1y + 1);
            Console.Write("    ");
            Console.SetCursorPosition(enemy1x, enemy1y + 2);
            Console.Write("    ");
            Console.SetCursorPosition(enemy1x, enemy1y + 3);
            Console.Write("    ");
        }

        static void Enemy2()
        {
            Console.SetCursorPosition(enemy2x, enemy2y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" __  ");
            Console.SetCursorPosition(enemy2x, enemy2y + 1);
            Console.Write("/..\\");
            Console.SetCursorPosition(enemy2x, enemy2y + 2);
            Console.Write("|  | ");
            Console.SetCursorPosition(enemy2x, enemy2y + 3);
            Console.Write("\\__/");
        }

        static void RemoveEnemy2()
        {
            Console.SetCursorPosition(enemy2x, enemy2y);
            Console.Write("      ");
            Console.SetCursorPosition(enemy2x, enemy2y + 1);
            Console.Write("      ");
            Console.SetCursorPosition(enemy2x, enemy2y + 2);
            Console.Write("      ");
            Console.SetCursorPosition(enemy2x, enemy2y + 3);
            Console.Write("       ");
        }

        static void Enemy3()
        {
            Console.SetCursorPosition(enemy3x, enemy3y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" .-. ");
            Console.SetCursorPosition(enemy3x, enemy3y + 1);
            Console.Write("(o o)");
            Console.SetCursorPosition(enemy3x, enemy3y + 2);
            Console.Write("|   |");
            Console.SetCursorPosition(enemy3x, enemy3y + 3);
            Console.Write("-----");
        }

        static void RemoveEnemy3()
        {
            Console.SetCursorPosition(enemy3x, enemy3y);
            Console.Write("     ");
            Console.SetCursorPosition(enemy3x, enemy3y + 1);
            Console.Write("     ");
            Console.SetCursorPosition(enemy3x, enemy3y + 2);
            Console.Write("      ");
            Console.SetCursorPosition(enemy3x, enemy3y + 3);
            Console.Write("      ");
        }

        static void Enemy4()
        {
            Console.SetCursorPosition(enemy4x, enemy4y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" .-. ");
            Console.SetCursorPosition(enemy4x, enemy4y + 1);
            Console.Write("(   )");
            Console.SetCursorPosition(enemy4x, enemy4y + 2);
            Console.Write(" | | ");
            Console.SetCursorPosition(enemy4x, enemy4y + 3);
            Console.Write(" |_| ");
        }

        static void RemoveEnemy4()
        {
            Console.SetCursorPosition(enemy4x, enemy4y);
            Console.Write("     ");
            Console.SetCursorPosition(enemy4x, enemy4y + 1);
            Console.Write("     ");
            Console.SetCursorPosition(enemy4x, enemy4y + 2);
            Console.Write("     ");
            Console.SetCursorPosition(enemy4x, enemy4y + 3);
            Console.Write("     ");
        }

        static void Instructions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1\tIt is a very easy game to play you just have to shoot the enemy.");
            Console.WriteLine("2\tThe player can fire the bullet by pressing the 4 key.");
            Console.WriteLine("3\tThe score increases as the player gets the bonus point.");
            Console.WriteLine("4\tThere are five lives for the player.");
            Console.WriteLine("5\tThere is also an enemy health system.");
            Console.WriteLine("6\tThe enemy health decrease as the player fires the bullet and it touches the enemy body.");
            Console.WriteLine("7\tThere are also lives for the user and if it gets hit by the enemy bullet or collides with it then its lives decrease.");
            Console.WriteLine("8\tIf all the lives of the player decrease then the player loses the game.");
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }

       
    }
}
