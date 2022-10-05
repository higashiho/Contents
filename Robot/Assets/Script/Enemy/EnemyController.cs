using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject Item;    //取得アイテム

    [SerializeField]
    private GameObject home;    //陣地

    private Vector3 enemyPosition;  //自分の位置

    [SerializeField]
    private float speed = 7.0f; //自身のスピード

    public bool HaveItem = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!HaveItem)
            move();
        if (HaveItem)
            goAway();
    }

    //挙動
    private void move()
    {
        enemyPosition = transform.position;
        Item = serchTag(gameObject, "Item");
        transform.LookAt(Item.transform);
        enemyPosition += transform.forward * speed * Time.deltaTime;
        transform.position = enemyPosition;
    }

    //アイテムをとった後の挙動
    private void goAway()
    {
        enemyPosition = transform.position;
        transform.LookAt(home.transform);
        enemyPosition += transform.forward * speed * Time.deltaTime;
        transform.position = enemyPosition;
    }

    //近くのオブジェクトを探索して入れる
    private GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;   //距離用一次変数
        float nearDis = 0;  //最も近いオブジェクトの距離
        GameObject targetObj = default;    //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、0であればオブジェクトを取得
            //一次変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }
}
