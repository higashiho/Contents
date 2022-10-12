using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Defence_Enemy : MonoBehaviour
{
    private Text text;      //�e�L�X�g�i�[�p
    [SerializeField]
    private UI_Attack_Enemy ui_Attack_Enemy;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DefenceStatus();
    }

    //Enemy��DefenceText�̕\��
    private void DefenceStatus()
    {
        text.text = "Defence: " + ui_Attack_Enemy.DefaultStatus;
    }
}
