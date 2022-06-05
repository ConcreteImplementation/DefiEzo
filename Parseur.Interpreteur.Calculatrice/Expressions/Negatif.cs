
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Negatif : ExpressionUnaire<decimal>
    {
        public Negatif(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => int.MaxValue-100;

        protected override decimal resoudre()
            =>  - enfant.Resoudre();
    }
}
