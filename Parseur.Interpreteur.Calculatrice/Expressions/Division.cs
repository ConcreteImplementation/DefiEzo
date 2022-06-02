
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Division : ExpressionBinaire<decimal>
    {
        public override int Priorite => 200;
        public override decimal Resoudre() => gauche.Resoudre() / droite.Resoudre();
    }
}
