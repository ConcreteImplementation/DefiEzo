
namespace Parseur.Interpreteur
{
    public abstract class ExpressionTerminale<T> : IExpression<T>
    {
        public virtual int Priorite => int.MaxValue;
        public ExpressionTypeEnum Type { get => ExpressionTypeEnum.Terminal; }
        public virtual IExpression<T> Ajouter(IExpression<T> expression)
        {
            if (expression.Priorite >= this.Priorite)
                throw new ErreurSyntaxiqueException("Tentative d'ajout à une expression feuille.");

            return expression.Ajouter(this);
        }
        
        public abstract T Resoudre();
    }
}
