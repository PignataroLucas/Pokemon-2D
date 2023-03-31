using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjectsScripts
{
    [CreateAssetMenu(fileName = "Pokemon",menuName = "Pokemon/Create new Pokemon")]
    public class PokemonAttributes : ScriptableObject
    {

        [SerializeField] private string name;
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
        Normal,
        Fire,
        Water,
        Electric,
        Grass,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Rock,
        Ghost,
        Dragon,
        Dark,
        Steel,
        Fairy,
    }

    //https://pokemondb.net/type
    public class TypeChart
    {
        private static float[][] _chart =
        {
            // types              Nor Fir  WAT Ele Grass Ice  Fight  Poi    Gro    Fly     Psy     Bugg     Rock    Ghost   Drag    Dark    Steel   Fairy

            /*NORMAL*/ new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 0f, 1f, 1f, 0.5f, 1f },
            /*FIRE*/ new float[] { 1f, 0.5f, 0.5f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 1f, 2f, 0.5f, 1f, 0.5f, 1f, 2f, 1f },
            /*WATER*/ new float[] { 1f, 2f, 0.5f, 1f, 0.5f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 2f, 1f, 0.5f, 1f, 1f, 1f },
            /*ELECTRIC*/ new float[] { 1f, 1f, 2f, 0.5f, 0.5f, 1f, 1f, 1f, 0f, 2f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f },
            /*GRASS*/ new float[] { 1f, 0.5f, 2f, 1f, 0.5f, 1f, 1f, 0.5f, 2f, 0.5f, 1f, 0.5f, 2f, 1f, 0.5f, 1f, 0.5f, 1f },
            /*ICE*/ new float[] { 1f, 0.5f, 0.5f, 1f, 2f, 0.5f, 1f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 2f, 1f, 0.5f, 1f },
            /*FIGHTING*/new float[] { 2f, 1f, 1f, 1f, 1f, 2f, 1f, 0.5f, 1f, 0.5f, 0.5f, 0.5f, 2f, 0f, 1f, 2f, 2f, 0.5f },
            /*POISON*/ new float[] { 1f, 1f, 1f, 1f, 2f, 1f, 1f, 0.5f, 0.5f, 1f, 1f, 1f, 0.5f, 0.5f, 1f, 1f, 0f, 2f },
            /*GROUND*/ new float[] { 1f, 2f, 1f, 2f, 0.5f, 1f, 1f, 2f, 1f, 0f, 1f, 0.5f, 2f, 1f, 1f, 1f, 2f, 1f },
            /*FLYING*/ new float[] { 1f, 1f, 1f, 0.5f, 2f, 1f, 2f, 1f, 1f, 1f, 1f, 2f, 0.5f, 1f, 1f, 1f, 0.5f, 1f },
            /*PSYCHIC*/ new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f, 0f, 0.5f, 1f },
            /*BUGG*/ new float[] { 1f, 0.5f, 1f, 1f, 2f, 1f, 0.5f, 0.5f, 1f, 0.5f, 2f, 1f, 1f, 0.5f, 1f, 2f, 0.5f, 0.5f },
            /*ROCK*/ new float[] { 1f, 2f, 1f, 1f, 1f, 2f, 0.5f, 1f, 0.5f, 2f, 1f, 2f, 1f, 1f, 1f, 1f, 0.5f, 1f },
            /*GHOST*/ new float[] { 0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 2f, 1f, 0.5f, 1f, 1f },
            /*DRAGON*/ new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 0.5f, 0f },
            /*DARK*/ new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 2f, 1f, 1f, 2f, 1f, 0.5f, 1f, 0.5f },
            /*STEEL*/ new float[] { 1f, 0.5f, 0.5f, 0.5f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 0.5f, 2f },
            /*FAIRY*/ new float[] { 1f, 0.5f, 1f, 1f, 1f, 1f, 2f, 0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 0.5f, 1f }

        };

        public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
        {
            if (attackType == PokemonType.None || defenseType == PokemonType.None)return 1;

            int row = (int)attackType - 1;
            int col = (int)defenseType - 1;

            return _chart[row][col];
        }
        
    }
    
    
}

