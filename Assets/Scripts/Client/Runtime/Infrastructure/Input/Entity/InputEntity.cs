using System;
using UnityEngine;
using UnityEngine.InputSystem;
using JackFrame;

namespace SJSJ.Client {

    public class InputEntity : InputEntityBase {

        public Vector2 MoveAxis { get; private set; }

        public InputEntity() {

            Player.Move.started += OnMove;
            Player.Move.performed += OnMove;

            Player.Enable();

        }

        void OnMove(InputAction.CallbackContext ctx) {
            this.MoveAxis = ctx.ReadValue<Vector2>();
        }

    }

}