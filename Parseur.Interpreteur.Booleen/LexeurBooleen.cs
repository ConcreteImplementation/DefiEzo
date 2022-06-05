namespace Parseur.Interpreteur.Booleen
{
    internal class LexeurBooleen : Lexeur
    {
        public override string Prochain()
        {
            sauterBlanc();

            PositionPrecedente = Position;

            fabriquerNom();

            string prochain = entree.Substring(PositionPrecedente, Position - PositionPrecedente);
            return prochain;
        }
    }
}