using UnityEngine;

public class FlyingًEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float distanceX = 5f;
    [SerializeField] private float distanceY = 3f;
    private Vector2 startPos;
    private Vector2 targetPos;
    private bool movingToTarget = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector2(distanceX, distanceY);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 destination = movingToTarget ? targetPos : startPos;
        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {
            movingToTarget = !movingToTarget;
        }
    }
}