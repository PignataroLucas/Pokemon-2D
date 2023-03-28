using TMPro;
using UnityEngine;

namespace Battle.HUD_Manager
{
    public class BattleHudUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private HpBar hpBar;

        public void SetData(Pokemon.Pokemon pokemon)
        {
            nameText.text = pokemon.Attributes.Name;
            levelText.text = "Lv" + pokemon.Level;
            hpBar.SetHp((float)pokemon.Hp);
            hpBar.SetHp(pokemon.Hp,pokemon.MaxHp);
        }
    }
}
