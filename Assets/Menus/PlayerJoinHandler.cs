using UnityEngine;

public class PlayerJoinHandler : MonoBehaviour
{
    public int numPlayers = 0;
    public GameObject[] joinText;
    public GameObject[] avatarSprite;

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
    }
}
