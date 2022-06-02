
namespace Parseur.Interpreteur.Calculatrice
{
    internal class CompositeParenthese : ExpressionTerminale<decimal>
    {
        IExpression<decimal> enfant;
        public CompositeParenthese(IExpression<decimal> enfant)
        {
            this.enfant = enfant;
        }
        public override decimal Resoudre() => enfant.Resoudre();
    }
}
