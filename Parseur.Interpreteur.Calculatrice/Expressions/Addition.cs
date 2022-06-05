
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Addition : ExpressionBinaire<decimal>
    {
        public Addition(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 100;
        protected override decimal resoudre() => gauche.Resoudre() + droite.Resoudre();
    }
}
