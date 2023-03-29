using Battle.Battle__Pokemon;
using Battle.HUD_Manager;
using UnityEngine;

namespace Battle
{
    public class BattleSystem : MonoBehaviour
    {
        [SerializeField] private BattlePokemon playerPokemon,enemyPokemon;
        [SerializeField] private BattleHudUIManager playerHud,enemyHud;
        [SerializeField] private BattleDialogBox dialogBox;

        private void Start()
        {
            SetUpBattle();
        }

        private void SetUpBattle()
        {
            playerPokemon.SetUp();
            enemyPokemon.SetUp();
            playerHud.SetData(playerPokemon.Pokemon);
            enemyHud.SetData(enemyPokemon.Pokemon);
            StartCoroutine( dialogBox.TypeDialog($"A wild  {enemyPokemon.Pokemon.Attributes.name} appeared."));
        }
        
    }
}
