using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private KeyCode KeyA = KeyCode.A;
    private KeyCode KeyD = KeyCode.D;
    private KeyCode KeySpace = KeyCode.Space;

    public event UnityAction KeyAPressed;
    public event UnityAction KeyDPressed;
    public event UnityAction KeySpacePressed;
    public event UnityAction MoveKeysUnpressed;

    private void Update()
    {
        if (Input.GetKey(KeyA))
        {
            KeyAPressed?.Invoke();
        }

        if (Input.GetKey(KeyD))
        {
            KeyDPressed?.Invoke();
        }

        if (Input.GetKey(KeySpace))
        {
            KeySpacePressed?.Invoke();
        }

        if (Input.GetKey(KeyA) == false && Input.GetKey(KeyD) == false)
        {
            MoveKeysUnpressed?.Invoke();
        }
    }
}