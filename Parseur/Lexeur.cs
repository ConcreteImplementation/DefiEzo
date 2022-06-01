
namespace Parseur
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
    }
}
