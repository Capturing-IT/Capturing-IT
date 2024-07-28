using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;


    //Movement Data
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private Vector2 startPosition = Vector2.zero;

    private Vector2 movementInput = Vector2.zero;

    private Vector2 prevMoveDir = Vector2.zero;

    //dash controls
    static public float dashDuration = 1.0f;
    private float counter = dashDuration;
    static public float dashLength = 5.0f;
    static public float dashRecovery = 3.0f;
    enum DashPhase {ACTIVE, RECOVERY, NONE};
    [SerializeField] private DashPhase dashState = DashPhase.NONE;

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

    public void OnDash(InputAction.CallbackContext context) {
        if (dashState == DashPhase.NONE)
            dashState = DashPhase.ACTIVE;
    }


    void Update()
    {
        // Normalizing the input doesn't allow the controller from being able to diff "walk" to "run"

        switch(dashState) {

            case DashPhase.ACTIVE: {
                float speed = dashLength/dashDuration;
                counter -= Time.deltaTime;
                rb.linearVelocity = prevMoveDir * speed;
                if (counter <= 0) {
                    dashState = DashPhase.RECOVERY;
                    rb.linearVelocity = Vector2.zero;
                }
                break;
            }


            case DashPhase.RECOVERY: {
                counter += Time.deltaTime;
                
                if (counter >= dashRecovery) {
                    counter = dashDuration;
                    dashState = DashPhase.NONE;
                }
                break;
            }

            case DashPhase.NONE: {
                movementInput.Normalize();
                rb.linearVelocity = playerSpeed * movementInput;
                prevMoveDir = movementInput;
                break;
            }

            default: {
                break;
            }
        }


    }
}