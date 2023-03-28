using System;
using Battle.Battle__Pokemon;
using Battle.HUD_Manager;
using UnityEngine;

namespace Battle
{
    public class BattleSystem : MonoBehaviour
    {
        [SerializeField] private BattlePokemon playerPokemon;
        [SerializeField] private BattleHudUIManager playerHud;

        private void Start()
        {
            SetUpBattle();
        }

        private void SetUpBattle()
        {
            playerPokemon.SetUp();
            playerHud.SetData(playerPokemon.Pokemon);
            
        }
        
    }
}
