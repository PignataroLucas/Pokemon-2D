using System.Collections;
using Pokemon;
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
            
            _battleSystem.enemyPokemon.PlayAttackAnimation();
            yield return new WaitForSeconds(1.3f);
            _battleSystem.playerPokemon.PlayHitAnimation();

            var damageDetails = _battleSystem.playerPokemon.Pokemon.TakeDamage(move, _battleSystem.playerPokemon.Pokemon);
            yield return _battleSystem.playerHud.UpdateHp();
            yield return ShowDamageDetails(damageDetails);
            if (damageDetails.Fainted)
            {
                yield return _battleSystem.dialogBox.TypeDialog(
                    $"{_battleSystem.playerPokemon.Pokemon.Attributes.Name} Fainted ");
                _battleSystem.playerPokemon.PlayFaintAnimation();
            }
            else
            {
                PlayerActions();
            }
        }

        IEnumerator ShowDamageDetails(DamageDetails damageDetails)
        {
            if (damageDetails.Critical > 1) yield return _battleSystem.dialogBox.TypeDialog("A critical hit!");
            if (damageDetails.TypeEffectiveness > 1f)
            {
                yield return _battleSystem.dialogBox.TypeDialog("It's super effective!");
            }
            else if (damageDetails.TypeEffectiveness < 1f)
            {
                yield return _battleSystem.dialogBox.TypeDialog("It's not very effective!");
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
