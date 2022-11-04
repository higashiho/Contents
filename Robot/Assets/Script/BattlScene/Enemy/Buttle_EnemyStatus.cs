using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttle_EnemyStatus : MonoBehaviour
{

    private int EnemyAttack, EnemyDefense, Hp;      // ステータス代入用

    // 変数取得用
    public int GetAttack(){return EnemyAttack;}
    public int GetDefense(){return EnemyDefense;}
    public int GetHp(){return Hp;}

    
    // Start is called before the first frame update
    void Start()
    {
        EnemyAttack = Status_Enemy.GetAttack();
        EnemyDefense = Status_Enemy.GetDefense();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatusUp()
    {
        EnemyAttack++;
        EnemyDefense++;
        Hp++;
    }
}
