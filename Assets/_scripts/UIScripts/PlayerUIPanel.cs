using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerUIPanel : MonoBehaviour
{
    public PlayerController player;

    public void AssignPlayer (int index)

  
    {
        StartCoroutine(AssignPlayerDelay(index));
        
    }

    IEnumerator AssignPlayerDelay(int index)
    {
        yield return new WaitForSeconds(0.01f);
        player = GameManager.instance.playerList[index].GetComponent<InputManager>().playerController;
        

     }   

   

   
}
