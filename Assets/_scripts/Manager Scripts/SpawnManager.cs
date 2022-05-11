using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] coins;

    public float XMin, XMax;
    public float ZMin, ZMax;


    private void Start()
    {
        StartCoroutine(SpawnCoins());

    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 4f));
            if (GameManager.instance.playerList.Count > 1)
            {
                Instantiate(coins[0], RandomSpawnPosition(), transform.rotation);
            }

        }
    }

    Vector3 RandomSpawnPosition()
    {
        float randomX = Random.Range(XMin, XMax);
        float randomZ = Random.Range(ZMin, ZMax);
        return new Vector3(randomX, 0.5f, randomZ);
    }


}
