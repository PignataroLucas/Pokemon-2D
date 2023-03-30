using UnityEngine;

namespace Battle.States_Battle
{
    public class PlayerAction <T> : States<T>
    {

        private BattleSystem _battleSystem;
        private MonoBehaviour _monoBehaviour;

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
    }
}
