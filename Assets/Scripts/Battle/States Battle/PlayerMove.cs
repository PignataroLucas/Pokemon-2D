
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Battle.States_Battle
{
    public class PlayerMove <T> : States<T>
    {
        private BattleSystem _battleSystem;

        private int _currentMove;
        public PlayerMove(BattleSystem battleSystem)
        {
            _battleSystem = battleSystem;
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
        }
    }
}
