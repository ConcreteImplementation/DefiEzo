using System.Text;

namespace Parseur.Brainfuck
{
    internal class Donnees
    {
        private StringBuilder chaine;
        private byte[] memoire;
        public int Pointeur { get; set; }
        public byte Memoire
        {
            get => memoire[Pointeur];
            set => memoire[Pointeur] = value;
        }


        public Donnees()
        {
            Initialiser();
        }

        public void Initialiser()
        {
            chaine = new StringBuilder();
            memoire = new byte[256];
            Pointeur = 0;
        }
       public void Print()
        {
            chaine.Append((char)memoire[Pointeur]);
        }

        public override string ToString()
        {
            return chaine.ToString();
        }
    }
}
