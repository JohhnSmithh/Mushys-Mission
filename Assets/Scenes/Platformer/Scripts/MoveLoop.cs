using UnityEngine;

public class MoveLoop : MonoBehaviour
{
    // variables
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private float cycleTime;
    [SerializeField] private float pauseTime;
    private float cycleTimer;
    private float pauseTimer;
    private bool forward;

    // Start is called before the first frame update
    void Start()
    {
        // set initial position/state
        transform.position = new Vector3(startPos.x, startPos.y, 0);

        // set initial state
        forward = true;
        cycleTimer = 0;
        pauseTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseTimer > pauseTime) // check for pause delay before resuming motion
        {
            if (forward) // moving towards end position
            {
                if (cycleTimer > cycleTime) // lock to end position
                {
                    transform.position = new Vector3(endPos.x, endPos.y, 0);
                    forward = !forward;
                    cycleTimer = 0;
                    pauseTimer = 0;
                }
                else // move platform
                {
                    transform.position = Vector3.Lerp(startPos, endPos, cycleTimer / cycleTime);
                    cycleTimer += Time.deltaTime;
                }
            }
            else // moving towards start position
            {
                if (cycleTimer > cycleTime) // lock to start position
                {
                    transform.position = new Vector3(startPos.x, startPos.y, 0);
                    forward = !forward;
                    cycleTimer = 0;
                    pauseTimer = 0;
                }
                else // move platform
                {
                    transform.position = Vector3.Lerp(endPos, startPos, cycleTimer / cycleTime);
                    cycleTimer += Time.deltaTime;
                }
            }
        }
        else // increment pause timer
        {
            pauseTimer += Time.deltaTime;
        }
        
    }
}
