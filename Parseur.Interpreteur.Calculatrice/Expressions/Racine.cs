
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Racine : ExpressionUnaire<decimal>
    {
        public Racine(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 300;
        protected override decimal resoudre()
            => (decimal)Math.Sqrt((double)enfant.Resoudre());
    }
}
