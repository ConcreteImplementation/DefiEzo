
namespace Parseur.Interpreteur
{
    public abstract class ExpressionTerminale<T> : Expression<T>
    {
        protected ExpressionTerminale(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => int.MaxValue;
        public override ExpressionTypeEnum Type { get => ExpressionTypeEnum.Terminal; }
        public override IExpression<T> Ajouter(IExpression<T> expression)
        {
            if (expression.Priorite >= this.Priorite)
                LancerExceptionSyntaxique();

            return expression.Ajouter(this);
        }

        public override T Resoudre() => resoudre();
        
        protected abstract T resoudre();
    }
}
