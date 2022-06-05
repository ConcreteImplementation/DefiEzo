

namespace Parseur.Interpreteur
{
    public abstract class ExpressionUnaire<T> : Expression<T>
    {
        
        protected IExpression<T>? enfant;

        protected ExpressionUnaire(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite { get; }
        public override T Resoudre()
        {
            if (enfant == null)
                LancerExceptionSyntaxique();
            return resoudre();
        }
        protected abstract T resoudre();
        public override ExpressionTypeEnum Type { get => ExpressionTypeEnum.Unaire; }


        public override IExpression<T> Ajouter(IExpression<T> expression)
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
