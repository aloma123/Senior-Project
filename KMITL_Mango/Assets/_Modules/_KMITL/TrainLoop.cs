using UnityEngine;

public class TrainLoop : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 5f;

    public Vector3 startPosition;
    private Vector3 destination;

    void Start()
    {
        destination = targetPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            transform.position = startPosition;
        }
    }
}