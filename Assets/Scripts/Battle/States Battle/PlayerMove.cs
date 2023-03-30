
namespace Battle.States_Battle
{
    public class PlayerMove <T> : States<T>
    {
        private BattleSystem _battleSystem;

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
    }
}
