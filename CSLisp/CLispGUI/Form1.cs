using CSLisp;
using CSLisp.elements;
using CSLisp.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLispGUI
{
    public partial class Form1 : Form
    {
        BasicLisp blisp = new BasicLisp();

        public Form1()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            if (e.Control)
            {
                return;
            }

            enter(txtInput.Text);
        }

        private void enter(string command) { 
            ExpressionParser parser = new ExpressionParser(command);
            try
            {
                ParseResult parsed = parser.parse();
                lstHistory.Items.Add(parsed.expression);
                txtOutput.Text = ""+blisp.process(parsed.expression);
            } catch (ParseException pe)
            {
                txtOutput.Text = "Failed to parse "+command+":\n\r"+pe.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enter("(define sqrt (lambda (x)  (sqrt-iter 1.0 x)))");
            enter("(define sqrt-iter (lambda (guess x)" +
                "  (if (good-enough? guess x)" +
                "                guess" +
                "                (sqrt-iter(improve-guess x)        " +
                "                           x))))");
            enter("(define improve-guess (lambda (x) (average guess(/ x guess))))");
            enter("(define average (lambda (x y) (/ (+ x y) 2)))");
            enter("(define square (lambda (x) (* x x)))");
            enter("(define abs (lambda (x) (if (< x 0) (- x) x)))");
            enter("(define good-enough? (lambda (guess x)  (< (abs(-(square guess) x)) 0.001)))");
            enter("(define cons (lambda (head tail) (lambda (x) (if (= x 0) head tail))))");
            enter("(define car (lambda (cons) (cons 0)))");
            enter("(define cdr (lambda (cons) (cons 1)))");
            enter(
    "(define fib " +
    "   (lambda (q) " +
    "       (if (= q 0) " +
    "           0 " +
    "           (if (= q 1) " +
    "               1 " +
    "               (+ " +
    "                   (fib (- q 2)) " +
    "                   (fib (- q 1))" +
    "               )" +
    "           )" +
    "       )" +
    "   )" +
    ")");
/*            enter("" +
                "(define get_element (lambda (n list) " +
                "   (if (= n 0) " +
                "       (get_first list) " +
                "       (get_element (- n 1) (get_tail list)))");*/
        }

        private void lstHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtOutput.Text = blisp.process((IExpression)lstHistory.SelectedItem).ToString();
        }

        private void lstHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void lstHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOutput.Text = blisp.process((IExpression)lstHistory.SelectedItem).ToString();
            }
        }
    }
}
