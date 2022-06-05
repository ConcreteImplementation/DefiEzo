
namespace Parseur.Interpreteur.Calculatrice
{
    internal class CompositeParenthese : ExpressionTerminale<decimal>
    {
        IExpression<decimal> enfant;
        public CompositeParenthese(IExpression<decimal> enfant, int debut, int fin): base(debut, fin)
        {
            this.enfant = enfant;
        }
        protected override decimal resoudre()
        {
            try
            {
                return enfant.Resoudre();
            }
            catch (ParseurException ex)
            {
                throw new ParseurException(
                    ex.Message,
                    Debut + ex.Debut + 1,
                    Debut + ex.Fin + 1
                );
            }
        }
    }
}
