using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private Vector2 startPosition = Vector2.zero;

    private Vector2 movementInput = Vector2.zero;

    private void Start()
    {
        startPosition = new Vector2(36f, 0);

        rb = gameObject.GetComponent<Rigidbody2D>();

        transform.position = startPosition;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        // Normalizing the input doesn't allow the controller from being able to diff "walk" to "run"

        movementInput.Normalize();
        rb.linearVelocity = playerSpeed * movementInput;
    }
}