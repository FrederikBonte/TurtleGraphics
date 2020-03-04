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
    public class BasicLisp
    {
        private readonly Scope scope;

        public BasicLisp()
        {
            this.scope = createBasicScope();
        }

        public IExpression process(string lisp)
        {
            ExpressionParser parser = new ExpressionParser(lisp);
            ParseResult parsed = parser.parse();
            return process(parsed.expression);
        }

        public IExpression process(IExpression expression)
        {
            return scope.evaluate(expression);
        }

        public static Scope createBasicScope()
        {
            Scope result = new Scope();

            result.register(new VariableEvaluator());
            result.register(new LambdaEvaluator());

            result.register(new IfApplicator());
            result.register(new SubtractApplicator());
            result.register(new MultiplyApplicator());
            result.register(new DivideApplicator());
            result.register(new AddApplicator());
            result.register(new DefineApplicator());
            result.register(new LessThanApplicator());
            result.register(new EqualsApplicator());
            result.register(new DefinitionApplicator());

            return result;
        }
    }
}
