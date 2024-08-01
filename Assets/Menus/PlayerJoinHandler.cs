using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerJoinHandler : MonoBehaviour
{
    public int numPlayers = 0;
    public GameObject[] joinText;
    public GameObject[] avatarSprite;
    public List<PlayerInput> playerInputs;
    public List<GameObject> players;
    public GameObject playerManager;

    private void Start()
    {
        foreach (GameObject i in avatarSprite)
        {
            i.SetActive(false);
        }   
    }

    public void OnPlayerJoin()
    {
        joinText[numPlayers].SetActive(false);
        avatarSprite[numPlayers].SetActive(true);
        numPlayers++;
        playerInputs.Add(PlayerInput.all[numPlayers - 1]);
        players.Add(playerInputs[numPlayers - 1].gameObject);
        DontDestroyOnLoad(players[numPlayers - 1]);
    }
}
