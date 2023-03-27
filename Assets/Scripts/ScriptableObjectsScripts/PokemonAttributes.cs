using UnityEngine;

namespace ScriptableObjectsScripts
{
    [CreateAssetMenu(fileName = "Pokemon",menuName = "Pokemon/Create new Pokemon")]
    public class PokemonAttributes : ScriptableObject
    {

        public new string name;
        [TextArea]
        public string description;

        public Sprite frontSprite;
        public Sprite backSprite;
        public PokemonType type, type2;
        public PokemonAttributes secondEvolution, thirdEvolution;

        public int hp;
        public int maxHp;
        public int defense;
        public int spAttack;
        public int spDefense;
        public int speed;
        public int fistEvolutionLevel, secondEvolutionLevel;


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

