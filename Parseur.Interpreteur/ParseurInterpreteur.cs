namespace Parseur.Interpreteur
{
    public abstract class ParseurInterpreteur<T> : IParseur<T>, IErreurParseur
    {
        protected Lexeur lexeur;
        protected ExpressionTypeEnum typeDerniereExpression;


        public IErreurParseur Erreur { get => new ErreurParseur(Message, Debut, Fin); }
        public string Message {get; private set;}
        public int Debut { get; private set; }
        public int Fin { get; private set; }



        public ParseurInterpreteur(Lexeur lexeur)
        {
            this.lexeur = lexeur;
            typeDerniereExpression = ExpressionTypeEnum.Nulle;

            Message = "Ok!";
            Debut = 0;
            Fin = 0;
        }



        protected abstract IExpression<T> Factory(string lexeme);



        //public T Resoudre(string entree) => Executer(entree).Resoudre();
        public bool TryParse(string entree, out T resultat)
        {
            try
            {
                resultat = Executer(entree).Resoudre();
                Fin = entree.Length - 1;
                return true;
            }
            catch (ParseurException exception)
            {
                resultat = default(T);

                Message = exception.Message;
                Debut = exception.Debut;
                Fin = exception.Fin;

                return false;
            }
        }
        protected virtual IExpression<T> Executer(string entree)
        {
            lexeur.Initialiser(entree);

            typeDerniereExpression = ExpressionTypeEnum.Nulle;
            IExpression<T> tete = prochaineExpression();

            while (lexeur.ContientEncore())
            {
                IExpression<T> expression = prochaineExpression();
                tete = tete.Ajouter(expression);
            }

            return tete;
        }

        private IExpression<T> prochaineExpression()
        {
            string lexeme = lexeur.Prochain();
            IExpression<T> expression = Factory(lexeme);
            typeDerniereExpression = expression.Type;
            return expression;
        }

        
    }
}