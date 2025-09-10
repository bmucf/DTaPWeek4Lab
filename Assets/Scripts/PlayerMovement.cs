using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbodyReference;
    public float moveSpeed;
    private Vector2 _moveDirection;

    public InputActionReference move;

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbodyReference.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }
}
