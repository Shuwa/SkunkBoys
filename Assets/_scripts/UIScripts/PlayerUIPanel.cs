using System.Collections;
using TMPro;
using UnityEngine;



//public class PlayerUIPanel : MonoBehaviour
//{
//    public TextMeshProUGUI playerName;
//    public TextMeshProUGUI playerScore;

//    public PlayerController player;



//    public void AssignPlayer(int index)
//    {
//        StartCoroutine(AssignPlayerDelay(index));
//    }


//    IEnumerator AssignPlayerDelay(int index)
//    {
//        yield return new WaitForSeconds(0.01f);
//        player = GameManager.instance.playerList[index].GetComponent<InputManager>().playerController;

//        SetupInfoPanel();

//    }
//    void SetupInfoPanel()
//    {
//        if (player != null)
//        {
//            player.OnScoreChanged += UpdateScore;
//            playerName.text = player.thisPlayerName.ToString();
//        }
//    }

//    private void UpdateScore(int score)
//    {
//        playerScore.text = score.ToString();

//    }
//}




