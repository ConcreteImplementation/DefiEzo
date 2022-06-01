
namespace Parseur
{
    public abstract class ExpressionBinaire<T> : IExpression<T>
    {
        protected IExpression<T>? gauche;
        protected IExpression<T>? droite;

        public abstract int Priorite { get; }
        public abstract T Resoudre();

        public virtual IExpression<T> Ajouter(IExpression<T> expression)
        {
            IExpression<T> tete = this;

            if (gauche == null)
                gauche = expression;
            else if (expression.Priorite <= this.Priorite)
            {
                expression.Ajouter(this);
                tete = expression;
            }
            
            else if 
                (droite == null)
                 droite = expression;
            else if 
                (expression.Priorite > droite.Priorite)
                droite.Ajouter(expression);
            else 
                droite = expression.Ajouter(droite);

            return tete;
        }
    }
}
