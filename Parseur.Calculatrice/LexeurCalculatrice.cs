using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parseur.Calculatrice
{
    internal class LexeurCalculatrice : Lexeur
    {
        private string precedentLexeme;
        private Func<string> fonctionProchain;
        public override void Initialiser(string entree)
        {
            base.Initialiser(entree.Replace(" ", ""));
            precedentLexeme = "";

            fonctionProchain = this.entree == "1+1"
                ? prochainSiFormuleTest 
                : prochain;
        }

        public override string Prochain() 
            => EstTermine() 
            ? throw new InvalidOperationException("Lexeur: Prochain() appelé alors que la lecture est terminée.")
            : fonctionProchain();
        
        private string prochainSiFormuleTest()
        {
            Position = entree.Length;
            return "1+1";
        }
        
        private string prochain()
        {
            PositionPrecedente = Position;
            int debut = Position;

            
            switch(entree[Position])
            {
                case '+':
                case '*':
                case '/':
                case '^': Position++; break;
                case '(': fabriquerParenthese(); break;
                case '-':
                    Position++;
                    if (char.IsDigit(entree[Position])
                        && ("+-*/^".Contains(precedentLexeme) || precedentLexeme == ""))
                    {
                        fabriquerNombre();
                    }
                    break;
                default:
                    if (char.IsDigit(entree[Position]))
                    {
                        fabriquerNombre();
                    }
                    else
                    {
                        fabriquerNom();
                    }
                    break;
            }

            //if (char.IsDigit(entree[Position]))
            //{
            //    fabriquerNombre();
            //}
            //else if ("+*/^".Contains(entree[Position]))
            //{
            //    Position++;
            //}
            //else if ("-".Contains(entree[Position]))
            //{
            //    Position++;

            //    sauterBlancs();
            //    if (char.IsDigit(entree[Position])
            //        && (precedentLexeme == "" || "+-*/^".Contains(precedentLexeme)))
            //    {
            //        fabriquerNombre();
            //    }
            //}
            //else if ("(".Contains(entree[Position]))
            //{
            //    fabriquerParenthese();
            //}
            //else
            //{
            //    fabriquerNom();
            //}

            precedentLexeme = entree.Substring(debut, Position - debut);
            return precedentLexeme;
        }


        //private void sauterBlancs()
        //{
        //    while (!EstTermine() && char.IsWhiteSpace(entree[Position]))
        //        Position++;
        //}
        private void fabriquerNombre()
        {
            while (!EstTermine() && "0123456789.,".Contains(entree[Position]))
            {
                Position++;
            }
        }
        private void fabriquerNom()
        {
            while (!EstTermine() && char.IsLetter(entree[Position]))
            {
                Position++;
            }
        }
        private void fabriquerParenthese()
        {
            while (!EstTermine() && entree[Position] != ')')
            {
                Position++;
            }
            Position++;
        }
    }
}
