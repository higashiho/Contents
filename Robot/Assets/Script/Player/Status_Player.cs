using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Player : MonoBehaviour
{
    [SerializeField]
    private int attack = 0;
    [SerializeField]
    private int defense = 0;
    [SerializeField]
    private int jump = 0;
    [SerializeField]
    private int statusUp = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AttackItem")
        {
            attack += statusUp;
        }
        if(other.gameObject.tag == "DefenseItem")
        {
            defense += statusUp;
        }
    }
}
