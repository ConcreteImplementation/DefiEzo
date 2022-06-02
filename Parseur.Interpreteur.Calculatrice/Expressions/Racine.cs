
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Racine : ExpressionUnaire<decimal>
    {
        public override int Priorite => 300;
        public override decimal Resoudre() => (decimal)Math.Sqrt((double)enfant.Resoudre());
    }
}
