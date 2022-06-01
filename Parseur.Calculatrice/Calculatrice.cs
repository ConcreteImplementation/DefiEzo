using System.Globalization;

using Parseur;

namespace Parseur.Calculatrice
{
    public class Calculatrice : Parseur<decimal>
    {
        public Calculatrice() : base(new LexeurCalculatrice())
        {
            ;
        }



        protected override IExpression<decimal> Factory(string lexeme)
        {
            switch (lexeme)
            {
                case "1+1": return new Nombre(1);
                case "+": return new Addition();
                case "-": return new Soustraction();
                case "*": return new Multiplication();
                case "/": return new Division();
                case "^": return new Exposant();
                case "sqrt": return new Racine();

                default:
                    if(lexeme.StartsWith('(') && lexeme.EndsWith(')'))
                    {
                        try
                        {
                            string formule = lexeme.Substring(1, lexeme.Length - 2);
                            return new CompositeParenthese().Ajouter(new Calculatrice().Executer(formule));
                        }
                        catch(ErreurParseurException)
                        {
                            throw new ErreurParseurException(lexeur.PositionPrecedente, lexeur.Position);
                        }
                    }

                    decimal nombre = 0.0m;
                    if (decimal.TryParse(lexeme, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, new CultureInfo("en-CA"), out nombre))
                    {
                        return new Nombre(nombre);
                    }

                    throw new ErreurGrammaticaleException(
                        "Aucun jeton trouvé dans Calculatrice.Factory()", lexeme
                    );

            }
        }
    }
}