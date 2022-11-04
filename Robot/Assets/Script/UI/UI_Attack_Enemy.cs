using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Attack_Enemy : MonoBehaviour
{
    
    private Text text;      //�e�L�X�g�i�[�p

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DefStatus();
    }

    //Enemy��AttackText�̕\��
    private void DefStatus()
    {
        text.text = "Attack: " + Status_Enemy.GetAttack() + "\nDefence"
            + Status_Enemy.GetDefense();
    }
}
