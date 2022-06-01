

namespace Parseur
{
    public abstract class ExpressionUnaire<T> : IExpression<T>
    {
        protected IExpression<T>? enfant;

        public abstract int Priorite { get; }
        public abstract T Resoudre();

        public virtual IExpression<T> Ajouter(IExpression<T> expression)
        {
            IExpression<T> tete = this;

            if (enfant == null)
                enfant = expression;
            else
            {
                expression.Ajouter(this);
                tete = expression;
            }
            

            return tete;
        }
    }
}
