
namespace Parseur
{
    public interface IExpression<T>
    {
        public int Priorite { get; }
        public IExpression<T> Ajouter(IExpression<T> expression);
        public T Resoudre();
    }
}
