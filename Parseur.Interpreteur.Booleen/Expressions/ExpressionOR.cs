using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parseur.Interpreteur.Booleen.Expressions
{
    internal class ExpressionOR : ExpressionBinaire<bool>
    {
        public ExpressionOR(int debut, int fin) : base(debut, fin)
        {
        }

        public override int Priorite => 100;
        protected override bool resoudre()
            => gauche.Resoudre() || droite.Resoudre();
    }
}
