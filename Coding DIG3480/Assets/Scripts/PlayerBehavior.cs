using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    
    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimit;
    public float verticalScreenLimit;
    public GameObject bulletPrefab;
    public int lives;
    public GameObject exsplosionPreFab;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        speed = 6.5f;
        lives = 3;
        horizontalScreenLimit = 14.36f;
        verticalScreenLimit = -3.47f;
    }

    // Update is called once per frame
    void Update()
    {
       Movement();
       Shooting();

    }

    void Movement()
    {
                horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if(transform.position.x > horizontalScreenLimit) 
        {
            //I am outside the screen from right
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y,0);
        } 
        else if (transform.position.x < -horizontalScreenLimit)
        {
            //I am outside the screen from the left
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y,0);
        } 
        else if (transform.position.y >= 0f) 
        {
            //I am touching the screen from top/middle
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= verticalScreenLimit) 
        {
            //I am touching the screen from bottom
            transform.position = new Vector3(transform.position.x, verticalScreenLimit, 0);
        }
    }

    void Shooting()
    {
        //if press SPACE, create a bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            //Game Over
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Instantiate(exsplosionPreFab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }




}
