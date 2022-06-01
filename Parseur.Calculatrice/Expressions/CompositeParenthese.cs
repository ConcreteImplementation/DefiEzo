
namespace Parseur.Calculatrice
{
    internal class CompositeParenthese : ExpressionUnaire<decimal>
    {
        public override int Priorite => 1;
        public override decimal Resoudre() => enfant.Resoudre();
    }
}
