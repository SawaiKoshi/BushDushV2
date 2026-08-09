using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private CharacterController controller;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    private void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) input.y += 1f;
            if (Keyboard.current.sKey.isPressed) input.y -= 1f;
            if (Keyboard.current.dKey.isPressed) input.x += 1f;
            if (Keyboard.current.aKey.isPressed) input.x -= 1f;
        }

        Vector3 move = new Vector3(input.x, 0f, input.y);

        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
