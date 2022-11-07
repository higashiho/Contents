using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 7.0f;
    [SerializeField]
    private float lowSpeed; //アイテムを持っている状態の自身のスピード

    private bool b_left;
    private bool b_right;
    private float Top;
    private float Bottom;
    private float Right;
    private float Left;

    public bool HaveItem = false;   //アイテムを持っているか
    void Start()
    {
        b_left = true;
        b_right = true;
        Top = 13.5f;
        Bottom = -13.5f;
        Right = 18.5f;
        Left = -18.5f;
    }

   
    void Update()
    {
        if (!HaveItem)
            move();
        else
            goAway();
    }

    void move()
    {
        if (Input.GetKey("w"))
        {
            
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            //player.transform.Rotate(new Vector3(0, 90, 0));
            if(player.transform.position.z < Top)
            player.transform.position += transform.forward * speed * Time.deltaTime;
            b_left = true;
            b_right = true;
        }

        if (Input.GetKey("a"))
        {
            if (b_left)
            {
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                player.transform.Rotate(new Vector3(0, -90, 0));
                b_left = false;
                b_right = true;
            }
            if (player.transform.position.x > Left)
            {
                player.transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey("s"))
        {
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
            if (player.transform.position.z > Bottom)
            {
                player.transform.position += transform.forward * speed * Time.deltaTime;
            }
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
            if (player.transform.position.x < Right)
            {
                player.transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
      

    }
    void goAway()
    {
        if (Input.GetKey("w"))
        {

            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            //player.transform.Rotate(new Vector3(0, 90, 0));
            if (player.transform.position.z < Top)
                player.transform.position += transform.forward * lowSpeed * Time.deltaTime;
            b_left = true;
            b_right = true;
        }

        if (Input.GetKey("a"))
        {
            if (b_left)
            {
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                player.transform.Rotate(new Vector3(0, -90, 0));
                b_left = false;
                b_right = true;
            }
            if (player.transform.position.x > Left)
            {
                player.transform.position += transform.forward * lowSpeed * Time.deltaTime;
            }
        }
        if (Input.GetKey("s"))
        {
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
            if (player.transform.position.z > Bottom)
            {
                player.transform.position += transform.forward * lowSpeed * Time.deltaTime;
            }
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
            if (player.transform.position.x < Right)
            {
                player.transform.position += transform.forward * lowSpeed * Time.deltaTime;
            }
        }


    }
}

