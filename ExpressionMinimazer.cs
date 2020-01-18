using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class ExpressionMinimazer
    {
        string EarlyExpress;
        public string Result { get; set; }

        public ExpressionMinimazer()
        {
            EarlyExpress = "";
            Result = "";
        }

        //Минимизачия вводимого выражения 
        //С учетом его предыдущего состояния и результата этого состояния
        public string Minimize(string Expression)
        {
            if (Result == "" || Expression.Length < EarlyExpress.Length)
            {
                EarlyExpress = Expression;
                return Expression;
            }

            string NewPeice = Expression.Substring(EarlyExpress.Length, Expression.Length - 1);

            if (!StrIsNum(ref NewPeice))
            {
                NewPeice = Expression;
                Expression = Expression.Replace(EarlyExpress, Result);
                EarlyExpress = NewPeice;
            }

            return Expression;
        }


        private bool StrIsNum(ref string str)
        {
            for (byte i = 0; i < str.Length; i++)
                if (!Char.IsDigit(str[i])) return false;
            return true;
        }
    }
}
