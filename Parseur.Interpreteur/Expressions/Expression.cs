
namespace Parseur.Interpreteur
{
    public abstract class Expression<T> : IExpression<T>
    {
        public int Debut { get; }
        public int Fin { get; }

        public Expression(int debut, int fin)
        {
            Debut = debut;
            Fin = fin;
        }

        protected void LancerExceptionSyntaxique()
        {
            throw new ParseurException("Erreur syntaxique", Debut, Fin);
        }
        public abstract int Priorite { get;   }
        public abstract ExpressionTypeEnum Type { get; }
        public abstract IExpression<T> Ajouter(IExpression<T> expression);
        public abstract T Resoudre();
    }
}
