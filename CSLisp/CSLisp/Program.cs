using CSLisp.elements;
using CSLisp.parser;
using CSLisp.processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp
{
    class Program
    {
        private static readonly BasicLisp clisp = new BasicLisp();

        static void Main(string[] args)
        {
            test("(define sqrt (lambda (x)  (sqrt-iter 1.0 x)))");
            test("(define sqrt-iter (lambda (guess x)" +
                "  (if (good-enough? guess x)" +
                "                guess" +
                "                (sqrt-iter(improve-guess x)        " +
                "                           x))))");
            test("(define improve-guess (lambda (x) (average guess(/ x guess))))");
            test("(define average (lambda (x y) (/ (+ x y) 2)))");
            test("(define square (lambda (x) (* x x)))");
            test("(define abs (lambda (x) (if (< x 0) (- x) x)))");
            test("(define good-enough? (lambda (guess x)  (< (abs(-(square guess) x)) 0.001)))");
            test("(* (+ 11 2 ()) 15 (* 3 2) (* 3 0.5))");
            test("(* (+ 11 2) 15 (* 3 2) (* 3 0.5))");
            test("(define calc (lambda(a b)(+ a(* b 3))))");
            test("(calc 4 5)");
            test("(= 4 5)");
            test("(= q q)");
            test("(= (+ 15 7) 22)");
            test("(= (lambda(a b)(+ a(* q 7))) (lambda(a b)(+ a(* q 7))))");
            test("(if (= 1 0) \"blaat\" \"bloep\")");
            test(
                "(define fib " +
                "   (lambda (n) " +
                "       (if (= n 0) " +
                "           0 " +
                "           (if (= n 1) " +
                "               1 " +
                "               (+ " +
                "                   (fib (- n 2)) " +
                "                   (fib (- n 1))" +
                "               )" +
                "           )" +
                "       )" +
                "   )" +
                ")");

            test("(fib 0)");
            test("(fib 1)");
            test("(fib 2)");
            test("(fib 5)");
            //            test("(fib 15)");
            test("(sqrt 2)");
            test("((+ 1 2) (* 3 4))");
            test("(sqrt 5)");
            Console.ReadKey();
        }

        private static void test(string lisp)
        {
            IExpression expression = clisp.process(lisp);
            Console.WriteLine(expression);
        }
    }
}