using ScriptableObjectsScripts;
using UnityEngine;
using System.Collections.Generic;

namespace Pokemon
{
    public class Pokemon
    {
        private PokemonAttributes _attributes;
        private int _level;
        public int Hp { get; set; }

        public List<Move> Moves { get; set; }
        
        

        public Pokemon(PokemonAttributes pokemonAttributes, int level)
        {
            _attributes = pokemonAttributes;
            _level = level;
            Hp = _attributes.MaxHp;

            //Generates Moves
            Moves = new List<Move>();
            foreach (var move in _attributes.LearnableMovesList)
            {
                Moves.Add(new Move(move.MoveAttributes));

                if (Moves.Count >= 4)
                {
                    break;
                }
            }
        }
        
        public int MaxHp => Mathf.FloorToInt((_attributes.MaxHp * _level) / 100f) + 10;
        public int Attack => Mathf.FloorToInt((_attributes.Attack * _level) / 100f) + 5;
        public int Defense => Mathf.FloorToInt((_attributes.Defense * _level) / 100f) + 5;
        public int SpAttack => Mathf.FloorToInt((_attributes.SpAttack * _level) / 100f) + 5;
        public int SpDefense => Mathf.FloorToInt((_attributes.SpDefense * _level) / 100f) + 5;
        public int Speed => Mathf.FloorToInt((_attributes.Speed * _level) / 100f) + 5;
        
        
    }
    
    
}
