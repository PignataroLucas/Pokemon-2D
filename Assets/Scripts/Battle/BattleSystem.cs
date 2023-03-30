using System;
using Battle.Battle__Pokemon;
using Battle.HUD_Manager;
using Battle.States_Battle;
using UnityEngine;
using System.Collections;
using Utility.Managers;

namespace Battle
{
    public class BattleSystem : MonoBehaviour , IEventListener
    {
        [SerializeField] private BattlePokemon playerPokemon,enemyPokemon;
        [SerializeField] private BattleHudUIManager playerHud,enemyHud;
        [SerializeField] private BattleDialogBox dialogBox;

        private FSM<string> _fsm;
        private StartBattle<string> _startBattle;
        private PlayerAction<string> _playerAction;
        private PlayerMove<string> _playerMove;
        private EnemyMove<string> _enemyMove;
        private Busy<string> _busy;

        private void Start()
        {
            _startBattle = new StartBattle<string>();
            _playerAction = new PlayerAction<string>();
            _playerMove = new PlayerMove<string>();
            _enemyMove = new EnemyMove<string>();
            _busy = new Busy<string>();
            _fsm = new FSM<string>(_startBattle);
            
            SetUpBattle();
            
        }

        private void Update()
        {
            _fsm.OnUpdate();
        }

        private void SetUpBattle()
        {
            playerPokemon.SetUp();
            enemyPokemon.SetUp();
            playerHud.SetData(playerPokemon.Pokemon);
            enemyHud.SetData(enemyPokemon.Pokemon);
            StartCoroutine( dialogBox.TypeDialog($"A wild  {enemyPokemon.Pokemon.Attributes.name} appeared."));
        }
        
        
        private void TransitionState(Hashtable data)
        {
            string state = data[GameplayHashtableParameters.ChangeState.ToString()].ToString();
                
            BattleSystem battleSystem = (BattleSystem)data[GameplayHashtableParameters.BattleSystem.ToString()];

            if (battleSystem == this) {

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
