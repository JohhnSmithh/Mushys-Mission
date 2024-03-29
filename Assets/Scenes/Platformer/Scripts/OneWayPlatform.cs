using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    // components
    private CompositeCollider2D compositeCollider;

    // variables
    private InputHelper.OctoDirection direction;
    private bool isOverlappingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // components
        compositeCollider = GetComponent<CompositeCollider2D>();

        // variables
        isOverlappingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        // update current direction
        direction = InputHelper.GetOctoDirectionHeld();

        // disable one way collisions if holding down
        if(direction == InputHelper.OctoDirection.Down || direction == InputHelper.OctoDirection.DownLeft || direction == InputHelper.OctoDirection.DownRight)
        {
            if (!compositeCollider.isTrigger) // only disable if not already disabled
                compositeCollider.isTrigger = true; ; // set collider as a trigger
        }
        else
        {
            if(compositeCollider.isTrigger && !isOverlappingPlayer) // only enable if not already enabled and if not overlapping the player (prevents resnapping player to platform)
                compositeCollider.isTrigger = false; // reset collider as NOT a trigger
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOverlappingPlayer = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isOverlappingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOverlappingPlayer = false;
        }
    }
}
