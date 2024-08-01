using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuButtonActions : MonoBehaviour
{
    public List<PlayerInput> playerInputs;
    public void StartGame()
    {
        playerInputs = GameObject.Find("PlayerManager").GetComponent<PlayerJoinHandler>().playerInputs;
        foreach (PlayerInput i in playerInputs)
        {
            i.SwitchCurrentActionMap("Player");
        }
        SceneManager.LoadScene("TestAsset");
    }
}
