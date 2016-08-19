using UnityEngine;
using System.Collections;

public class TelevisionCamMovement : MonoBehaviour {

    public Transform[] wayPoints;

    public int currentWayPoint;
    public int nextWayPoint;

    public float waitingTime = 1f;
    public float speed = 1f;

    Rigidbody rigid;
    float timer = 0f;
    bool isWaiting = true;

    public void Start()
    {
        currentWayPoint = Random.Range(0, wayPoints.Length);
        transform.position = wayPoints[currentWayPoint].position;

        rigid = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (isWaiting)
        {
            timer += Time.deltaTime;
            if (timer >= waitingTime)
            {
                isWaiting = false;
                getNextWayPoint();
                timer = 0f;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, wayPoints[nextWayPoint].position) <= 0.1f)
            {
                isWaiting = true;
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextWayPoint].position, step);
            }
        }
    }

    void getNextWayPoint()
    {
        nextWayPoint = Random.Range(0, wayPoints.Length);
        if(nextWayPoint == currentWayPoint)
        {
            getNextWayPoint();
        }
    }
}
