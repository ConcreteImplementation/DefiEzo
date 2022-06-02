

namespace Parseur.Interpreteur
{
    public abstract class ExpressionUnaire<T> : IExpression<T>
    {
        protected IExpression<T>? enfant;

        public abstract int Priorite { get; }
        public ExpressionTypeEnum Type { get => ExpressionTypeEnum.Unaire; }
        public abstract T Resoudre();

        public virtual IExpression<T> Ajouter(IExpression<T> expression)
        {
            if (enfant == null)
                enfant = expression;
            else if (Priorite < expression.Priorite)
                enfant.Ajouter(expression);
            else
                return expression.Ajouter(this);

            return this;
        }
    }
}
