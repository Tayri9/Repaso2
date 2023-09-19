using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 iniPos;
    public Vector3 finalPos;
    public float speed = 5;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = iniPos;
    }

    // Update is called once per frame
    void Update()
    {
        rb.position += new Vector2(-speed * Time.deltaTime, 0);

        if (transform.position.x < finalPos.x)
        {
            Destroy(this);
        }
    }
}
