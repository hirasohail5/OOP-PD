using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Calculator
    {
        public int number1;
        public int number2;
        public int result;
        public List<string> calculations = new List<string>();
         public Calculator(int number1, int number2,int result)
        {
            this.number1 = number1;
            this.number2 = number2;
            this.result = result;
        }
        public void addTolist(string s)
        {
            calculations.Add(s);
        }
        public int add()
        {
            result = number1 + number2;
            return result;
        }
        public int sub()
        {
            result = number1 - number2;
            return result;
        }
        public int mul()
        {
            result = number1 * number2;
            return result;
        }
        public int div()
        {
            result = number1 / number2;
            return result;
        }

    }
}
