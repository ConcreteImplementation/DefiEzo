
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Nombre : ExpressionTerminale<decimal>
    {
        private decimal nombre;
        public Nombre(decimal nombre, int debut, int fin):base(debut, fin)
        {
            this.nombre = nombre;
        }


        public override int Priorite => int.MaxValue;
        protected override decimal resoudre() 
            => nombre;
        

    }
}
