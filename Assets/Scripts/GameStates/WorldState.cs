using System.Collections;
using AI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Utility.Managers;

namespace GameStates
{
    public class WorldState <T> : States<T> , IEventListener
    {
        private GameManager _gameManager;

        public WorldState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void OnEnter()
        {
            OnEnableListenerSubscriptions();
        }

        public override void OnUpdate()
        {
            _gameManager.playerController.HandleUpdate();
        }


        public void OnEnableListenerSubscriptions()
        {
            EventManager.StartListening(GenericEvents.RandomEncounter,ChangeToBattleState);
        }

        private void ChangeToBattleState(Hashtable obj)
        {
            EventManager.TriggerEvent(GenericEvents.ChangeState, new Hashtable() {
                { GameplayHashtableParameters.ChangeState.ToString(),GameState.Battle},
                { GameplayHashtableParameters.GameManager.ToString(), _gameManager}
            });
        }

        public void OnDisableListenerSubscriptions()
        {
            throw new System.NotImplementedException();
        }
    }
}
