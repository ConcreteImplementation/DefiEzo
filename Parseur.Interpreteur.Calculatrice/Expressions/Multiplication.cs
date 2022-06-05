
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Multiplication : ExpressionBinaire<decimal>
    {
        public Multiplication(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 200;
        protected override decimal resoudre() 
            => gauche.Resoudre() * droite.Resoudre();
    }
}
