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

        public ExpressionMinimazer() { }

        //Минимизачия вводимого выражения 
        //С учетом его предыдущего состояния и результата этого состояния
        public string Minimize(string Expression)
        {
            if (Result == "") return Expression;



            return Expression;
        }
    }
}
