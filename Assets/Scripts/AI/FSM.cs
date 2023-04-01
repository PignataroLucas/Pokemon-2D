using System.Collections.Generic;

namespace AI
{
    public class FSM <T>
    {
        States<T> _currentState;
        List<States<T>> _states = new List<States<T>>();

        public States<T> Current { get { return _currentState; } }

        private bool _init;

        public FSM(States<T> init) 
        {
            _currentState= init;
        }


        public void OnUpdate() 
        {
            if(_init == false)
            {
                _currentState.OnEnter();
                _init = true;
            }
            _currentState.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            _currentState.OnFixedUpdate();
        }

        public void Transition(T input)
        {
            var newState = _currentState.GetState(input);
            if (newState == null) return;
            _currentState.OnSleep();
            _currentState = newState;
            _currentState.OnEnter();
        }


    }

    public static class State
    {
        public const string Start = "Start";
        public const string PlayerAction = "PlayerAction";
        public const string PlayerMove = "PlayerMove";
        public const string EnemyMove = "EnemyMove";
        public const string Busy = "Busy";
    }

    public static class GameState
    {
        public const string World = "World";
        public const string Battle = "Battle";
    }
}