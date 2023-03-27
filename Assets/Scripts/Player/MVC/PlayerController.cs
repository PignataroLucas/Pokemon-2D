using System;
using System.Collections;
using UnityEngine;
using Unity;

namespace Player.MVC
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerModel _model;

        private void Awake()
        {
            _model = GetComponent<PlayerModel>();
        }

        private void Update()
        {
            _model.Movement();
        }
    }
    
}
