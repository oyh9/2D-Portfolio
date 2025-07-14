using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float arrivalThreshold = 0.05f;

    private Vector3 currentTarget;
    private GameObject playerOnPlatform = null;
    private Vector3 lastPlatformPosition;

    private void Start()
    {
        currentTarget = pointB.position;
        lastPlatformPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 oldPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < arrivalThreshold)
        {
            currentTarget = (currentTarget == pointA.position) ? pointB.position : pointA.position;
        }

        // 플랫폼이 이동한 만큼 플레이어도 이동
        if (playerOnPlatform != null)
        {
            Vector3 delta = transform.position - oldPosition;
            playerOnPlatform.transform.position += delta;
        }

        lastPlatformPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            playerOnPlatform = other.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            playerOnPlatform = null;
        }
    }
}
