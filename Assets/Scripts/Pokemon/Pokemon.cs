using ScriptableObjectsScripts;
using UnityEngine;
using System.Collections.Generic;

namespace Pokemon
{
    public class Pokemon
    {
        public PokemonAttributes Attributes { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public List<Move> Moves { get; set; }
        
        

        public Pokemon(PokemonAttributes pokemonAttributes, int level)
        {
            Attributes = pokemonAttributes;
            Level = level;
            Hp = MaxHp;

            //Generates Moves
            Moves = new List<Move>();
            foreach (var move in Attributes.LearnableMovesList)
            {
                Moves.Add(new Move(move.MoveAttributes));

                if (Moves.Count >= 4)
                {
                    break;
                }
            }
        }
        
        public int MaxHp => Mathf.FloorToInt((Attributes.MaxHp * Level) / 100f) + 10;
        public int Attack => Mathf.FloorToInt((Attributes.Attack * Level) / 100f) + 5;
        public int Defense => Mathf.FloorToInt((Attributes.Defense * Level) / 100f) + 5;
        public int SpAttack => Mathf.FloorToInt((Attributes.SpAttack * Level) / 100f) + 5;
        public int SpDefense => Mathf.FloorToInt((Attributes.SpDefense * Level) / 100f) + 5;
        public int Speed => Mathf.FloorToInt((Attributes.Speed * Level) / 100f) + 5;
        
        
    }
    
    
}
