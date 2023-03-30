using UnityEngine;

namespace Battle.States_Battle
{
    public class StartBattle <T> : States<T>
    {
        public override void OnEnter()
        {
            Debug.Log("StartBattle State");
        }
    }
    
}
