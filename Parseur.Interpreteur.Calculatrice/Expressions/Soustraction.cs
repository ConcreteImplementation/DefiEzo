
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Soustraction : ExpressionBinaire<decimal>
    {
        public override int Priorite => 100;
        public override decimal Resoudre() => gauche.Resoudre() - droite.Resoudre();

    }
}
