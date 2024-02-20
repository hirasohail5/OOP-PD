using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    internal class Enemy
    {

        public char enemycharacter;
        public int enemyx;
        public int enemyy;
        public string direction;

        public Enemy(char displayCharacter, int x, int y,string dir)
        {
            enemycharacter = displayCharacter;
            enemyx = x;
            enemyy = y;
            direction = dir;
        }

        public void Moveenmyhorizontal()
        {
            
        }
        public void Moveenmyvertical()
        {
            
        }


    }
}
