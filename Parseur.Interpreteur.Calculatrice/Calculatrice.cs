using System.Globalization;

namespace Parseur.Interpreteur.Calculatrice
{
    public class Calculatrice : ParseurInterpreteur<decimal>
    {
        public Calculatrice() : base(new LexeurCalculatrice())
        { ; }


        protected override IExpression<decimal> Factory(string lexeme)
        {
            IExpression<decimal> resultat;
            int debut = lexeur.PositionPrecedente;
            int fin = lexeur.Position;

            switch (lexeme)
            {
                case "1+1": resultat = new Nombre(1, debut, fin); break;
                case " ": resultat = new Nombre(0, debut, fin); break;
                case "+": resultat = new Addition(debut, fin); break;
                case "-":
                    resultat = 0 < (typeDerniereExpression & ExpressionTypeEnum.Terminal)
                        ? new Soustraction(debut, fin)
                        : new Negatif(debut, fin); 
                    break;
                case "*": resultat = new Multiplication(debut, fin); break;
                case "/": resultat = new Division(debut, fin); break;
                case "^": resultat = new Exposant(debut, fin); break;
                case "sqrt": resultat = new Racine(debut, fin); break;

                default:
                    decimal nombre = 0.0m;
                    lexeme = lexeme.Replace(',', '.');
                    if (tryParseDecimal(lexeme, out nombre))
                    {
                        resultat = new Nombre(nombre, debut, fin);
                        break;
                    }

                    if (lexeme.StartsWith('('))
                    {
                        if (lexeme.EndsWith(')') == false)
                            throw new ParseurException(
                                "Paranthèse incomplète",
                                lexeur.PositionPrecedente,
                                lexeur.Position
                            );
                        try
                        {
                            string formule = lexeme.Substring(1, lexeme.Length - 2);
                            resultat = new CompositeParenthese(new Calculatrice().Executer(formule), debut, fin);
                            break;
                        }
                        catch (ParseurException ex)
                        {
                            throw new ParseurException(
                                ex.Message,
                                lexeur.PositionPrecedente + ex.Debut + 1,
                                lexeur.PositionPrecedente + ex.Fin + 1
                            );
                        }
                    }


                    throw new ParseurException(
                        "Symbole inconnue",
                        lexeur.PositionPrecedente,
                        lexeur.Position
                    );
            }

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