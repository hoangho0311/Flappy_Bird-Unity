using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true) return;

        transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
