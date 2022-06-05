
namespace Parseur.Interpreteur
{
    public abstract class ExpressionBinaire<T> : Expression<T>
    {
        protected IExpression<T>? gauche;
        protected IExpression<T>? droite;

        protected ExpressionBinaire(int debut, int fin) : base(debut, fin)
        {
        }

        public override ExpressionTypeEnum Type { get => ExpressionTypeEnum.Binaire; }

        public override int Priorite { get; }
        public override T Resoudre()
        {
            if (gauche == null || droite == null)
                LancerExceptionSyntaxique();
            return resoudre();
        }
        protected abstract T resoudre();

        public override IExpression<T> Ajouter(IExpression<T> expression)
        {
            if (gauche == null)
                gauche = expression;

            else if (Priorite < expression.Priorite)
                droite = droite == null
                    ? droite = expression
                    : droite = expression.Ajouter(droite);
            else
            {
                if (droite == null)
                    LancerExceptionSyntaxique();
                return expression.Ajouter(this);
            }

            return this;
        }
    }
}
