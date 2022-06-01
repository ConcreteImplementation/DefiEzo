
namespace Parseur.Calculatrice
{
    internal class Addition : ExpressionBinaire<decimal>
    {
        public override int Priorite => 1;
        public override decimal Resoudre() => gauche.Resoudre() + droite.Resoudre();
    }
}
