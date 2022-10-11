using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

    public int HaveCount = 0;   //持ってる個数
    private int maxHaveCount = 1;    //カウントが増える最大値
    private bool isHit;         // プレイヤーの攻撃を受けているか
   [SerializeField]
    private int loopCount = 4;
    [SerializeField]
    private float flashInterval = 0.5f;
    [SerializeField]
    private MeshRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //アイテムを取ったら拠点に帰る
        if (other.gameObject.tag == "AttackItem" || other.gameObject.tag == "DefenseItem")
        {
            if (HaveCount < maxHaveCount)
                HaveCount++;
            enemycontroller.HaveItem = true;   // アイテム所持フラグON
            
        }
        //拠点に帰ったら新しいアイテムを取りに行く
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false;  // アイテム所持フラグOFF
            if (HaveCount > 0)
                HaveCount--;
        }
        // playerの攻撃を受けたら...
        if(other.gameObject.tag == "Bat")
        {
            enemycontroller.b_move_ok = false;  // エネミー行動可能フラグOFF
            enemycontroller.HaveItem = false;   // アイテム所持フラグOFF
            if (HaveCount > 0)
                HaveCount--;
            if (isHit)
                return;
            else
                StartCoroutine(Hit());
           // enemycontroller.b_move_ok = false;  // エネミー行動可能フラグOFF
            //enemycontroller.HaveItem = false;   // アイテム所持フラグOFF
            //if (HaveCount > 0)
             //   HaveCount--;
        }
    }

    IEnumerator Hit()
    {
        isHit = true;

        // 点滅ループ
        for(int i = 0; i < loopCount; i++)
        {
            yield return new WaitForSeconds(flashInterval);
            sprite.enabled = false;

            yield return new WaitForSeconds(flashInterval);
            sprite.enabled = true;
        }

        isHit = false;
    }
}
