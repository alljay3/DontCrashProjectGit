using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Test : MonoBehaviour
{


    private InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }
    private void Update()
    {
        //Debug.Log(input.Player.Move.ReadValue<Vector2>());
    }
}
