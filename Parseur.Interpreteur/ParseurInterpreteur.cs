namespace Parseur.Interpreteur
{
    public abstract class ParseurInterpreteur<T> : IParseur<T>
    {
        protected Lexeur lexeur;
        public ParseurInterpreteur(Lexeur lexeur)
        {
            this.lexeur = lexeur;
        }



        protected abstract IExpression<T> Factory(string lexeme);

        public T Resoudre(string entree) => Executer(entree).Resoudre();
        

        protected virtual IExpression<T> Executer(string entree)
        {
            try
            {
                lexeur.Initialiser(entree);
                string lexeme = lexeur.Prochain();
                IExpression<T> tete = Factory(lexeme);

                while(!lexeur.EstTermine())
                {
                    lexeme = lexeur.Prochain();
                    IExpression<T> expression = Factory(lexeme);
                    tete = tete.Ajouter(expression);
                }

                return tete;
            }
            catch(DivideByZeroException)
            {
                throw;
            }
            catch (ExceptionParseur)
            {
                throw new ExceptionParseur(lexeur.PositionPrecedente, lexeur.Position);
            }
            catch (ExceptionGrammaticale)
            {
                throw new ExceptionParseur(lexeur.PositionPrecedente, lexeur.Position);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}