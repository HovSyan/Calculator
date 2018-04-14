using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    class Methods
    {
        public static double Calculate(string input)
        {
            double sum, minus, product, devide;
            double output = 0;
            Stack<int> indexesOfBrackets = new Stack<int>();
            int open, close;
            string subOperation;

            try
            {

                for (int i = 0; i < input.Count(); i++)
                {
                    if (input[i] == '(')
                    {
                        indexesOfBrackets.Push(i);
                    }
                    else if (input[i] == ')')
                    {
                        open = indexesOfBrackets.Pop();
                        close = i;

                        subOperation = input.Substring(open + 1, close - open - 1);

                        //Console.WriteLine(subOperation);

                        output = Methods.Count(subOperation);

                        input = input.Substring(0, open) + output.ToString() + input.Substring(close + 1);
                        i = 0;
                    }
                }

                return Count(input);
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
                return 0.0;
            }
        }

        public static List<string> SplitByOperators(string s)
        {
            string number = "";
            List<string> operations = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    continue;

                if (s[i] == '(')
                {
                    operations.Add(s[i].ToString());
                    continue;
                }

                if (s[i] == ')')
                {
                    operations.Add(number);
                    operations.Add(s[i].ToString());
                    number = "";
                    continue;
                }

                if (s[i] != '+' && s[i] != '-' && s[i] != '*' && s[i] != '/')
                {
                    number += s[i];
                }
                else
                {
                    if (!number.Equals(""))
                        operations.Add(number.Trim());

                    operations.Add(s[i].ToString());
                    number = "";
                }
            }

            if (!number.Equals(""))
            {
                operations.Add(number.Trim());
            }

            return operations;
        }

        public static void OperatingProductAndDevision(List<string> operations, out List<string> newOperations)
        {
            double product, devide;
            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i] == "*")
                {
                    product = Convert.ToDouble(operations[i - 1]) * Convert.ToDouble(operations[i + 1]);
                    operations[i] = product.ToString();
                    operations.RemoveAt(i + 1);
                    operations.RemoveAt(i - 1);
                    i = 0;

                }
                else if (operations[i] == "/")
                {
                    devide = (Convert.ToDouble(operations[i - 1]) / Convert.ToDouble(operations[i + 1]));
                    operations[i] = devide.ToString();
                    operations.RemoveAt(i + 1);
                    operations.RemoveAt(i - 1);
                    i = 0;

                }
            }
            newOperations = operations;
        }

        public static double OperatingSumAndMinus(List<string> operations)
        {
            double sum, minus;
            double value = Convert.ToDouble(operations[0]);

            while (operations.Count >= 3)
            {
                if (operations[1].Equals("+"))
                {
                    sum = Convert.ToDouble(operations[0]) + Convert.ToDouble(operations[2]);
                    operations.RemoveAt(0);
                    operations.RemoveAt(0);
                    operations[0] = sum.ToString();
                    value = sum;
                }
                else
                {
                    minus = Convert.ToDouble(operations[0]) - Convert.ToDouble(operations[2]);
                    operations.RemoveAt(0);
                    operations.RemoveAt(0);
                    operations[0] = minus.ToString();
                    value = minus;
                }
            }

            return value;
        }

        public static double Count(string s)
        {
            List<string> operations = new List<string>();
            operations = Methods.SplitByOperators(s);

            Methods.OperatingProductAndDevision(operations, out operations);

            return Methods.OperatingSumAndMinus(operations);
        }
    }
}
