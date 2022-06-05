using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parseur.Interpreteur.Booleen.Expressions
{
    internal class ExpressionFALSE : ExpressionTerminale<bool>
    {
        public ExpressionFALSE(int debut, int fin)
            :base(debut, fin)
        {
            
        }
        protected override bool resoudre()
            => false;
    }
}
