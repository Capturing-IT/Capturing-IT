using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    private bool isTaken = false;

    private Vector2 flagStartPosition;

    private void Start()
    {
        flagStartPosition = new Vector2(36.27f, 1.58f);

        transform.position = flagStartPosition;
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        print("Colliding");

        if (collider.gameObject.CompareTag("Player") && !isTaken)
        {
            // Does player already have a flag? Is there some reason it shouldn't be able to pick up the flag

            // activate hasflag on player?

            pickUp(collider.gameObject.GetComponent<SpriteRenderer>());
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

    public void resetFlag(SpriteRenderer playerFlagSprite)
    {
        isTaken = false;

        playerFlagSprite.enabled = false;

        transform.position = flagStartPosition;
        // set active
            // Should the flag be invulnerable for a few seconds?
    }
}
