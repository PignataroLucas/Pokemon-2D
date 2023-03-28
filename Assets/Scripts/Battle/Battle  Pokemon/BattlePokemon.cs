using ScriptableObjectsScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Battle__Pokemon
{
    public class BattlePokemon : MonoBehaviour
    {
        [SerializeField] private PokemonAttributes attributes;
        [SerializeField] private int level;
        public bool isPlayerUnit;
        
        public Pokemon.Pokemon Pokemon { get; set; }

        public void SetUp()
        {
            Pokemon = new Pokemon.Pokemon(attributes, level);
            GetComponent<Image>().sprite = isPlayerUnit ? Pokemon.Attributes.BackSprite : Pokemon.Attributes.FrontSprite;
        }

    }
    
    
}
