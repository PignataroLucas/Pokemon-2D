using System;
using System.Collections;
using Battle;
using GameStates;
using Player.MVC;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utility.Managers
{
    
    public class GameManager : MonoBehaviour , IEventListener
    {

        private FSM<string> _fsm;
        private WorldState<string> _worldState;
        private BattleState<string> _battleState;

        [SerializeField] protected internal PlayerController playerController;
        [SerializeField] protected internal BattleSystem battleSystem;
        [SerializeField] protected internal Camera worldCamera;
        
        
        private void Awake()
        {
            OnEnableListenerSubscriptions();
        }

        private void OnDisable()
        {
            
        }

        private void Start()
        {
            _worldState = new WorldState<string>(this);
            _battleState = new BattleState<string>(this);
            
            _worldState.SetTransition(GameState.Battle,_battleState);
            _battleState.SetTransition(GameState.World,_worldState);

            _fsm = new FSM<string>(_worldState);
        }

        private void Update()
        {
            _fsm.OnUpdate();
        }


        private void TransitionState(Hashtable data)
        {
            string state = data[GameplayHashtableParameters.ChangeState.ToString()].ToString();
                
            GameManager gameManager = (GameManager)data[GameplayHashtableParameters.GameManager.ToString()];

            if (gameManager == this) {

                _fsm.Transition(state);           
            } 
        }
        public void OnEnableListenerSubscriptions()
        {
            EventManager.StartListening(GenericEvents.ChangeState, TransitionState);
        }
        
        public void OnDisableListenerSubscriptions()
        {
            EventManager.StopListering(GenericEvents.ChangeState, TransitionState);
        }
    }
    
    
}
