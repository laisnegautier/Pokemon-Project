using System;
using System.Collections.Generic;
using System.Text;

namespace ProgAvancee_Pokemon
{
    abstract class Pokemon
    {
        // Nous interdisons la construction de Pokemon en general. 
        // Il faut forcement que celui-ci soit d'un type particulier (de feu, de glace, de plante...)
        // Les classes filles qui servent a initialiser les pokemon d'un certains type sont dans PokemonType.cs

        #region Champs et Proprietes
        
        public readonly int __PV_MAX;

        // Etapes necessaires pour poser des conditions sur les valeurs de pv SAUF lors de la construction de l'objet
        private int? pv = null;
        public int PV
        {
            get { return (int)pv; }
            set {
                if (pv.HasValue && pv - value < 0) pv = 0;
                else pv = value;
            }
        }
        public string Nom { get; }
        public int PuissanceAttaque { get; }
        // Le type de l'ennemi (Pokemon de Feu, Pokemon Insecte etc...) est defini lorsque l'on construit un Pokemon d'un certain type.
        public abstract Type TypeEnnemi { get; }

        // Precise si le pokemon est mort ou pas selon les points de vie qu'il lui reste
        public bool KO
        {
            get {
                if (PV > 0) return false;
                else return true;
            }
        }

        #endregion

        #region Constructeur
        public Pokemon(string nom, int PVmax, int puissanceAttaque)
        {
            __PV_MAX = PVmax;
            PV = PVmax;
            Nom = nom;
            PuissanceAttaque = puissanceAttaque;
        }
        #endregion

        #region Methodes d'instance
        /// <summary>
        /// Applique des degats a l'objet instancie
        /// </summary>
        /// <param name="Adversaire">Pokemon qui donne le coup</param>
        public void PrendreUnCoup(Pokemon Adversaire)
        {
            int degatsInfliges = Adversaire.PuissanceAttaque;

            if (TypeEnnemi == Adversaire.GetType())
                degatsInfliges = 2 * degatsInfliges;

            PV -= degatsInfliges;
        }

        /// <summary>
        /// Il y a 6 types de Pokemon dans notre jeu. Chacun a un type ennemi.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Un type qui sera l'ennemi</returns>
        protected Type DefinirTypeEnnemi(Type type)
        {
            Type typeEnnemi = null;

            if (type == typeof(PokemonFeu)) typeEnnemi = typeof(PokemonEau);
            else if (type == typeof(PokemonEau)) typeEnnemi = typeof(PokemonElectrique);
            else if (type == typeof(PokemonPlante)) typeEnnemi = typeof(PokemonInsecte);
            else if (type == typeof(PokemonElectrique)) typeEnnemi = typeof(PokemonVol);
            else if (type == typeof(PokemonVol)) typeEnnemi = typeof(PokemonPlante);
            else if (type == typeof(PokemonInsecte)) typeEnnemi = typeof(PokemonFeu);
            
            return typeEnnemi;
        }

        #endregion
    }
}
