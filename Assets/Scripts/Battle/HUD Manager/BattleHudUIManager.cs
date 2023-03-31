using System.Collections;
using TMPro;
using UnityEngine;

namespace Battle.HUD_Manager
{
    public class BattleHudUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private HpBar hpBar;

        private Pokemon.Pokemon _pokemon;

        public void SetData(Pokemon.Pokemon pokemon)
        {
            _pokemon = pokemon;
            
            nameText.text = pokemon.Attributes.Name;
            levelText.text = "Lv" + pokemon.Level;
            hpBar.SetHp((float)pokemon.Hp / pokemon.MaxHp );
            hpBar.SetHp(pokemon.Hp,pokemon.MaxHp);
        }

        public IEnumerator UpdateHp()
        {
           yield return hpBar.SetHpSmooth((float)_pokemon.Hp / _pokemon.MaxHp );       
        }
        
    }
}
