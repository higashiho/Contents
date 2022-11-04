using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Enemy : MonoBehaviour
{
    private static int attack = 0;
    private static int defense = 0;
    [SerializeField]
    private int jump = 0;
    [SerializeField]
    private int statusUp = 1;
    [SerializeField]
    private int defenceUp = 1;

    [SerializeField]
    private UI_Attack_Enemy ui_Attack_Enemy;

    public static int GetAttack() {return attack;}  // アタックの値取得
    public static int GetDefense() {return defense;}    // ディフェンスの値取得
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�X�e�[�^�X�A�b�v��UI
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttackItem")
        {
            attack += statusUp;
        }
        if (other.gameObject.tag == "DefenseItem")
        {
            defense += statusUp;
        }
    }
}
