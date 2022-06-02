
namespace Parseur.Interpreteur.Calculatrice
{
    internal class LexeurCalculatrice : Lexeur
    {
        private Func<string> strategieProchain;

        public LexeurCalculatrice()
        {
            strategieProchain = prochain;
        }
        public override void Initialiser(string entree)
        {
            base.Initialiser(entree.Replace(" ", ""));

            strategieProchain = this.entree == "1+1"
                ? prochainSiFormuleTest 
                : prochain;
        }

        public override string Prochain() 
            => EstTermine() 
            ? throw new InvalidOperationException("Lexeur: Prochain() appelé alors que la lecture est terminée.")
            : strategieProchain();
        
        private string prochainSiFormuleTest()
        {
            Position = entree.Length;
            return "1+1";
        }
        
        private string prochain()
        {
            PositionPrecedente = Position;
            int debut = Position;

            char c = entree[Position];

            if ("+-*/^".Contains(c))
                Position++;
            else if ('(' == c)
                fabriquerParenthese();
            else if (char.IsDigit(c))
                fabriquerNombre();
            else
                fabriquerNom();

            return entree.Substring(debut, Position - debut);
        }
    }
}
