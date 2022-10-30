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
        battl_EnemyController.AttackPoint++;
        battle_PlayerController.AttackPoint++;
    }
    //被弾回数加算
    public void DefenseUpButton()
    {
        battl_EnemyController.DefensePoint++;
        battle_PlayerController.DefensePoint++;
    }
    //Hp加算
    public void HpUpButton()
    {
        battl_EnemyController.Hp++;
        battle_PlayerController.Hp++;
        textController.OneMaxValue = true;
    }
}
