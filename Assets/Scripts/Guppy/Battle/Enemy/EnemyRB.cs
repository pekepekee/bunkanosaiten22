using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRB : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;

    public void AddForce(Vector2 force)
    {
        rb2d.AddForce(force);
    }
}
