using UnityEngine;

namespace ScriptableObjectsScripts
{
    [CreateAssetMenu(fileName = "Move",menuName = "Moves/Create new Move")]
    public class MoveAttributes : ScriptableObject
    {
        [SerializeField] private new string name;

        [TextArea] [SerializeField] private string description;

        [SerializeField] private PokemonType type;

        [SerializeField] private int power;
        [SerializeField] private int accuracy;
        [SerializeField] private int pp;

        public string Name => name;
        
        public string Description => description;
        public PokemonType Type => type;
        public int Power => power;
        public int Accuracy => accuracy;
        public int Pp => pp;
    }
    
}
