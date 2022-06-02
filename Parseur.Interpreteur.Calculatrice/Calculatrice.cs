using System.Globalization;

using Parseur.Interpreteur;

namespace Parseur.Interpreteur.Calculatrice
{
    public class Calculatrice : ParseurInterpreteur<decimal>
    {
        ExpressionTypeEnum typeDerniereExpression;
        public Calculatrice() : base(new LexeurCalculatrice())
        {
            typeDerniereExpression = ExpressionTypeEnum.Nulle;
        }



        protected override IExpression<decimal> Factory(string lexeme)
        {
            IExpression<decimal> resultat;

            switch (lexeme)
            {
                case "1+1": resultat = new Nombre(1); break;
                case "+": resultat = new Addition(); break;
                case "-":
                    resultat = 0 < (typeDerniereExpression & ExpressionTypeEnum.Terminal)
                        ? new Soustraction()
                        : new Negatif(); 
                    break;
                case "*": resultat = new Multiplication(); break;
                case "/": resultat = new Division(); break;
                case "^": resultat = new Exposant(); break;
                case "sqrt": resultat = new Racine(); break;

                default:
                    if (lexeme.StartsWith('(') && lexeme.EndsWith(')'))
                    {
                        try
                        {
                            string formule = lexeme.Substring(1, lexeme.Length - 2);
                            resultat = new CompositeParenthese(new Calculatrice().Executer(formule));
                            break;
                        }
                        catch(ErreurParseurException exception)
                        {
                            int debut = lexeur.PositionPrecedente + exception.Debut;
                            int fin = lexeur.PositionPrecedente + exception.Fin;
                            throw new ErreurParseurException(debut, fin);
                        }
                    }

                    decimal nombre = 0.0m;
                    if (tryParseDecimal(lexeme, out nombre))
                    {
                        resultat = new Nombre(nombre);
                        break;
                    }
                    
                    throw new ErreurGrammaticaleException(
                        "Aucun jeton trouvé dans Calculatrice.Factory()", lexeme
                    );
            }

            typeDerniereExpression = resultat.Type;
            return resultat;
        }

        private bool tryParseDecimal(string chaine, out decimal nombre)
            => decimal.TryParse(
                chaine, 
                NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, 
                new CultureInfo("en-CA"), 
                out nombre
            );

    }
}