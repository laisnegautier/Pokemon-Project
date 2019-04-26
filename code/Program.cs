using System;
using System.Collections.Generic;
using System.Text;

namespace ProgAvancee_Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test de construction d'un Pokemon
            PokemonPlante Err = new PokemonPlante("Hello", 50, 12);
            PokemonElectrique Test1 = new PokemonElectrique("Mechant", 20, 5);
            PokemonInsecte Test2 = new PokemonInsecte("TresMechant", 20, 5);
            Console.WriteLine("Nom: {0}, PVMAX : {1}, PV : {2}, estKo ? {3}, type ennemi : {4}", Err.Nom, Err.__PV_MAX, Err.PV, Err.KO, Err.TypeEnnemi);
            Err.PrendreUnCoup(Test1);
            Console.WriteLine("Nom: {0}, PVMAX : {1}, PV : {2}, estKo ? {3}, type ennemi : {4}", Err.Nom, Err.__PV_MAX, Err.PV, Err.KO, Err.TypeEnnemi);
            Err.PrendreUnCoup(Test2);
            Console.WriteLine("Nom: {0}, PVMAX : {1}, PV : {2}, estKo ? {3}, type ennemi : {4}", Err.Nom, Err.__PV_MAX, Err.PV, Err.KO, Err.TypeEnnemi);
            #endregion

            #region Test Match
            // Creons 6 Pokemons, 2 joueurs et un match
            PokemonPlante Pok11 = new PokemonPlante("J1-P1", 20, 6);
            PokemonElectrique Pok12 = new PokemonElectrique("J1-P2", 20, 7);
            PokemonInsecte Pok13 = new PokemonInsecte("J1-P3", 20, 8);
            PokemonFeu Pok21 = new PokemonFeu("J2-P1", 20, 6);
            PokemonVol Pok22 = new PokemonVol("J2-P2", 20, 7);
            PokemonEau Pok23 = new PokemonEau("J2-P3", 20, 8);

            Joueur Humain = new Joueur(1, Pok11, Pok12, Pok13);
            Joueur Ordinateur = new Joueur(2, Pok21, Pok22, Pok23);

            Match MatchTest = new Match(Humain, Ordinateur);
            //MatchTest.LancerMatch();
            #endregion

            #region Test Tour
            PokemonPlante Pok31 = new PokemonPlante("J3-P1", 16, 6);
            PokemonElectrique Pok32 = new PokemonElectrique("J3-P2", 16, 7);
            PokemonInsecte Pok33 = new PokemonInsecte("J3-P3", 16, 8);
            PokemonFeu Pok41 = new PokemonFeu("J4-P1", 19, 6);
            PokemonVol Pok42 = new PokemonVol("J4-P2", 19, 7);
            PokemonEau Pok43 = new PokemonEau("J4-P3", 19, 8);

            Joueur Ordinateur2 = new Joueur(3, Pok31, Pok32, Pok33);
            Joueur Ordinateur3 = new Joueur(4, Pok41, Pok42, Pok43);

            List<Joueur> Joueurs = new List<Joueur>();
            Joueurs.Add(Humain);
            Joueurs.Add(Ordinateur);
            Joueurs.Add(Ordinateur2);
            Joueurs.Add(Ordinateur3);

            Tour TourTest = new Tour(Joueurs);
            TourTest.LancerTour();

            //Tour TourTest = new Tour();
            #endregion
        }
    }
}
