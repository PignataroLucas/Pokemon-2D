using System.Collections;
using UnityEngine;
using Utility.Managers;

namespace Battle.States_Battle
{
    public class EnemyMove <T> : States<T>
    {
        private BattleSystem _battleSystem;
        private MonoBehaviour _monoBehaviour;

        public EnemyMove(BattleSystem battleSystem, MonoBehaviour monoBehaviour)
        {
            _battleSystem = battleSystem;
            _monoBehaviour = monoBehaviour;
        }

        public override void OnEnter()
        {
            _monoBehaviour.StartCoroutine(EnemyMoves());
        }

        private IEnumerator EnemyMoves()
        {
            var move = _battleSystem.enemyPokemon.Pokemon.GetRandomMove();

            yield return _battleSystem.dialogBox.TypeDialog(
                $"{_battleSystem.enemyPokemon.Pokemon.Attributes.Name} used {move.MoveAttributes.Name}");
            yield return new WaitForSeconds(1f);

            bool isFainted = _battleSystem.playerPokemon.Pokemon.TakeDamage(move, _battleSystem.playerPokemon.Pokemon);
            yield return _battleSystem.playerHud.UpdateHp();

            if (isFainted)
            {
                yield return _battleSystem.dialogBox.TypeDialog(
                    $"{_battleSystem.playerPokemon.Pokemon.Attributes.Name} Fainted ");
            }
            else
            {
                PlayerActions();
            }

        }

        private void PlayerActions()
        {
            EventManager.TriggerEvent(GenericEvents.ChangeState, new Hashtable() {
                { GameplayHashtableParameters.ChangeState.ToString(),State.PlayerAction},
                { GameplayHashtableParameters.BattleSystem.ToString(), _battleSystem}
            });
        }
    }
}
