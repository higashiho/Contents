using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Enemy : MonoBehaviour
{
    public int Attack = 0;
    public int Defense = 0;
    [SerializeField]
    private int jump = 0;
    [SerializeField]
    private int statusUp = 1;
    [SerializeField]
    private int defenceUp = 1;

    [SerializeField]
    private UI_Attack_Enemy ui_Attack_Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ステータスアップのUI
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttackItem")
        {
            Attack += statusUp;
        }
        if (other.gameObject.tag == "DefenseItem")
        {
            Defense += statusUp;
        }
    }
}
