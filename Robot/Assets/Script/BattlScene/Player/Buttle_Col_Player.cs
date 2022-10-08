using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttle_Col_Player : MonoBehaviour
{
    [SerializeField]
    private Battl_AttackEnemy battl_AttackEnemy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col) 
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackPoint")
            battl_AttackEnemy.Attack();
    }
    
}
