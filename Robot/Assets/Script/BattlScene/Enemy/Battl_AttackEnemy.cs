using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_AttackEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;  //弾のプレハブ

    private GameObject bulletPrefab;    //子オブジェクト変更用

    //private bool one = true;    //一回だけ処理

    [SerializeField]
    private GameObject Enemy;   //敵


    private RectTransform rect; //トランスフォーム格納用


    [SerializeField]
    private int attack = 0;     //攻撃できる回数

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if (attack > 0)
        {
            bulletPrefab = Instantiate(bullet, transform.position, transform.rotation);
            bulletPrefab.transform.SetParent(Enemy.transform);
            attack--;
        }
    }
}
