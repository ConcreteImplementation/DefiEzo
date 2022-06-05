using System.Reflection;

using Parseur.Interpreteur;

namespace Parseur.Interpreteur.Booleen
{
    public class Booleen : ParseurInterpreteur<bool>
    {
        private IEnumerable<TypeInfo> expressions;
        public Booleen()
            : base(new LexeurBooleen())
        {
            expressions = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(type => type.Name.StartsWith("Expression"))
                ;

            
        }

        protected override IExpression<bool> Factory(string lexeme)
        {
            int debut = lexeur.PositionPrecedente;
            int fin = lexeur.Position;
            object?[]? parametres = new object?[] { debut, fin };
            ConstructorInfo ctor = obtenirConstruteur(lexeme);
            IExpression<bool> expression = ctor.Invoke(parametres) as IExpression<bool>;
            return expression;
        }


        private ConstructorInfo obtenirConstruteur(string expression)
        {
            ConstructorInfo ctorInfo = expressions
                .FirstOrDefault(type => type.FullName.Contains(expression))
                .GetConstructors()[0];

            if(ctorInfo == null)
                throw new ParseurException(
                    "Symbole inconnu",
                    lexeur.PositionPrecedente,
                    lexeur.Position
                );

            return ctorInfo;
        }
    }
}
