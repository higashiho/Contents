using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Player : MonoBehaviour
{
    [SerializeField]
    private PlayerController playercontroller;
    public int HaveCount = 0;  // 持ってる個数
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HaveCount > 1)
        {
            HaveCount = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // アイテムを取ったら拠点に帰る
        if (other.gameObject.tag == "AttackItem" || other.gameObject.tag == "DefenseItem")
        {
            HaveCount++;
            playercontroller.HaveItem = true;
        }
        // 拠点に帰ったら新しいアイテムを取りに行く
        if(other.gameObject.tag == "Home")
        {
            playercontroller.HaveItem = false;
            if (HaveCount > 0)
                HaveCount--;
        }
    }
}
