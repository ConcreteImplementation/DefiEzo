
namespace Parseur
{
    public class ExceptionGrammaticale : Exception
    {
        public ExceptionGrammaticale(string lexeme)
            :base($"Le lexème «{lexeme}» n'est pas reconnu.")
        {
            ;
        }
        public ExceptionGrammaticale(string message, string lexeme)
            : base($"{message}. «{lexeme}» n'est pas reconnu.")
        {
            ;
        }
    }
}
