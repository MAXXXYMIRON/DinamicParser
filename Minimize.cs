using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Minimize
    {
        List<(string Exp, string Res)> Pieces;
        const string Func = "SCTLE√";
        const string Oper = "+-*/^";

        public Minimize() { Pieces = new List<(string Exp, string Res)>(); }

        public string Minimized(string Expression)
        {
            ChangeExpression(ref Expression);

            while (SearchPiecesInBoreder(ref Expression)) { }
            SearchPiecesInUnaryFunction(ref Expression);

            return Expression;
        }

        private bool SearchPiecesInBoreder(ref string Expression)
        {
            string Piece = "";
            for (ushort i = 0; i < Expression.Length; i++)
            {
                Piece += Expression[i];
                if (Expression[i] == '(') Piece = Expression[i].ToString();

                if (Expression[i] == ')')
                {
                    Pieces.Add((Piece, Parser.Parsing(Piece).Replace('-', '—')));
                    Expression = Expression.Replace(Piece, Pieces[Pieces.Count - 1].Res);
                    return true;
                }
            }
            return false;
        }

        private void SearchPiecesInUnaryFunction(ref string Expression)
        {
            string Piece = "";
            for (ushort i = 0; i < Expression.Length; i++)
                if (Func.Contains(Expression[i]))
                {
                    Piece = Expression.Substring(i);
                    for (int j = 0; j < Oper.Length; j++)
                        Piece = (Piece.IndexOf(Oper[j]) < 0) ? Piece : Piece.Remove(Piece.IndexOf(Oper[j]));

                    Pieces.Add((Piece, Parser.Parsing(Piece).Replace('-', '—')));
                    Expression = Expression.Replace(Piece, Pieces[Pieces.Count - 1].Res);
                }
        }

        private void ChangeExpression(ref string Expression)
        {

            for (ushort i = 0; i < Pieces.Count; i++)
            {
                if (!Expression.Contains(Pieces[i].Exp)) Pieces.Remove(Pieces[i]);
                else Expression = Expression.Replace(Pieces[i].Exp, Pieces[i].Res); 
            }
        }
    }
}
