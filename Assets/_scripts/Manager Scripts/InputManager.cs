using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public PlayerController playerController;

    private void Awake()
    {
        if (playerPrefabs != null)
        {

            playerController = GameObject.Instantiate(playerPrefabs[GetComponent<PlayerInput>().playerIndex], GameManager.instance.spawnPoints[0].transform.position, transform.rotation).GetComponent<PlayerController>();
            transform.parent = playerController.transform;
            transform.position = playerController.transform.position;
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        playerController.OnMove(context);
    }



}
