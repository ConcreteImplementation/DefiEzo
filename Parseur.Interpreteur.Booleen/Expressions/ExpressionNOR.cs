
namespace Parseur.Interpreteur.Booleen.Expressions
{
    internal class ExpressionNOR : ExpressionBinaire<bool>
    {
        public ExpressionNOR(int debut, int fin) : base(debut, fin)
        {; }

        public override int Priorite => 100;
        protected override bool resoudre()
            => !(gauche.Resoudre() || droite.Resoudre());
    }
}
