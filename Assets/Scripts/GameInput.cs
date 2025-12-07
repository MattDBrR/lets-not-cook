using UnityEngine;

public class GameInput : MonoBehaviour
{
    private Vector2 _movementInput;
    private KeyCode keyUp;
    private KeyCode keyDown;
    private KeyCode keyLeft;
    private KeyCode keyRight;

    public void Initialize(KeyCode up, KeyCode down, KeyCode left, KeyCode right)
    {
        keyUp = up;
        keyDown = down;
        keyLeft = left;
        keyRight = right;
    }

    private void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(keyUp)) vertical += 1f;
        if (Input.GetKey(keyDown)) vertical -= 1f;
        if (Input.GetKey(keyLeft)) horizontal -= 1f;
        if (Input.GetKey(keyRight)) horizontal += 1f;

        _movementInput = new Vector2(horizontal, vertical);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        return _movementInput.normalized;
    }
}