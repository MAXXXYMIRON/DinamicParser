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

        public Minimize() { Pieces = new List<(string Exp, string Res)>(); }

        public string Minimized(string Expression)
        {
            ChangeExpression(ref Expression);

            while (SearchPiecesInBoreder(ref Expression)) { }
            while (SearchPiecesInUnaryFunction(ref Expression)) { }

            return Expression;
        }

        private bool SearchPiecesInBoreder(ref string Expression)
        {
            string Piece = "";
            for (ushort i = 0; i < Expression.Length; i++)
            {
                if (Piece != "") Piece += Expression[i];

                if (Expression[i] == '(') Piece = Expression[i].ToString();

                if (Expression[i] == ')')
                {
                    Pieces.Add((Piece, Parser.Parsing(Piece)));
                    Expression = Expression.Replace(Piece, Pieces[Pieces.Count - 1].Res);
                    return true;
                }
            }
            return false;
        }

        private bool SearchPiecesInUnaryFunction(ref string Expression)
        {
            for (ushort i = 0; i < Expression.Length; i++)
            {

            }
            return false;
        }

        private void ChangeExpression(ref string Expression)
        {
            foreach (var item in Pieces)
                if (!Expression.Contains(item.Exp)) Pieces.Remove(item);
                else Expression = Expression.Replace(item.Exp, item.Res);
        }
    }
}
