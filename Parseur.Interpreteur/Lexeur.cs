
namespace Parseur.Interpreteur
{
    public abstract class Lexeur
    {
        protected string entree;

        public int Position { get; protected set;  }
        public int PositionPrecedente { get; protected set; }

        public bool EstTermine() => Position >= entree.Length;
        public Lexeur()
        {
            entree = "";
        }
        public virtual void Initialiser(string entree)
        {
            this.entree = entree.Trim();
            Position = 0;
            PositionPrecedente = 0;
        }

        abstract public string Prochain();



        protected void fabriquerNombre()
        {
            while (!EstTermine() && "0123456789.,".Contains(entree[Position]))
            {
                Position++;
            }
        }
        protected void fabriquerNom()
        {
            while (!EstTermine() && char.IsLetter(entree[Position]))
            {
                Position++;
            }
        }
        protected void fabriquerParenthese()
        {
            int niveau = 1;
            while (!EstTermine() && niveau > 0)
            {
                Position++;
                if (entree[Position] == '(')
                    niveau++;
                else if (entree[Position] == ')')
                    niveau--;
            }
            Position++;
        }
    }
}
