
namespace Parseur.Calculatrice
{
    internal class Exposant : ExpressionBinaire<decimal>
    {
        public override int Priorite => 3;
        public override decimal Resoudre() => (decimal)Math.Pow((double)gauche.Resoudre(), (double)droite.Resoudre());
    }
}
