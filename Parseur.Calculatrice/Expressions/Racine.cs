
namespace Parseur.Calculatrice
{
    internal class Racine : ExpressionUnaire<decimal>
    {
        public override int Priorite => 3;
        public override decimal Resoudre() => (decimal)Math.Sqrt((double)enfant.Resoudre());
    }
}
