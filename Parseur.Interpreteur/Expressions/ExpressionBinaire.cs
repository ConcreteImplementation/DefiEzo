
namespace Parseur.Interpreteur
{
    public abstract class ExpressionBinaire<T> : IExpression<T>
    {
        protected IExpression<T>? gauche;
        protected IExpression<T>? droite;

        public ExpressionTypeEnum Type { get => ExpressionTypeEnum.Binaire; }
        public abstract int Priorite { get; }
        
        public abstract T Resoudre();

        public virtual IExpression<T> Ajouter(IExpression<T> expression)
        {
            if (gauche == null)
                gauche = expression;

            else if (Priorite < expression.Priorite)
                droite = droite == null
                    ? droite = expression
                    : droite = expression.Ajouter(droite);
            else
                return expression.Ajouter(this);

            return this;
        }
    }
}
