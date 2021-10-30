using System.Collections;
using System.Collections.Generic;
using Components;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputReader : MonoBehaviour
    {
        public void OnTap(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            if (Camera.main is null) return;
            
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit))
            {
                hit.collider.GetComponent<DigComponent>().Dig();
            }
        }
    }
}
