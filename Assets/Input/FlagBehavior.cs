using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    bool isTaken = false;

    private void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !isTaken)
        { 
            // Does player already have a flag? Is there some reason it shouldn't be able to pick up the flag

            // teleport flag elsewhere
            // set invisible
            // activate hasflag on player

        }
    }

    public void pickUp(SpriteRenderer playerFlagSprite)
    {
        isTaken = true;
        transform.position = new Vector3(Mathf.Infinity, Mathf.Infinity, 0);

        playerFlagSprite.enabled = true;
    }

    public void dropFlag(SpriteRenderer playerFlagSprite)
    {
        isTaken = false;

        playerFlagSprite.enabled = false;
    }

    public void resetFlag()
    {
        isTaken = false;
        // teleport to the middle
        // set active
            // Should the flag be invulnerable for a few seconds?
    }
}
