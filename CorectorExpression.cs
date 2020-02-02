using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    //Класс отвечает за корретный ввод математического выражения
    //Парсинг выражения осуществляется с преположением что выражание 
    //введено по правилам этого класса
    class CorectorExpression
    {
        const string Digits = "1234567890";
        const string Operations = "+-*/^";
        const string Functions = "SinCosTanLnExp√—";
        const string Separators = "(),";

        public string Expression { get; private set; }

        public CorectorExpression()
        {
            Expression = "0";
        }




        //Добавить цифру в выражение
        public void AddDigit(char digit)
        {
            if(Expression == "0")
            {
                Expression = Expression.Replace('0', digit);
                return;
            }
            if(Expression[Expression.Length- 1] != ')')
            {
                Expression += digit;
            }
        }



        //Добавить в выражение операцию, типа Sin, Cos, √ и т.д.
        public void AddOperations(string operation)
        {
            if(Expression == "0")
            {
                Expression = operation;
                return;
            }
            if(Operations.Contains(Expression[Expression.Length - 1]) 
            || Functions.Contains(Expression[Expression.Length - 1]) 
            || Expression[Expression.Length - 1] == '(')
            {
                Expression += operation;
            }
        }



        //Добавить в выражение операцию, типа +, -, *, ^
        public void AddOperations(char operation)
        {
            if (Expression == "—") return;
            if(operation == '-')
            {
                if(Expression == "0")
                {
                    Expression = "—";
                    return;
                }
                else if(Functions.Contains(Expression[Expression.Length - 1]) || Expression[Expression.Length - 1] == '(')
                {
                    Expression += "—";
                    return;
                }
            }

            if (Operations.Contains(Expression[Expression.Length - 1]))
            {
                Expression = Expression.Remove(Expression.Length - 1);
                Expression += operation;
                return;
            }
            if(Digits.Contains(Expression[Expression.Length - 1]) 
            || Expression[Expression.Length - 1] == ')')
            {
                Expression += operation;
            }
        }



        //Дабавть скобку
        public void AddBracket(char bracket)
        {
            if(bracket == '(')
            {
                if(Expression == "0")
                {
                    Expression = "(";
                    return;
                }
                if(Operations.Contains(Expression[Expression.Length - 1])
                || Functions.Contains(Expression[Expression.Length - 1])
                || Expression[Expression.Length - 1] == bracket)
                {
                    Expression += bracket;
                }
            }
            else if(bracket == ')')
            {
                if(!CheckCloseBracket()) return;

                if(Digits.Contains(Expression[Expression.Length - 1])
                || Expression[Expression.Length - 1] == bracket)
                {
                    Expression += bracket;
                }
            }
        }
        //Проверка возможности поставить закрываюшую скобку
        //Проверка на совпадение кол-ва открывающих и закрывающих скобок
        bool CheckCloseBracket()
        {
            ushort open = 0, close = 0;
            for(ushort i = 0; i < Expression.Length; i++)
            {
                if(Expression[i] == '(') open++;
                else if (Expression[i] == ')') close++;
            }
            return (open > close) ? true : false;
        }



        //Добавить точку
        public void AddPoint()
        {
            if (Digits.Contains(Expression[Expression.Length - 1]))
                Expression += (!SecondPoint()) ? "," : "";
        }
        //Проверка чтобы не поставить вторую точку в числе
        bool SecondPoint()
        {
            for(int i = Expression.Length - 1; i >= 0; i--)
            {
                if (Expression[i] == ',') return true;
                if (!Digits.Contains(Expression[i])) break;
            }
            return false;
        }



        //Стереть последнюю цифру, операцию, функцию или разделитель
        public void Backspace()
         {
             ushort index = (ushort)(Expression.Length - 1);

             if(Functions.Contains(Expression[index]))
             {
                if(Expression.Substring(index) == "√" || Expression.Substring(index) == "—")
                    Expression = Expression.Remove(index, 1);
                else if (Expression.Substring(index - 1) == "Ln")
                    Expression = Expression.Remove(index - 1, 2);
                else
                    Expression = Expression.Remove(index - 2, 3);
            }
             else
                Expression = Expression.Remove(index, 1);

             if(Expression == "") Expression = "0";
         }



        //Проверить провильно ли введено выражение для поиска результата
        public bool RightExpressionDeep()
         {
            for (ushort i = 0; i < Expression.Length; i++)
            {
                if (!(Digits.Contains(Expression[i]) ||
                    Operations.Contains(Expression[i]) ||
                    Functions.Contains(Expression[i]) ||
                    Separators.Contains(Expression[i]))) return false;
            }

            string TempExpress = Expression;
            for (ushort i = 0; i < Digits.Length; i++)
                TempExpress = Expression.Replace(Digits[i], ' ');
            for (ushort i = 0; i < Operations.Length; i++)
                TempExpress = Expression.Replace(Operations[i], ' ');
            for (ushort i = 0; i < Separators.Length; i++)
                TempExpress = Expression.Replace(Separators[i], ' ');
            TempExpress = Expression.Replace("Sin", "");
            TempExpress = Expression.Replace("Cos", "");
            TempExpress = Expression.Replace("Tan", "");
            TempExpress = Expression.Replace("Ln", "");
            TempExpress = Expression.Replace("Exp", "");
            TempExpress = Expression.Replace('√', ' ');
            TempExpress = Expression.Replace('—', ' ');

            for (ushort i = 0; i < TempExpress.Length; i++)
                if (TempExpress[i] != ' ') return false;

            if (CheckCloseBracket()) return false;
             return (Digits.Contains(Expression[Expression.Length - 1]) || Expression[Expression.Length - 1] == ')')
             ?  true
             :  false;
         }
        //Проверить провильно ли введено выражение для поиска результата
        //(С учетом, что ввод осуществлялся с помощью этого класса)
        public bool RightExpression()
        {
            if (CheckCloseBracket()) return false;
            return (Digits.Contains(Expression[Expression.Length - 1]) || Expression[Expression.Length - 1] == ')')
            ? true
            : false;
        }
    }
}
