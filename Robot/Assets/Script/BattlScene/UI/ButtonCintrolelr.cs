using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCintrolelr : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //ƒXƒNƒŠƒvƒgŠi”[—p
    [SerializeField] 
    private Battl_EnemyController battl_EnemyController;    //ƒXƒNƒŠƒvƒgŠi”[—p
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //UŒ‚‰ñ”‰ÁZ
    public void AttackUpButton()
    {
        battl_EnemyController.AttackPoint++;
        battle_PlayerController.AttackPoint++;
    }
    //”í’e‰ñ”‰ÁZ
    public void DefenseUpButton()
    {
        battl_EnemyController.DefensePoint++;
        battle_PlayerController.DefensePoint++;
    }
    //ƒWƒƒƒ“ƒv‰ñ”‰ÁZ
    public void JunpUpButton()
    {
        battl_EnemyController.JunpPoint++;
        battle_PlayerController.JunpPoint++;
    }
}
