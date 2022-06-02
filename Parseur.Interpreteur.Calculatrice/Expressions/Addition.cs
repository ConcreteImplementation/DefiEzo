
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Addition : ExpressionBinaire<decimal>
    {
        public override int Priorite => 100;
        public override decimal Resoudre() => gauche.Resoudre() + droite.Resoudre();
    }
}
