using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
////////////////////////////////
using static System.Math;

namespace Parser
{
    static class Parser
    {
        static string[] Operations = new string[12] 
        {"+", "-", "*", "/", "^", "√", "Sin", "Cos", "Tan", "Ln", "Exp", "—"};

        static string EarlyResult;
        static Minimize Min;
        public static CorectorExpression Correct { get; set; }

        static Parser()
        {
            EarlyResult = "0";
            Min = new Minimize();
            Correct = new CorectorExpression();
        }

        //Парсинг с простой проверкой выражения
        public static string ParsingExpression(string Expression)
        {
            if (Correct.RightExpression())
                EarlyResult = Parsing(Min.Minimized(Expression));

            return EarlyResult;
        }

        //Парсинг со сложной проверкой выражения
        public static string ParsingExpression(string Expression, char D)
        {
            if (D != Correct.Deep) return EarlyResult;

            if (Correct.RightExpressionDeep())
                EarlyResult = Parsing(Expression);

            return EarlyResult;
        }

        //Парсинг выражения(вернет результат)
        internal static string Parsing(string Expression)
        {
            DelBorder(ref Expression);

            if (Digit(ref Expression)) return Expression;

            string exp1 = "", exp2 = "";
            ref string operation = ref SearchInflectionPoint(ref Expression, ref exp1, ref exp2);

            exp1 = Parsing(exp1);
            exp2 = Parsing(exp2);

            return RunOperation(operation, Convert.ToSingle(exp1), Convert.ToSingle(exp2));
        }



        //Проверить если в выражении лишь одно число
        static bool Digit(ref string Expression)
        {
            string digit = "0123456789.";
            for (ushort i = 0; i < Expression.Length; i++)
                if (!digit.Contains(Expression[i])) return false;

            return true;
        }




        //Удаление лишних скобок в выражении
        static void DelBorder(ref string mainExp)
        {
            ushort NumberOpenBorder = 0,
            NumberCloseBorder = 0,
            StartIndex = 0,
            StopIndex = 0;

            for (ushort i = 0; i < mainExp.Length; i++)
                if (mainExp[i] == '(') NumberOpenBorder++;
                else
                {
                    StartIndex = i;
                    break;
                }
            if (NumberOpenBorder == 0) return;

            for (ushort i = (ushort)(mainExp.Length - 1); i >= 0; i--)
                if (mainExp[i] == ')') NumberCloseBorder++;
                else
                {
                    StopIndex = i;
                    break;
                }
            if (NumberCloseBorder == 0) return;

            ushort OpenBorderInside = 0;
            for (ushort i = StartIndex; i < StopIndex; i++)
            {
                if (mainExp[i] == '(') OpenBorderInside++;
                else if (mainExp[i] == ')')
                {
                    if (OpenBorderInside != 0) OpenBorderInside--;
                    else NumberOpenBorder--;
                }
                if (NumberOpenBorder == 0) return;
            }

            NumberCloseBorder -= OpenBorderInside;

            mainExp = mainExp.Remove(0, NumberOpenBorder);
            mainExp = mainExp.Remove(mainExp.Length - NumberCloseBorder, NumberCloseBorder);
        }




        //Поиск точки перегиба
        //(разрыв выражения на два поменьше, в месте с наименьшей по приоритету операцией)
        //Вернет два этих выражения
        static ref string SearchInflectionPoint(ref string mainExp, ref string exp1, ref string exp2)
        {
            for (ushort i = 0; i < 5; i++)
                for (ushort j = 0; j < mainExp.Length; j++)
                    if (Operations[i].Contains(mainExp[j]))
                        if (RightInflectionPoint(j, ref mainExp))
                        {
                            exp2 = mainExp.Substring(j + 1);
                            exp1 = mainExp.Substring(0, j);
                            return ref Operations[i];
                        }

            for (ushort i = 5; i < Operations.Length; i++)
                if (Operations[i].Contains(mainExp[0]))
                {
                    exp2 = (mainExp[0] == 'L') 
                        ? mainExp.Substring(2) 
                    : (mainExp[0] == '√' || mainExp[0] == '—') 
                        ? mainExp.Substring(1)
                        : mainExp.Substring(3);

                    exp1 = "0";
                    return ref Operations[i];
                }

            return ref Operations[0];
        }
            


        //Проверка правильности выбора точки перегиба для бинарной операции
        static bool RightInflectionPoint(ushort indOper, ref string mainExp)
        {
            ushort OpenBord = 0,
                    CloseBord = 0;
            for (ushort i = indOper; i < mainExp.Length; i++)
            {
                if (mainExp[i] == '(') OpenBord++;
                else if (mainExp[i] == ')') CloseBord++;
            }

            return (OpenBord == CloseBord) ? true : false;
        }


        //Выполнение опрации в зависимости от точки перегиба
        static string RunOperation(string oper, float exp1, float exp2)
        {
            if (oper == "+") return (exp1 + exp2).ToString();
            else if (oper == "-") return (exp1 - exp2).ToString();
            else if (oper == "*") return (exp1 * exp2).ToString();
            else if (oper == "/") return (exp2 == 0) ? "0" : (exp1 / exp2).ToString();
            else if (oper == "^") return Pow(exp1, exp2).ToString();
            else if (oper == "√") return (exp2 < 0) ? "0" : Sqrt(exp2).ToString();
            else if (oper == "Sin") return Sin(exp2).ToString();
            else if (oper == "Cos") return Cos(exp2).ToString();
            else if (oper == "Tan") return Tan(exp2).ToString();
            else if (oper == "Ln") return (exp2 < 0) ? "0" : Log(exp2).ToString();
            else if (oper == "—") return (-exp2).ToString();
            else return Exp(exp2).ToString();
        }
    }
}
