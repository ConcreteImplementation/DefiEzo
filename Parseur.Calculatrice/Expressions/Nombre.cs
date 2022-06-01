
namespace Parseur.Calculatrice
{
    internal class Nombre : ExpressionFeuille<decimal>
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
