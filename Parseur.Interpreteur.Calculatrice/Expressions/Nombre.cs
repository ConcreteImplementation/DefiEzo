
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Nombre : ExpressionTerminale<decimal>
    {
        private decimal nombre;
        public Nombre(decimal nombre)
        {
            this.nombre = nombre;
        }


        public override int Priorite => int.MaxValue;
        public override decimal Resoudre() => nombre;
        

    }
}
