using System;
using System.Collections.Generic;
using System.Text;

namespace ProgAvancee_Pokemon
{
    class Tour
    {
        static private Random rnd = new Random();

        public List<Joueur> Joueurs { get; }
        public int NbrMatchs { get; }
        public Joueur[,] RepartitionMatchs { get; set; }

        public Tour(List<Joueur> joueurs)
        {
            Joueurs = joueurs;
            NbrMatchs = Joueurs.Count / 2;
            RepartitionMatchs = RepartirMatchs(joueurs);
        }

        // FONCTION A REVOIR
        public Joueur[,] RepartirMatchs(List<Joueur> joueurs)
        {
            Joueur[,] RepartitionMatchs = new Joueur[2, Joueurs.Count / 2];
            int choixLigne;
            int choixColonne;
            bool ligneRemplie;

            // On prend un element de la liste des joueurs, on choisit aleatoirement si on va le mettre en ligne 1 ou 2, puis aleatoirement dans une colonne
            for (int i = 0; i < joueurs.Count; i++)
            {
                ligneRemplie = true;
                do
                {
                    choixLigne = rnd.Next(0, 2);

                    // Attention au cas ou une des lignes est entierement remplie !
                    for (int p = 0; p < joueurs.Count / 2; p++)
                        if (RepartitionMatchs[choixLigne, p] == null)
                            ligneRemplie = false;

                } while (ligneRemplie);

                do
                {
                    choixColonne = rnd.Next(0, (joueurs.Count / 2) + 1);
                    Console.WriteLine(choixLigne);
                    Console.WriteLine(choixColonne);
                } while (RepartitionMatchs[choixLigne, choixColonne] != null);

                RepartitionMatchs[choixLigne, choixColonne] = joueurs[i];
            }

            return RepartitionMatchs;
        }

        public void LancerTour()
        {
            Console.WriteLine(Joueurs.Count);
            for (int j = 0; j < NbrMatchs; j++)
            {
                Match JoueurContreJoueur = new Match(RepartitionMatchs[0, j], RepartitionMatchs[1, j]);
                Joueur Perdant = JoueurContreJoueur.JoueurPerdant;
                Joueurs.Remove(Perdant);
            }
            Console.WriteLine(Joueurs.Count);
        }
    }
}
