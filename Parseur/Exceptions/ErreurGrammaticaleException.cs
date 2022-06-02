﻿
namespace Parseur
{
    public class ErreurGrammaticaleException : Exception
    {
        public ErreurGrammaticaleException(string lexeme)
            :base($"Le lexème «{lexeme}» n'est pas reconnu.")
        {
            ;
        }
        public ErreurGrammaticaleException(string message, string lexeme)
            : base($"{message}. «{lexeme}» n'est pas reconnu.")
        {
            ;
        }
    }
}
