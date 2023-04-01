using System.Collections;
using AI;
using UnityEngine;
using Utility.Managers;

namespace GameStates
{
    public class BattleState <T> : States<T> , IEventListener
    {
        private GameManager _gameManager;

        public BattleState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void OnEnter()
        {
            OnEnableListenerSubscriptions();
            _gameManager.battleSystem.gameObject.SetActive(true);
            _gameManager.worldCamera.gameObject.SetActive(false);
            _gameManager.battleSystem.StartBattle();
        }


        public void OnEnableListenerSubscriptions()
        {
            EventManager.StartListening(GenericEvents.EndBattle,ChangeToWorldState);   
        }

        private void ChangeToWorldState(Hashtable obj)
        {
            _gameManager.battleSystem.gameObject.SetActive(false);
            _gameManager.worldCamera.gameObject.SetActive(true);
            EventManager.TriggerEvent(GenericEvents.ChangeState, new Hashtable() {
                { GameplayHashtableParameters.ChangeState.ToString(),GameState.World},
                { GameplayHashtableParameters.GameManager.ToString(), _gameManager}
            });
        }

        public void OnDisableListenerSubscriptions()
        {
            throw new System.NotImplementedException();
        }
    }
}
