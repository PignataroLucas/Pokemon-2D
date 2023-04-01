using UnityEngine;
using Utility.Managers;

namespace GameStates
{
    public class BattleState <T> : States<T>
    {
        private GameManager _gameManager;

        public BattleState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void OnEnter()
        {
            _gameManager.battleSystem.gameObject.SetActive(true);
            _gameManager.worldCamera.gameObject.SetActive(false);
        }
    }
}
