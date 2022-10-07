using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Item : MonoBehaviour
{

    private ItemController itemController;  //カウント変数値増加用

    private GameObject itemControl;        // Item生成管理用

    private Col_Enemy col_Enemy;           // Item所持制限用
    private Col_Player col_Player;         // Item所持制限用

    private GameObject Enemy;              // Col_Enemy取得用
    private GameObject Player;             // Col_Player取得用
    // Start is called before the first frame update
    void Start()
    {
        itemControl = GameObject.Find("ItemControl");

        Enemy = GameObject.Find("Enemy");
        Player = GameObject.Find("Player");

        itemController = itemControl.gameObject.GetComponent<ItemController>();

        col_Enemy = Enemy.gameObject.GetComponent<Col_Enemy>();
        col_Player = Player.gameObject.GetComponent<Col_Player>();
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
            if(col_Player.HaveCount == 1)
            this.gameObject.transform.parent = other.gameObject.transform;
        }
        //敵に当たったら子になって一緒に動く
        if (other.gameObject.tag == "Enemy")
        {
            if (col_Enemy.HoveCount == 0)
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
