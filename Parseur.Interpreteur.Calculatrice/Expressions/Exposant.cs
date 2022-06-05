
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Exposant : ExpressionBinaire<decimal>
    {
        public Exposant(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 300;
        protected override decimal resoudre() 
            => (decimal)Math.Pow((double)gauche.Resoudre(), (double)droite.Resoudre());
    }
}
