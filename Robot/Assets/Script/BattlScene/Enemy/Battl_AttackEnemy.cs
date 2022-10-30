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
    private GameObject canvas;   //Chara格納Canvas


    private RectTransform rect; //トランスフォーム格納用

    [SerializeField]
    private Battl_EnemyController battl_EnemyController;    //スクリプト格納用

    [SerializeField]
    private float waitTime = 3.0f;  //コルーチン遅延用

    private bool waitShot = false;  //打ち止める

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvas = GameObject.Find("Chara");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //攻撃できるか
    public void Attack()
    {
        if (battl_EnemyController.AttackPoint > 0 && !waitShot)
        {
            waitShot = true;
            StartCoroutine(waitAttack());
        }
    }
    //一回打ったら少し待つ
    private IEnumerator waitAttack()
    {
        //battl_EnemyController.AttackPoint--;
        bulletPrefab = Instantiate(bullet, transform.position, transform.rotation);
        bulletPrefab.transform.SetParent(canvas.transform);
        yield return new WaitForSeconds(waitTime);
        waitShot = false;
    }
}
