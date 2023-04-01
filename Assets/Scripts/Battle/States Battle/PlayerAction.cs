using System.Collections;
using AI;
using UnityEngine;
using Utility.Managers;

namespace Battle.States_Battle
{
    public class PlayerAction <T> : States<T>
    {

        private BattleSystem _battleSystem;
        private MonoBehaviour _monoBehaviour;

        private int _currentAction;
        
        public PlayerAction(BattleSystem battleSystem,MonoBehaviour monoBehaviour)
        {
            _battleSystem = battleSystem;
            _monoBehaviour = monoBehaviour;
        }
        public override void OnEnter()
        {
            _monoBehaviour.StartCoroutine(_battleSystem.dialogBox.TypeDialog("Choose an Action"));
            _battleSystem.dialogBox.EnableActionSelector(true);
        }

        //This maybe cause bugs in the call of fsm in battle system
        public override void OnUpdate()
        {
            HandleActionSelector();
        }

        private void HandleActionSelector()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(_currentAction < 1)_currentAction++;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_currentAction > 0) _currentAction--;
            }
            _battleSystem.dialogBox.UpdateActionSelection(_currentAction);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (_currentAction == 0)
                {
                    EventManager.TriggerEvent(GenericEvents.ChangeState, new Hashtable() {
                        { GameplayHashtableParameters.ChangeState.ToString(),State.PlayerMove},
                        { GameplayHashtableParameters.BattleSystem.ToString(), _battleSystem}
                    });
                }
                if (_currentAction == 1)
                {
                    //Run State
                }   
            }
        }
    }
}
