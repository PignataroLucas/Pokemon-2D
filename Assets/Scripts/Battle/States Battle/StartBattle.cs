using System.Collections;
using UnityEngine;
using Utility.Managers;

namespace Battle.States_Battle
{
    public class StartBattle <T> : States<T>
    {
        private BattleSystem _battleSystem;

        private MonoBehaviour _monoBehaviour;

        public StartBattle(BattleSystem battleSystem, MonoBehaviour monoBehaviour)
        {
            _battleSystem = battleSystem;
            _monoBehaviour = monoBehaviour;
            
        }

        public override void OnEnter()
        {
            _monoBehaviour.StartCoroutine(SetUpBattle());
        }

        private IEnumerator SetUpBattle()
        {
            _battleSystem.playerPokemon.SetUp();
            _battleSystem.enemyPokemon.SetUp();
            _battleSystem.playerHud.SetData(_battleSystem.playerPokemon.Pokemon);
            _battleSystem.enemyHud.SetData(_battleSystem.enemyPokemon.Pokemon);
            yield return _monoBehaviour.StartCoroutine( _battleSystem.dialogBox.TypeDialog($"A wild  {_battleSystem.enemyPokemon.Pokemon.Attributes.name} appeared."));
            yield return new WaitForSeconds(1f);
            ChangeToPlayerAction();
        }

        private void ChangeToPlayerAction()
        {
            EventManager.TriggerEvent(GenericEvents.ChangeState, new Hashtable() {
                { GameplayHashtableParameters.ChangeState.ToString(),State.PlayerAction},
                { GameplayHashtableParameters.BattleSystem.ToString(), _battleSystem }
            });
        }
    }
    
}
