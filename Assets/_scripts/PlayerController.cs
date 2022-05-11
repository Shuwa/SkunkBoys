
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float gravityValue = -5.81f;

    private Vector3 playerVelocity;
    private Vector3 move;


    public int score;




    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;

        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    public void OnMove(InputAction.CallbackContext context)

    {
        Vector2 movement = context.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y);
    }

    public void IncreaseScore(int value)
    {
        score += value;
        Debug.Log("Player score: " + score);
    }

}

































