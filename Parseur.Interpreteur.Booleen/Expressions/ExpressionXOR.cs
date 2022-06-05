
namespace Parseur.Interpreteur.Booleen.Expressions
{
    internal class ExpressionXOR : ExpressionBinaire<bool>
    {
        public ExpressionXOR(int debut, int fin) 
            : base(debut, fin)
        {; }

        public override int Priorite => 100;
        protected override bool resoudre()
            => gauche.Resoudre() ^ droite.Resoudre();
    }
}
