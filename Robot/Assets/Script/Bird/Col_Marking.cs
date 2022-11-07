using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Marking : MonoBehaviour
{

    private Col_Bird col_Bird;
    private GameObject bird;


    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindWithTag("Bird");
        col_Bird = bird.GetComponent<Col_Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(col_Bird.GetOnDamage())
            {
                //damage = true;
            }

        }
    }
}
