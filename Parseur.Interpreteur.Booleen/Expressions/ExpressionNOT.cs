

namespace Parseur.Interpreteur.Booleen.Expressions
{
    internal class ExpressionNOT : ExpressionUnaire<bool>
    {
        public ExpressionNOT(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 200;
        protected override bool resoudre()
            => !enfant.Resoudre();
    }
}
