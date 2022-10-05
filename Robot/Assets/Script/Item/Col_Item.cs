using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Item : MonoBehaviour
{

    private ItemController itemController;  //カウント変数値増加用

    private GameObject itemControl;
    // Start is called before the first frame update
    void Start()
    {
        itemControl = GameObject.Find("ItemControl");

        itemController = itemControl.gameObject.GetComponent<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーになったら子になって一緒に動く
        if (other.gameObject.tag == "Player")
        { 
            this.gameObject.transform.parent = other.gameObject.transform;
        }
        //敵に当たったら子になって一緒に動く
        if (other.gameObject.tag == "Enemy")
        {
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
