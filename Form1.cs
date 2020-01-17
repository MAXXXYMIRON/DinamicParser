using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class Win : Form
    {
        public Win()
        {
            InitializeComponent();
        }

        private void Win_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '0')
            {
                Parser.Correct.AddDigit('0');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression); 
            }
            else if(e.KeyChar == '1')
            {
                Parser.Correct.AddDigit('1');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '2')
            {
                Parser.Correct.AddDigit('2');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '3')
            {
                Parser.Correct.AddDigit('3');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '4')
            {
                Parser.Correct.AddDigit('4');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '5')
            {
                Parser.Correct.AddDigit('5');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '6')
            {
                Parser.Correct.AddDigit('6');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '7')
            {
                Parser.Correct.AddDigit('7');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '8')
            {
                Parser.Correct.AddDigit('8');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '9')
            {
                Parser.Correct.AddDigit('9');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '+')
            {
                Parser.Correct.AddOperations('+');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '-')
            {
                Parser.Correct.AddOperations('-');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '*')
            {
                Parser.Correct.AddOperations('*');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '/')
            {
                Parser.Correct.AddOperations('/');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '^')
            {
                Parser.Correct.AddOperations('^');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == 'q' || e.KeyChar == 'Q' || e.KeyChar == 'й' || e.KeyChar == 'Й')
            {
                Parser.Correct.AddOperations("√");
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'S' || e.KeyChar == 'ы' || e.KeyChar == 'Ы')
            {
                Parser.Correct.AddOperations("Sin");
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == 'c' || e.KeyChar == 'C' || e.KeyChar == 'с' || e.KeyChar == 'С')
            {
                Parser.Correct.AddOperations("Cos");
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == 't' || e.KeyChar == 'T' || e.KeyChar == 'н' || e.KeyChar == 'Н')
            {
                Parser.Correct.AddOperations("Tan");
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == 'l' || e.KeyChar == 'L' || e.KeyChar == 'д' || e.KeyChar == 'Д')
            {
                Parser.Correct.AddOperations("Ln");
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == 'e' || e.KeyChar == 'E' || e.KeyChar == 'у' || e.KeyChar == 'У')
            {
                Parser.Correct.AddOperations("Exp");
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '(')
            {
                Parser.Correct.AddBracket('(');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == ')')
            {
                Parser.Correct.AddBracket(')');
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == '.')
            {
                Parser.Correct.AddPoint();
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
            else if (e.KeyChar == 08)
            {
                Parser.Correct.Backspace();
                LabelExpression.Text = Parser.Correct.Expression;

                LabelResult.Text = Parser.ParsingExpression(Parser.Correct.Expression);
            }
        }
    }
}
