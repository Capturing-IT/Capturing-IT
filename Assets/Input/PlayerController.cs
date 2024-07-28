using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float playerSpeed = 2.0f;

    private Vector2 movementInput = Vector2.zero;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        movementInput.Normalize();
        rb.linearVelocity = playerSpeed * movementInput;

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}
    }
}