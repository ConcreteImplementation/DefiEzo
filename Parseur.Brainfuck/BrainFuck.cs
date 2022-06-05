

namespace Parseur.Brainfuck
{
    public class BrainFuck : IParseur<string>, IErreurParseur
    {
        Lexeur lexeur;
        Donnees donnees;

        public IErreurParseur Erreur => new ErreurParseur(this);
        public string Message { get; private set;}
        public int Debut { get; private set;}
        public int Fin { get; private set;}


        public BrainFuck()
        {
            lexeur = new Lexeur();
            donnees = new Donnees();
        }
        public bool TryParse(string entree, out string resultat)
        {
            lexeur.Initialiser(entree);
            donnees.Initialiser();

            try
            {
                while (lexeur.ContientEncore)
                {
                    Fabriquer(lexeur.Pochain());
                }

                resultat = donnees.ToString();
                return true;
            }
            catch(ParseurException exception)
            {
                resultat = "";

                Message = exception.Message;
                Debut = exception.Debut;
                Fin = exception.Fin;

                return false;
            }

        }


        private void Fabriquer(char symbole)
        {
            switch (symbole)
            {
                case '+': donnees.Memoire++; break;
                case '-': donnees.Memoire--; break;
                case '>': donnees.Pointeur++; break;
                case '<': donnees.Pointeur--; break;

                case '.': donnees.Print(); break;

                case '[':
                    if (donnees.Memoire == 0)
                        lexeur.TrouverCrochetSuivant();
                    break;
                case ']':
                    if (donnees.Memoire != 0)
                        lexeur.TrouverCrochetPrecedant();
                    break;

                default:
                    throw new ParseurException("Symbole inconnu", lexeur.Position - 1, lexeur.Position);
            }
        }
    }
}