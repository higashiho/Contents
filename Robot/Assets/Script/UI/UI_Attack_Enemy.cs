using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Attack_Enemy : MonoBehaviour
{
    
    private Text text;      //�e�L�X�g�i�[�p

    [SerializeField]
    private Status_Enemy status_Enemy;      //�X�N���v�g�i�[�p

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
        text.text = "Attack: " + status_Enemy.Attack + "\nDefence"
            + status_Enemy.Defense;
    }
}
