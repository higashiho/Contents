using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCintrolelr : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //�X�N���v�g�i�[�p
    [SerializeField] 
    private Battl_EnemyController battl_EnemyController;    //�X�N���v�g�i�[�p
    [SerializeField] 
    private TextController textController;    //�X�N���v�g�i�[�p
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�U���񐔉��Z
    public void AttackUpButton()
    {
        battl_EnemyController.AttackPoint++;
        battle_PlayerController.AttackPoint++;
    }
    //��e�񐔉��Z
    public void DefenseUpButton()
    {
        battl_EnemyController.DefensePoint++;
        battle_PlayerController.DefensePoint++;
    }
    //�W�����v�񐔉��Z
    public void HpUpButton()
    {
        battl_EnemyController.Hp++;
        battle_PlayerController.Hp++;
        textController.OneMaxValue = true;
    }
}
