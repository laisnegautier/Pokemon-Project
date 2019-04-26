using System;
using System.Collections.Generic;
using System.Text;

namespace ProgAvancee_Pokemon
{
    class Combat
    {
        public Pokemon Pokemon1 { get; set; }
        public Pokemon Pokemon2 { get; set; }

        public Combat(Pokemon pokemonQuiCommence, Pokemon pokemonEnSecond)
        {
            Pokemon1 = pokemonQuiCommence;
            Pokemon2 = pokemonEnSecond;
        }

        public void LancerCombat()
        {
            while(!Pokemon1.KO && !Pokemon2.KO)
            {
                // Le Pokemon2 commence en second, il se prend donc un coup en premier
                Pokemon2.PrendreUnCoup(Pokemon1);

                // Si le pokemon qui vient de se prendre un coup est mort, on arrete le combat (i.e. la boucle)
                // sinon il se vange et frappe son adversaire
                if (Pokemon2.KO) break;
                else Pokemon1.PrendreUnCoup(Pokemon2);
            }
        }

        /// <summary>
        /// A n'utiliser qu'apres un combat ! Determine quel pokemon vient de perdre le combat (les deux ne peuvent pas etre morts en meme temps)
        /// </summary>
        /// <returns>Pokemon perdant</returns>
        public Pokemon PokemonPerdant()
        {
            if (Pokemon1.KO) return Pokemon1;
            else return Pokemon2;
        }
    }
}
