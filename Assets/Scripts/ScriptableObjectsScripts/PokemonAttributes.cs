using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjectsScripts
{
    [CreateAssetMenu(fileName = "Pokemon",menuName = "Pokemon/Create new Pokemon")]
    public class PokemonAttributes : ScriptableObject
    {

        [SerializeField] private new string name;
        [TextArea]
        [SerializeField] private string description;

        [SerializeField] private Sprite frontSprite;
        [SerializeField] private Sprite backSprite;
        [SerializeField] private PokemonType type, type2;
        [SerializeField] private PokemonAttributes secondEvolution, thirdEvolution;
        
        [SerializeField] private int maxHp;
        [SerializeField] private int attack;
        [SerializeField] private int defense;
        [SerializeField] private int spAttack;
        [SerializeField] private int spDefense;
        [SerializeField] private int speed;
        [SerializeField] private List<LearnableMoves> learnableMoves;
        [SerializeField] private int fistEvolutionLevel, secondEvolutionLevel;

        public string GetName(){return name;}
        public string Name => name;
        public string Description => description;
        public Sprite FrontSprite => frontSprite;
        public Sprite BackSprite => backSprite;
        public PokemonType Type => type;
        public PokemonType Type2 => type2;
        public int MaxHp => maxHp;
        public int Attack => attack;
        public int Defense => defense;
        public int SpAttack => spAttack;
        public int SpDefense => spDefense;
        public int Speed => speed;
        public List<LearnableMoves> LearnableMovesList => learnableMoves;



    }

    [System.Serializable]
    public struct LearnableMoves
    { 
        [SerializeField] private MoveAttributes moveAttributes;
        [SerializeField] private int level;
        
        public MoveAttributes MoveAttributes => moveAttributes;
        public int Level => level;
        
    }

    public enum PokemonType
    {
        None,
        Bug,
        Dragon,
        Electric,
        Fighting,
        Fire,
        Flying,
        Ghost,
        Grass,
        Ground,
        Ice,
        Normal,
        Poison,
        Psychic,
        Rock,
        Water
    }
    
    
}

