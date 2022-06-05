
namespace Parseur.Interpreteur.Calculatrice
{
    internal class Division : ExpressionBinaire<decimal>
    {
        public Division(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 200;
        protected override decimal resoudre()
        {
            decimal resultatDroite = droite.Resoudre();
            if (resultatDroite == 0)
                throw new ParseurException("Division par zéro", droite.Debut, droite.Fin);



            return gauche.Resoudre() / resultatDroite;
        }
    }
}
