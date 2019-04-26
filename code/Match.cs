using System;
using System.Collections.Generic;
using System.Text;

namespace ProgAvancee_Pokemon
{
    class Match
    {
        static private Random rnd = new Random();

        public Joueur Joueur1 { get; }
        public Joueur Joueur2 { get; }
        public Joueur JoueurPerdant { get; set; }

        public Match(Joueur joueur1, Joueur joueur2)
        {
            Joueur1 = joueur1;
            Joueur2 = joueur2;
            // Joueur perdant initialisé à null (ie le match est en cours
            JoueurPerdant = null;
        }

        /// <summary>
        /// Determine si le Joueur1 doit commencer a jouer ou non. Choix aleatoire
        /// </summary>
        /// <returns>True si le Joueur1 doit commencer, false sinon</returns>
        public bool Joueur1QuiCommence()
        {
            return (rnd.Next(0, 2) != 0);
        }

        public void LancerMatch()
        {
            Pokemon ChoixPokemonJoueur1 = null;
            Pokemon ChoixPokemonJoueur2 = null;
            Combat UnContreUn;

            // Tant que tous les joueurs ont au moins un pokemon vivant
            while (!Joueur1.EstMort() && !Joueur2.EstMort())
            {
                // Demandes de choix d'un pokemon si le pokemon precedent vient de mourir ou si debut du match
                // A part au premier tour, il n'y a pas lieu d'entrer dans les deux if
                if (ChoixPokemonJoueur1 == null || ChoixPokemonJoueur1.KO) ChoixPokemonJoueur1 = Joueur1.ChoisirPokemonActif();
                if (ChoixPokemonJoueur2 == null || ChoixPokemonJoueur2.KO) ChoixPokemonJoueur2 = Joueur2.ChoisirPokemonActif();

                if(Joueur1QuiCommence())
                    UnContreUn = new Combat(ChoixPokemonJoueur1, ChoixPokemonJoueur2);
                else
                    UnContreUn = new Combat(ChoixPokemonJoueur2, ChoixPokemonJoueur1);

                // Les combats peuvent commencer !
                UnContreUn.LancerCombat();
            }

            Joueur JoueurG = JoueurGagnant();
            if (JoueurG == Joueur1)
            {
                JoueurPerdant = Joueur2;
                Console.WriteLine("Le vainqueur est le joueur num {0}", Joueur1.Numero);
            }
            else
            {
                JoueurPerdant = Joueur1;
                Console.WriteLine("Le vainqueur est le joueur num {0}", Joueur2.Numero);
            }
            
            JoueurG.Soigner();
        }  

        /// <summary>
        /// Determine quel joueur vient de mourir a la fin du match (ie. lequel a ses trois pokemon detruits). Il ne peut y avoir 2 joueurs morts.
        /// </summary>
        /// <returns>Le Joueur elimine</returns>
        public Joueur JoueurGagnant()
        {
            if (Joueur1.EstMort()) return Joueur2;
            else return Joueur1;
        }
    }
}
