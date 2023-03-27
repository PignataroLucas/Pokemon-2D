using UnityEngine;

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

        [SerializeField] private int hp;
        [SerializeField] private int maxHp;
        [SerializeField] private int attack;
        [SerializeField] private int defense;
        [SerializeField] private int spAttack;
        [SerializeField] private int spDefense;
        [SerializeField] private int speed;
        [SerializeField] private int fistEvolutionLevel, secondEvolutionLevel;


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

