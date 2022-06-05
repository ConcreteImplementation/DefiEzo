
namespace Parseur.Interpreteur
{
    public interface IExpression<T>
    {
        public int Debut { get; }
        public int Fin { get; }
        public int Priorite { get; }
        public ExpressionTypeEnum Type { get; }
        public IExpression<T> Ajouter(IExpression<T> expression);
        public T Resoudre();
    }
}
