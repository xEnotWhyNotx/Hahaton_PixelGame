using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    private float distance;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            // Враг подошел к нам
        }

    }
}
