using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Marking : MonoBehaviour
{

    private Col_Bird colBird;
    private GameObject bird;

    private bool damage = false;        // ダメージ
    
    public bool GetDamage() {return damage;}
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindWithTag("Bird");
        colBird = bird.GetComponent<Col_Bird>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(colBird.GetOnDamage())
            {
                other.GetComponent<PlayerController>().FindMarking(this.gameObject);
                damage = true;
            }

        }
        if(other.gameObject.tag == "Enemy")
        {
            if(colBird.GetOnDamage())
            {
                other.GetComponent<EnemyController>().FindMarking(this.gameObject);
                damage = true;
            }

        }
    }
}
