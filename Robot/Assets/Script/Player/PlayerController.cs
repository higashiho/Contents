using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 7.0f;

    private bool b_left;
    private bool b_right;
    
    void Start()
    {
        b_left = true;
        b_right = true;
    }

   
    void Update()
    {
        move();
    }

    void move()
    {
        if (Input.GetKey("w"))
        {
            // TODO DS‰Ÿ‚µ‚½‚Æ‚«‚¤‚¦‚¢‚­
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            //player.transform.Rotate(new Vector3(0, 90, 0));
            player.transform.position += transform.forward * speed * Time.deltaTime;
            b_left = true;
            b_right = true;
        }

        if (Input.GetKey("a"))
        {
            //player.transform.Rotate(new Vector3(0, 0, 0));
            if (b_left)
            {
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                player.transform.Rotate(new Vector3(0, -90, 0));
                b_left = false;
                b_right = true;
            }
            player.transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
            //player.transform.Rotate(new Vector3(0, 90, 0));
            player.transform.position += transform.forward * speed * Time.deltaTime;
            b_left = true;
            b_right = true;
        }
        if (Input.GetKey("d"))
        {
            if (b_right)
            {
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                player.transform.Rotate(new Vector3(0, 90, 0));
                b_right = false;
                b_left = true;
            }
            player.transform.position += transform.forward * speed * Time.deltaTime;
        }
      

    }
}
