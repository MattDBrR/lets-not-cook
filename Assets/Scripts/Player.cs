using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isWalking;
    private Vector3 lastInteractDirection;

    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private LayerMask countersLayerMask;
    private GameInput gameInput;
    

    private void Awake()
    {
        if (gameInput == null)
        {
            gameInput = GetComponent<GameInput>();
        }

        // Initialize based on player tag or name
        if (gameObject.tag == "Player1" || gameObject.name.Contains("Player1"))
        {
            gameInput.Initialize(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        }
        else if (gameObject.tag == "Player2" || gameObject.name.Contains("Player2"))
        {
            gameInput.Initialize(KeyCode.I, KeyCode.K, KeyCode.J, KeyCode.L);
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    public bool IsWalking()
    {
        return _isWalking;
    }

    private void HandleInteraction()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastInteractDirection = moveDir;
        }
        float interactionDistance = 2;
        if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit raycastHit, interactionDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;

        // Try to move in the full direction
        bool canMove = !Physics.CapsuleCast(
            transform.position,
            transform.position + Vector3.up * playerHeight,
            playerRadius,
            moveDir.normalized,
            moveDistance
        );

        if (canMove)
        {
            // Can move towards moveDir
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
        else
        {
            // Cannot move towards moveDir, try only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(
                transform.position,
                transform.position + Vector3.up * playerHeight,
                playerRadius,
                moveDirX.normalized,
                moveDistance
            );

            if (canMove)
            {
                // Can move only on the X axis
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move on X, try only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(
                    transform.position,
                    transform.position + Vector3.up * playerHeight,
                    playerRadius,
                    moveDirZ.normalized,
                    moveDistance
                );

                if (canMove)
                {
                    // Can move only on the Z axis
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                    moveDir = Vector3.zero;
                }
            }

            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        _isWalking = moveDir != Vector3.zero;
        if (_isWalking)
        {
            transform.forward = Vector3.Slerp(transform.forward, -moveDir, Time.deltaTime * rotateSpeed);
        }
    }
}
