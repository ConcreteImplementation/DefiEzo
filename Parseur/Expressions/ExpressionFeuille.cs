
namespace Parseur
{
    public abstract class ExpressionFeuille<T> : IExpression<T>
    {
        public virtual int Priorite => int.MaxValue;

        public virtual IExpression<T> Ajouter(IExpression<T> expression)
        {
            if ((expression.Priorite >= this.Priorite))
                throw new ErreurSyntaxiqueException("Tentative d'ajout à une expression feuille.");

            expression.Ajouter(this);
            return expression;
        }
        
        public abstract T Resoudre();
    }
}
