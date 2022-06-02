
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Exposant : ExpressionBinaire<decimal>
    {
        public override int Priorite => 300;
        public override decimal Resoudre() => (decimal)Math.Pow((double)gauche.Resoudre(), (double)droite.Resoudre());
    }
}
