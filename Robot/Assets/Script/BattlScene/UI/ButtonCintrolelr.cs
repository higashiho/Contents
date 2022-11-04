using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCintrolelr : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //スクリプト格納用
    [SerializeField] 
    private Battl_EnemyController battl_EnemyController;    //スクリプト格納用
    [SerializeField] 
    private TextController textController;    //スクリプト格納用

    private int plasPoint = 1;              // 加算する値
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //攻撃回数加算
    public void AttackUpButton()
    {
        battl_EnemyController.SetAttackPoint(plasPoint);
        battle_PlayerController.AttackPoint++;
        textController.StatusText();
    }
    //被弾回数加算
    public void DefenseUpButton()
    {
        battl_EnemyController.SetDefensePoint(plasPoint);
        battle_PlayerController.DefensePoint++;
        textController.StatusText();
    }
    //Hp加算
    public void HpUpButton()
    {
        battl_EnemyController.SetHpPoint(plasPoint);
        battle_PlayerController.Hp++;
        textController.OneMaxValue = true;
    }
}
