namespace Parseur
{
    public abstract class Parseur<T>
    {
        protected Lexeur lexeur;
        public Parseur(Lexeur lexeur)
        {
            this.lexeur = lexeur;
        }



        protected abstract IExpression<T> Factory(string lexeme);


        public IExpression<T> Executer(string entree)
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
            catch (ErreurParseurException)
            {
                throw new ErreurParseurException(lexeur.PositionPrecedente, lexeur.Position);
            }
            catch (ErreurGrammaticaleException)
            {
                throw new ErreurParseurException(lexeur.PositionPrecedente, lexeur.Position);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}