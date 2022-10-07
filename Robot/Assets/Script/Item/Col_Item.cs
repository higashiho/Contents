using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Item : MonoBehaviour
{

    private ItemController itemController;  //カウント変数値増加用

    private GameObject itemControl;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    private HoldItem hiScript_p;
    private HoldItem hiScript_e;
    private bool hold_p;
    private bool hold_e;

    // Start is called before the first frame update
    void Start()
    {
        itemControl = GameObject.Find("ItemControl");

        itemController = itemControl.gameObject.GetComponent<ItemController>();
        hiScript_p = player.GetComponent<HoldItem>();
        hiScript_e = enemy.GetComponent<HoldItem>();
        hold_p = false;
        hold_e = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        hold_p = hiScript_p.holding;
        hold_e = hiScript_e.holding;
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーになったら子になって一緒に動く
        if (other.gameObject.tag == "Player")
        {
            if(!hold_p)
                this.gameObject.transform.parent = other.gameObject.transform;
        }
       
        //敵に当たったら子になって一緒に動く
        if (other.gameObject.tag == "Enemy")
        {
            if (!hold_e)
                this.gameObject.transform.parent = other.gameObject.transform;
        }
        //どちらかの拠点に当たると消える
        if (other.gameObject.tag == "Home")
        {
            itemController.Count++;
            Destroy(this.gameObject);
        }
    }
}
