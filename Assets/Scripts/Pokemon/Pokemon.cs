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
                if(move.Level <= Level) Moves.Add(new Move(move.MoveAttributes));

                if (Moves.Count >= 4) break;
            }
        }
        
        public int MaxHp => Mathf.FloorToInt((Attributes.MaxHp * Level) / 100f) + 10;
        public int Attack => Mathf.FloorToInt((Attributes.Attack * Level) / 100f) + 5;
        public int Defense => Mathf.FloorToInt((Attributes.Defense * Level) / 100f) + 5;
        public int SpAttack => Mathf.FloorToInt((Attributes.SpAttack * Level) / 100f) + 5;
        public int SpDefense => Mathf.FloorToInt((Attributes.SpDefense * Level) / 100f) + 5;
        public int Speed => Mathf.FloorToInt((Attributes.Speed * Level) / 100f) + 5;
        
        public DamageDetails TakeDamage(Move move , Pokemon attacker)
        {
            float critical = 1f;
            
            if (Random.value * 100f <= 6.25f)
            {
                critical = 2f;
            }
            
            float type = TypeChart.GetEffectiveness(move.MoveAttributes.Type, this.Attributes.Type)
                         * TypeChart.GetEffectiveness(move.MoveAttributes.Type, this.Attributes.Type2);


            var damageDetails = new DamageDetails()
            {
                TypeEffectiveness = type,
                Critical = critical,
                Fainted = false,
            };
            
            float modifiers = Random.Range(.85f, 1f) * type * critical;
            float a = (2 * attacker.Level + 10) / 250f;
            float d = a * move.MoveAttributes.Power * ((float)attacker.Attack / Defense) + 2;
            int damage = Mathf.FloorToInt(d * modifiers);
        
            Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;
                damageDetails.Fainted = true;
            }
            return damageDetails;
        }

        public Move GetRandomMove()
        {
            int r = Random.Range(0, Moves.Count);
            return Moves[r];
        }
        
    }

    
    public class DamageDetails
    {
        public bool Fainted { get; set; }
        
        public float Critical { get; set; }
        
        public float TypeEffectiveness { get; set; }
    }
    
}
