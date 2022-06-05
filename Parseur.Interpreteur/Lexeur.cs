
namespace Parseur.Interpreteur
{
    public abstract class Lexeur
    {
        protected string entree;


        public int Position { get; protected set;  }
        public int PositionPrecedente { get; protected set; }
        public bool ContientEncore() => Position < entree.Length;


        public Lexeur()
        {
            entree = "";
        }


        abstract public string Prochain();
        
        public virtual void Initialiser(string entree)
        {
            this.entree = entree.Trim();
            Position = 0;
            PositionPrecedente = 0;
        }



        protected void sauterBlanc()
        {
            while (ContientEncore() && char.IsWhiteSpace(entree[Position]))
            {
                Position++;
            }
        }
        protected void fabriquerNombre()
        {
            while (ContientEncore() && "0123456789.,".Contains(entree[Position]))
            {
                Position++;
            }
        }
        protected void fabriquerNom()
        {
            while (ContientEncore() && char.IsLetter(entree[Position]))
            {
                Position++;
            }
        }
        protected void fabriquerParenthese()
        {
            int niveau = 1;
            Position++;

            while (ContientEncore() && niveau > 0)
            {
                if (entree[Position] == '(')
                    niveau++;
                else if (entree[Position] == ')')
                    niveau--;
                Position++;
            }
        }
    }
}
