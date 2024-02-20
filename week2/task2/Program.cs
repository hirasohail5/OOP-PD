using System;
using EZInput;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        class Enemy
        {
            public Enemy(char symbol, int x, int y)
            {
                this.symbol = symbol;
                this.x = x;
                this.y = y;

            }
            public char symbol;
            public int x;
            public int y;
        }

        class Player
        {
            public Player(char symbol, int x, int y)
            {
                this.symbol = symbol;
                this.x = x;
                this.y = y;
            }
            public char symbol;
            public int x;
            public int y;
        }

        static public int BX = 0, BY = 0;
        static public int scoreBoxX = 0, scoreBoxY = 26;
        public const int scoreBoxHeight = 7;
        public const int scoreBoxWidth = 53;
        public const int boardHeight = 26;
        public const int boardWidth = 53;
        public static char[,] board = new char[,]
 {
    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#','#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#','#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
 };
        public static char[,] scoreBox = new char[,]
 {
    {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-','-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
    {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
    {'|', ' ', ' ', 'S', 'C', 'O', 'R', 'E', ':', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
    {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
    {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-','-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
 };




        ///////////////////////////////////////////


        // ENEMY  /////////////////////////////
        //
        static public int enemy1Col = 0;
        static public int enemy1Row = 0;
        static public int enemy2Col = 0;
        static public int enemy2Row = 0;
        static public int enemy3Col = 0;
        static public int enemy3Row = 0;

        static public int score = 0;

        static public string horizontalDirection = "right";
        static public string verticalDirection = "down";
        static public string diagonalDirection = "rightDown";


        static void Main(string[] args)
        {
            Player player = new Player('P', boardHeight - 4, boardWidth / 2);
            List<Enemy> enemyList = new List<Enemy>
            {
                new Enemy('e',3, 7),
                new Enemy('x',27, 3),
                new Enemy('s',3, 3)
            };

            placeEnemies(enemyList);
            printPlayer(player);
            printBoard();
            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    movePlayerRight(player);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    movePlayerUp(player);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    movePlayerLeft(player);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    movePlayerDown(player);
                }
                if (Keyboard.IsKeyPressed(Key.Shift))
                {
                    createFire(player);
                }
                printScoreBox();
                changeDirection();
                moveEnemy1(enemyList, 'e', horizontalDirection);
                Thread.Sleep(50);
                moveEnemy2(enemyList, 'x', verticalDirection);
                Thread.Sleep(50);
                moveEnemy3(enemyList, 's', diagonalDirection);
                Thread.Sleep(50);
                moveFire(1);

                printBoard();
                Console.SetCursorPosition(10, 28);
                Console.Write(score);
            }


        }
        static void printBoard()
        {
            Console.SetCursorPosition(BX, BY);
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.Write("\n");
            }
        }
        /// scoreBox FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void printScoreBox()
        {
            Console.SetCursorPosition(scoreBoxX, scoreBoxY);
            for (int row = 0; row < (scoreBoxHeight - 2); row++)
            {
                for (int col = 0; col < (scoreBoxWidth - 1); col++)
                {
                    Console.Write(scoreBox[row, col]);
                }
                Console.Write("\n");
            }
        }
        /// PLAYER FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void printPlayer(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < boardWidth; col++)
                {
                    if (row == boardHeight - 4 && col == boardWidth / 2)
                    {
                        board[row, col] = player.symbol;
                    }
                }
            }
        }
        static void movePlayerLeft(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol && board[row, col - 1] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row, col - 1] = player.symbol;
                    }
                }
            }
        }
        static void movePlayerRight(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol && board[row, col + 1] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row, col + 1] = player.symbol;
                        break;
                    }
                }
            }
        }
        static void movePlayerUp(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol && board[row - 1, col] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row - 1, col] = player.symbol;
                        break;
                    }
                }
            }
        }
        static void movePlayerDown(Player player)
        {
            for (int col = 0; col < (boardWidth - 1); col++)
            {
                for (int row = 0; row < (boardHeight - 1); row++)
                {
                    if (board[row, col] == player.symbol && board[row + 1, col] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row + 1, col] = player.symbol;
                        break;
                    }
                }
            }
        }
        /// ENEMY FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void placeEnemies(List<Enemy> enemyList)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                board[enemyList[i].y, enemyList[i].x] = enemyList[i].symbol;
            }
        }
        static void moveEnemy1(List<Enemy> enemyList, char enemy, string direction)
        {


            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == enemy)
                    {

                        if (direction == "right" && board[row, col + 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row, col + 1] = enemy;
                            enemy1Col = col;
                            break;
                        }

                        else if (direction == "left" && board[row, col - 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row, col - 1] = enemy;
                            enemy1Col = col;
                            break;
                        }

                    }
                }
            }
        }
        static void moveEnemy2(List<Enemy> enemyList, char enemy, string direction)
        {

            for (int col = 0; col < (boardWidth - 1); col++)
            {
                for (int row = 0; row < (boardHeight - 1); row++)
                {
                    if (board[row, col] == enemy)
                    {

                        if (direction == "down" && board[row + 1, col] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row + 1, col] = enemy;
                            enemy2Row = row;
                            break;
                        }
                        else if (direction == "up" && board[row - 1, col] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row - 1, col] = enemy;
                            enemy2Row = row;
                            break;
                        }
                    }
                }
            }
        }
        static void moveEnemy3(List<Enemy> enemyList, char enemy, string direction)
        {

            int moved = 0;
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == enemy)
                    {
                        if (direction == "rightDown" && board[row + 1, col + 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row + 1, col + 1] = enemy;
                            enemy3Col++;
                            enemy3Row++;
                            moved++;
                            break;
                        }
                        else if (direction == "rightUp" && board[row - 1, col + 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row - 1, col + 1] = enemy;
                            enemy3Col++;
                            enemy3Row--;
                            moved++;
                            break;
                        }
                        else if (direction == "leftDown" && board[row + 1, col - 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row + 1, col - 1] = enemy;
                            enemy3Col--;
                            enemy3Row++;
                            moved++;
                            break;
                        }
                        else if (direction == "leftUp" && board[row - 1, col - 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row - 1, col - 1] = enemy;
                            enemy3Col--;
                            enemy3Row--;
                            moved++;
                            break;
                        }

                    }
                }
                if (moved > 0)
                {
                    break;
                }
            }
        }
        static void changeDirection()
        {

            if (horizontalDirection == "right" && enemy1Col == 49)
            {
                horizontalDirection = "left";
            }
            else if (horizontalDirection == "left" && enemy1Col == 3)
            {
                horizontalDirection = "right";
            }
            if (verticalDirection == "down" && enemy2Row == 22)
            {
                verticalDirection = "up";
            }
            else if (verticalDirection == "up" && enemy2Row == 3)
            {
                verticalDirection = "down";
            }
            else if (diagonalDirection == "rightDown" && enemy3Row == 20 && enemy3Col == 20)
            {
                diagonalDirection = "rightUp";
            }
            else if (diagonalDirection == "rightUp" && enemy3Row == -2 && enemy3Col == 42)
            {
                diagonalDirection = "leftDown";
            }
            else if (diagonalDirection == "leftDown" && enemy3Row == 20 && enemy3Col == 20)
            {
                diagonalDirection = "leftUp";
            }
            else if (diagonalDirection == "leftUp" && enemy3Row == -1 && enemy3Col == -1)
            {
                diagonalDirection = "rightDown";
            }
        }
        /// FIRE FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void createFire(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol)
                    {
                        board[row - 2, col] = '.';
                    }
                }
            }
        }

        static void moveFire(int timeShift)
        {
            for (int time = 0; time < timeShift; time++)
            {
                for (int row = 0; row < (boardHeight - 1); row++)
                {
                    for (int col = 0; col < (boardWidth - 1); col++)
                    {
                        if (board[row, col] == '.')
                        {
                            if (row > 0 && board[row - 1, col] == '#')
                            {
                                board[row, col] = ' ';
                            }
                            else if (row > 0 && (board[row - 1, col] == 'x' || board[row - 1, col] == 'e' || board[row - 1, col] == 's'))
                            {
                                board[row, col] = ' ';
                                board[row - 1, col] = ' ';
                                score += 10;
                            }
                            else
                            {
                                board[row - 1, col] = '.';
                                board[row, col] = ' ';
                            }
                        }
                    }
                }
            }
        }

        static void printBoard()
        {
            Console.SetCursorPosition(BX, BY);
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.Write("\n");
            }
        }
        /// scoreBox FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void printScoreBox()
        {
            Console.SetCursorPosition(scoreBoxX, scoreBoxY);
            for (int row = 0; row < (scoreBoxHeight - 2); row++)
            {
                for (int col = 0; col < (scoreBoxWidth - 1); col++)
                {
                    Console.Write(scoreBox[row, col]);
                }
                Console.Write("\n");
            }
        }
        /// PLAYER FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void printPlayer(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < boardWidth; col++)
                {
                    if (row == boardHeight - 4 && col == boardWidth / 2)
                    {
                        board[row, col] = player.symbol;
                    }
                }
            }
        }
        static void movePlayerLeft(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol && board[row, col - 1] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row, col - 1] = player.symbol;
                    }
                }
            }
        }
        static void movePlayerRight(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol && board[row, col + 1] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row, col + 1] = player.symbol;
                        break;
                    }
                }
            }
        }
        static void movePlayerUp(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol && board[row - 1, col] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row - 1, col] = player.symbol;
                        break;
                    }
                }
            }
        }
        static void movePlayerDown(Player player)
        {
            for (int col = 0; col < (boardWidth - 1); col++)
            {
                for (int row = 0; row < (boardHeight - 1); row++)
                {
                    if (board[row, col] == player.symbol && board[row + 1, col] == ' ')
                    {
                        board[row, col] = ' ';
                        board[row + 1, col] = player.symbol;
                        break;
                    }
                }
            }
        }
        /// ENEMY FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void placeEnemies(List<Enemy> enemyList)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                board[enemyList[i].y, enemyList[i].x] = enemyList[i].symbol;
            }
        }
        static void moveEnemy1(List<Enemy> enemyList, char enemy, string direction)
        {


            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == enemy)
                    {

                        if (direction == "right" && board[row, col + 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row, col + 1] = enemy;
                            enemy1Col = col;
                            break;
                        }

                        else if (direction == "left" && board[row, col - 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row, col - 1] = enemy;
                            enemy1Col = col;
                            break;
                        }

                    }
                }
            }
        }
        static void moveEnemy2(List<Enemy> enemyList, char enemy, string direction)
        {

            for (int col = 0; col < (boardWidth - 1); col++)
            {
                for (int row = 0; row < (boardHeight - 1); row++)
                {
                    if (board[row, col] == enemy)
                    {

                        if (direction == "down" && board[row + 1, col] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row + 1, col] = enemy;
                            enemy2Row = row;
                            break;
                        }
                        else if (direction == "up" && board[row - 1, col] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row - 1, col] = enemy;
                            enemy2Row = row;
                            break;
                        }
                    }
                }
            }
        }
        static void moveEnemy3(List<Enemy> enemyList, char enemy, string direction)
        {

            int moved = 0;
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == enemy)
                    {
                        if (direction == "rightDown" && board[row + 1, col + 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row + 1, col + 1] = enemy;
                            enemy3Col++;
                            enemy3Row++;
                            moved++;
                            break;
                        }
                        else if (direction == "rightUp" && board[row - 1, col + 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row - 1, col + 1] = enemy;
                            enemy3Col++;
                            enemy3Row--;
                            moved++;
                            break;
                        }
                        else if (direction == "leftDown" && board[row + 1, col - 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row + 1, col - 1] = enemy;
                            enemy3Col--;
                            enemy3Row++;
                            moved++;
                            break;
                        }
                        else if (direction == "leftUp" && board[row - 1, col - 1] == ' ')
                        {
                            board[row, col] = ' ';
                            board[row - 1, col - 1] = enemy;
                            enemy3Col--;
                            enemy3Row--;
                            moved++;
                            break;
                        }

                    }
                }
                if (moved > 0)
                {
                    break;
                }
            }
        }
        static void changeDirection()
        {

            if (horizontalDirection == "right" && enemy1Col == 49)
            {
                horizontalDirection = "left";
            }
            else if (horizontalDirection == "left" && enemy1Col == 3)
            {
                horizontalDirection = "right";
            }
            if (verticalDirection == "down" && enemy2Row == 22)
            {
                verticalDirection = "up";
            }
            else if (verticalDirection == "up" && enemy2Row == 3)
            {
                verticalDirection = "down";
            }
            else if (diagonalDirection == "rightDown" && enemy3Row == 20 && enemy3Col == 20)
            {
                diagonalDirection = "rightUp";
            }
            else if (diagonalDirection == "rightUp" && enemy3Row == -2 && enemy3Col == 42)
            {
                diagonalDirection = "leftDown";
            }
            else if (diagonalDirection == "leftDown" && enemy3Row == 20 && enemy3Col == 20)
            {
                diagonalDirection = "leftUp";
            }
            else if (diagonalDirection == "leftUp" && enemy3Row == -1 && enemy3Col == -1)
            {
                diagonalDirection = "rightDown";
            }
        }
        /// FIRE FUNCTIONS//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void createFire(Player player)
        {
            for (int row = 0; row < (boardHeight - 1); row++)
            {
                for (int col = 0; col < (boardWidth - 1); col++)
                {
                    if (board[row, col] == player.symbol)
                    {
                        board[row - 2, col] = '.';
                    }
                }
            }
        }

        static void moveFire(int timeShift)
        {
            for (int time = 0; time < timeShift; time++)
            {
                for (int row = 0; row < (boardHeight - 1); row++)
                {
                    for (int col = 0; col < (boardWidth - 1); col++)
                    {
                        if (board[row, col] == '.')
                        {
                            if (row > 0 && board[row - 1, col] == '#')
                            {
                                board[row, col] = ' ';
                            }
                            else if (row > 0 && (board[row - 1, col] == 'x' || board[row - 1, col] == 'e' || board[row - 1, col] == 's'))
                            {
                                board[row, col] = ' ';
                                board[row - 1, col] = ' ';
                                score += 10;
                            }
                            else
                            {
                                board[row - 1, col] = '.';
                                board[row, col] = ' ';
                            }
                        }
                    }
                }
            }
        }
    }
}
