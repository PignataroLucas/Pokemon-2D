using System.Collections;
using UnityEngine;
using Utility.Managers;


namespace Player.MVC
{
    public class PlayerModel : MonoBehaviour
    {
        private const float MoveSpeed = 5f;

        private bool _isMoving;

        private Vector2 _input;

        private Animator _animator;

        public LayerMask grassLayer;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Movement()
        {
            if (!_isMoving)
            {
                _input.x = Input.GetAxisRaw("Horizontal");
                _input.y = Input.GetAxisRaw("Vertical");

                if (_input.x != 0) _input.y = 0;
                
                if (_input != Vector2.zero)
                {
                    _animator.SetFloat($"MoveX",_input.x);
                    _animator.SetFloat($"MoveY",_input.y);
                    
                    var targetPos = transform.position;
                    targetPos.x += _input.x;
                    targetPos.y += _input.y;

                    StartCoroutine(Move(targetPos));
                }
            }
            _animator.SetBool($"IsMoving",_isMoving);
        }

        IEnumerator Move(Vector3 targetPos)
        {
            _isMoving = true;
            
            while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position , targetPos , MoveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = targetPos;

            _isMoving = false;

            CheckForEncounters();

        }

        private void CheckForEncounters()
        {
            if (Physics2D.OverlapCircle(transform.position , 0.2f , grassLayer) != null)
            {
                if (Random.Range(1,101) <= 10)
                {
                    _animator.SetBool($"IsMoving",false);
                    RandomEncounter();
                }
            }
        }

        private void RandomEncounter()
        {
            EventManager.TriggerEvent(GenericEvents.RandomEncounter);
        }
    }
}
