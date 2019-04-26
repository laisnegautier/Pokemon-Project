using System;
using System.Collections.Generic;
using System.Text;

namespace ProgAvancee_Pokemon
{
    class Joueur
    {
        static private Random rnd = new Random();

        // Si le numero vaut 1, alors le joueur est l'utilisateur. Autrement c'est l'ordinateur.
        public int Numero { get; }
        public List<Pokemon> Pokemons { get; }

        public Joueur(int numero, Pokemon pokemon1, Pokemon pokemon2, Pokemon pokemon3)
        {
            Numero = numero;
            Pokemons = new List<Pokemon>();
            Pokemons.Add(pokemon1);
            Pokemons.Add(pokemon2);
            Pokemons.Add(pokemon3);
        }

        /// <summary>
        /// Permet de choisir un pokemon parmi ceux encore en vie pour le combat
        /// </summary>
        /// <returns>Le pokemon choisi</returns>
        public Pokemon ChoisirPokemonActif()
        {
            Pokemon PokemonChoisi = null;

            // Soit le joueur est un humain vivant, soit c'est un ordinateur
            if (Numero == 1)
            {
                int choixHumain;
                bool erreur = false;

                Console.WriteLine("Quel Pokemon voulez-vous choisir ?");

                do
                {
                    if (erreur) Console.WriteLine("Le numero saisi ne correspond a aucun Pokemon disponible");

                    int i = 1;
                    foreach (Pokemon PokemonJoueur in Pokemons)
                    {
                        // On ne propose que les pokemons encore vivants
                        if (!PokemonJoueur.KO) Console.WriteLine("Tapez {0} pour {1}", i, PokemonJoueur.Nom);
                        else Console.WriteLine("Votre pokemon {0} : {1} est mort ! Vous ne pouvez pas le choisir.", i, PokemonJoueur.Nom);
                        i++;
                    }

                    Console.Write("Votre choix : ");
                    choixHumain = int.Parse(Console.ReadLine());

                    // Verification : le numero du pokemon correspond bien a un pokemon et celui-ci n'est pas mort
                    if (choixHumain >= 1 && choixHumain <= 3 && !Pokemons[choixHumain - 1].KO)
                    {
                        PokemonChoisi = Pokemons[choixHumain - 1];
                        erreur = false;
                    }
                    else erreur = true;

                } while (erreur == true);
            }
            else
            {
                int choixOrdi;

                do
                {
                    choixOrdi = rnd.Next(1, 4);
                } while (Pokemons[choixOrdi - 1].KO);

                PokemonChoisi = Pokemons[choixOrdi - 1];
            }

            return PokemonChoisi;
        }

        /// <summary>
        /// Annonce si un joueur est encore de la partie ou non
        /// </summary>
        /// <returns>TRUE si le joueur a tous ces pokemons de mort, FALSE sinon</returns>
        public bool EstMort()
        {
            bool estMort = true;

            foreach (Pokemon PokemonJoueur in Pokemons)
                if (!PokemonJoueur.KO)
                    estMort = false;

            return estMort;
        }

        /// <summary>
        /// Remet tous les PV des pokemons du joueur a leur etat initial, comme ca ils sont de nouveaux prets pour une nouvelle bataille
        /// </summary>
        public void Soigner()
        {
            foreach (Pokemon PokemonJoueur in Pokemons)
                PokemonJoueur.PV = PokemonJoueur.__PV_MAX;
        }
    }
}
