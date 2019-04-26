using System;
using System.Collections.Generic;
using System.Text;

namespace ProgAvancee_Pokemon
{
    class PokemonFeu : Pokemon
    {
        public override Type TypeEnnemi { get; }

        public PokemonFeu(string nom, int PVmax, int puissanceAttaque) : base(nom, PVmax, puissanceAttaque)
        {
            TypeEnnemi = DefinirTypeEnnemi(typeof(PokemonFeu));
        }
    }

    class PokemonEau : Pokemon
    {
        public override Type TypeEnnemi { get; }

        public PokemonEau(string nom, int PVmax, int puissanceAttaque) : base(nom, PVmax, puissanceAttaque)
        {
            TypeEnnemi = DefinirTypeEnnemi(typeof(PokemonEau));
        }
    }

    class PokemonPlante : Pokemon
    {
        public override Type TypeEnnemi { get; }

        public PokemonPlante(string nom, int PVmax, int puissanceAttaque) : base(nom, PVmax, puissanceAttaque)
        {
            TypeEnnemi = DefinirTypeEnnemi(typeof(PokemonPlante));
        }
    }

    class PokemonElectrique : Pokemon
    {
        public override Type TypeEnnemi { get; }

        public PokemonElectrique(string nom, int PVmax, int puissanceAttaque) : base(nom, PVmax, puissanceAttaque)
        {
            TypeEnnemi = DefinirTypeEnnemi(typeof(PokemonElectrique));
        }
    }

    class PokemonVol : Pokemon
    {
        public override Type TypeEnnemi { get; }

        public PokemonVol(string nom, int PVmax, int puissanceAttaque) : base(nom, PVmax, puissanceAttaque)
        {
            TypeEnnemi = DefinirTypeEnnemi(typeof(PokemonVol));
        }
    }

    class PokemonInsecte : Pokemon
    {
        public override Type TypeEnnemi { get; }

        public PokemonInsecte(string nom, int PVmax, int puissanceAttaque) : base(nom, PVmax, puissanceAttaque)
        {
            TypeEnnemi = DefinirTypeEnnemi(typeof(PokemonInsecte));
        }
    }
}
