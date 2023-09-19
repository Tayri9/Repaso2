using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstaculo : MonoBehaviour
{    
    Vector3 iniPos = new Vector3(20, -8, 0);
    Vector3 finalPos = new Vector3(-20, -8, 0);
    public float speed = 20;
    Rigidbody2D rb;
    public int points = 0;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI pointsTextGameOver;
    [SerializeField] GameObject canvasEnd;
    public bool canMove = true;
    public GameObject fireBallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = iniPos;
        canvasEnd.SetActive(false);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rb.position += new Vector2(-speed * Time.deltaTime, 0);

            if (transform.position.x < finalPos.x)
            {
                transform.position = iniPos;
                points++;
                pointsText.SetText("Points: " + points);
                if (points % 10 == 0)
                {
                    speed += 10;
                }
                if (points % 5 == 0)
                {
                    Instantiate(fireBallPrefab);
                }
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            canMove = false;
            pointsTextGameOver.SetText("Points: " + points);
            canvasEnd.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        points = 0;
        speed = 20;
        pointsText.SetText("Points: " + points);
        transform.position = iniPos;
        canvasEnd.SetActive(false);
        canMove = true;
    }
}
