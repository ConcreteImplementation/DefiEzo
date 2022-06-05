

namespace Parseur
{
    public class ErreurParseur : IErreurParseur
    {
        public string Message { get; }
        public int Debut { get; }
        public int Fin { get; }

        public ErreurParseur(string message, int debut, int fin)
        {
            Message = message;
            Debut = debut;
            Fin = fin;
        }
    }
}
