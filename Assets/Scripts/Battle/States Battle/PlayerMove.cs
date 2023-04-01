
using System.Collections;
using AI;
using Pokemon;
using UnityEngine;
using Utility.Managers;

namespace Battle.States_Battle
{
    public class PlayerMove <T> : States<T>
    {
        private BattleSystem _battleSystem;
        private MonoBehaviour _monoBehaviour;

        private int _currentMove;
        public PlayerMove(BattleSystem battleSystem,MonoBehaviour monoBehaviour)
        {
            _battleSystem = battleSystem;
            _monoBehaviour = monoBehaviour;
        }

        public override void OnEnter()
        {
           _battleSystem.dialogBox.EnableActionSelector(false);
           _battleSystem.dialogBox.EnableDialogText(false);
           _battleSystem.dialogBox.MoveEnableSelector(true);
        }

        public override void OnUpdate()
        {
            HandleMoveSelection();
        }

        private void HandleMoveSelection()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(_currentMove < _battleSystem.playerPokemon.Pokemon.Moves.Count - 1)_currentMove++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_currentMove > 0) _currentMove--;
            } 
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_currentMove < _battleSystem.playerPokemon.Pokemon.Moves.Count - 2) _currentMove += 2;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_currentMove > 1) _currentMove -= 2;
            }
            _battleSystem.dialogBox.UpdateMoveSelection(_currentMove,_battleSystem.playerPokemon.Pokemon.Moves[_currentMove]);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                  _battleSystem.dialogBox.MoveEnableSelector(false);
                  _battleSystem.dialogBox.EnableDialogText(true);
                  _monoBehaviour.StartCoroutine(PerformPlayerMove());
            }
            
        }

        private IEnumerator PerformPlayerMove()
        {
            //Cambiar estado a Busy
            var move = _battleSystem.playerPokemon.Pokemon.Moves[_currentMove];
            yield return _battleSystem.dialogBox.TypeDialog(
                $"{_battleSystem.playerPokemon.Pokemon.Attributes.name} used " +
                $"{move.MoveAttributes.Name}");

            _battleSystem.playerPokemon.PlayAttackAnimation();
            yield return new WaitForSeconds(1.3f);
            _battleSystem.enemyPokemon.PlayHitAnimation(); 
            
            var damageDetails = _battleSystem.enemyPokemon.Pokemon.TakeDamage(move, _battleSystem.playerPokemon.Pokemon);
            yield return _battleSystem.enemyHud.UpdateHp();
            yield return ShowDamageDetails(damageDetails);
            if (damageDetails.Fainted)
            {
                yield return _battleSystem.dialogBox.TypeDialog(
                    $"{_battleSystem.enemyPokemon.Pokemon.Attributes.Name} Fainted ");
                _battleSystem.enemyPokemon.PlayFaintAnimation();

                yield return new WaitForSeconds(2f);
                EventManager.TriggerEvent(GenericEvents.EndBattle);
            }
            else
            {
                ChangeEnemyMove();
            }
        }
        
        IEnumerator ShowDamageDetails(DamageDetails damageDetails)
        {
            if (damageDetails.Critical > 1)yield return _battleSystem.dialogBox.TypeDialog("A critical hit!");
            if (damageDetails.TypeEffectiveness > 1f)
            {
                yield return _battleSystem.dialogBox.TypeDialog("It's super effective!");
            }
            else if (damageDetails.TypeEffectiveness < 1f)
            {
                yield return _battleSystem.dialogBox.TypeDialog("It's not very effective!");
            }
        }

        private void ChangeEnemyMove()
        {
            EventManager.TriggerEvent(GenericEvents.ChangeState, new Hashtable() {
                { GameplayHashtableParameters.ChangeState.ToString(),State.EnemyMove},
                { GameplayHashtableParameters.BattleSystem.ToString(), _battleSystem}
            });
        }
    }
}
