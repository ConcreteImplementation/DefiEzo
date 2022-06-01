﻿
namespace Parseur.Calculatrice
{
    internal class Division : ExpressionBinaire<decimal>
    {
        public override int Priorite => 2;
        public override decimal Resoudre() => gauche.Resoudre() / droite.Resoudre();
    }
}
