
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Negatif : ExpressionUnaire<decimal>
    {
        
        public override int Priorite => int.MaxValue-100;

        public override decimal Resoudre() =>  - enfant.Resoudre();
    }
}
