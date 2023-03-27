using ScriptableObjectsScripts;
using UnityEngine;
using System.Collections.Generic;



namespace Pokemon
{
    public class Pokemon
    {
        private PokemonAttributes _attributes;
        private int _level;

        public Pokemon(PokemonAttributes pokemonAttributes, int level)
        {
            _attributes = pokemonAttributes;
            _level = level;
        }
        
        public int MaxHp => Mathf.FloorToInt((_attributes.MaxHp * _level) / 100f) + 10;
        public int Attack => Mathf.FloorToInt((_attributes.Attack * _level) / 100f) + 5;
        public int Defense => Mathf.FloorToInt((_attributes.Defense * _level) / 100f) + 5;
        public int SpAttack => Mathf.FloorToInt((_attributes.SpAttack * _level) / 100f) + 5;
        public int SpDefense => Mathf.FloorToInt((_attributes.SpDefense * _level) / 100f) + 5;
        public int Speed => Mathf.FloorToInt((_attributes.Speed * _level) / 100f) + 5;
        
        
    }
    
    
}
