
namespace Parseur.Brainfuck
{
    internal class Lexeur
    {
        private string entree;
        public int Position { get; private set; }
        public bool ContientEncore { get => 0 <= Position && Position < entree.Length; }

        public void Initialiser(string entree)
        {
            this.entree = entree;
            Position = 0;
        }


        public char Pochain() => entree[Position++];
        


        public void TrouverCrochetPrecedant()
        {
            int positionInitiale = Position - 1;
            Position -= 2;
            int niveau = 1;
            while (ContientEncore && niveau > 0)
            {
                char c = entree[Position];
                if (c == ']')
                    niveau++;
                else if (c == '[')
                    niveau--;
                Position--;
            }

            if (ContientEncore == false)
                throw new ParseurException(
                    "Aucun crochet d'ouverture",
                    positionInitiale,
                    positionInitiale + 1
                );

            Position += 2;
        }

        public void TrouverCrochetSuivant()
        {
            int positionInitiale = Position - 1;
            int niveau = 1;
            while (ContientEncore && niveau > 0)
            {
                if (entree[Position] == '[')
                    niveau++;
                else if (entree[Position] == ']')
                    niveau--;
                Position++;
            }

            if (ContientEncore == false)
                throw new ParseurException(
                    "Aucun crochet de fermeture",
                    positionInitiale,
                    positionInitiale + 1
                );
        }
    }
}
