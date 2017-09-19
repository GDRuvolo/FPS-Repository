using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField]
    GameObject playerScoreboardItem;

    [SerializeField]
    Transform playerScoreboardList;


    private void OnEnable()
    {
        // Get an array of players
        Player[] players = GameManager.GetAllPlayers();

        foreach (Player player in players)
        {
            //Debug.Log(player.username + " | " + player.kills + " / " + player.deaths);
            GameObject itemGO = (GameObject)Instantiate(playerScoreboardItem, playerScoreboardList);
            PlayerScoreBoardItem item = itemGO.GetComponent<PlayerScoreBoardItem>();
            if(item != null)
            {
                item.Setup(player.username, player.kills, player.deaths);
            }
        }
        
    }

    private void OnDisable()
    {
        //Clean up out list of items
        foreach(Transform child in playerScoreboardList)
        {
            Destroy(child.gameObject);
        }

    }
}

