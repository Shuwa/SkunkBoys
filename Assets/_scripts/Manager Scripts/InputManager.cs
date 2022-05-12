using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public PlayerController playerController;

    private void Awake()
    {
        if (playerPrefab != null)
        {

            playerController = GameObject.Instantiate(playerPrefab, GameManager.instance.spawnPoints[0].transform.position, transform.rotation).GetComponent<PlayerController>();
            transform.parent = playerController.transform;
            transform.position = playerController.transform.position;
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        playerController.OnMove(context);
    }



}
