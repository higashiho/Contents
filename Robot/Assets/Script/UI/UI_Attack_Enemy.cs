using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Attack_Enemy : MonoBehaviour
{
    
    private Text text;      //�e�L�X�g�i�[�p
    public int DefaultStatus = 0;       //�X�e�[�^�X�����l

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
        text.text = "Attack: " + DefaultStatus;
    }
}
