
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Soustraction : ExpressionBinaire<decimal>
    {
        public Soustraction(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 100;
        protected override decimal resoudre()
            => gauche.Resoudre() - droite.Resoudre();

    }
}
