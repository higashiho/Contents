using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Attack_Enemy : MonoBehaviour
{
    
    private Text text;      //テキスト格納用

    [SerializeField]
    private Status_Enemy status_Enemy;      //スクリプト格納用

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

    //EnemyのAttackTextの表示
    private void DefStatus()
    {
        text.text = "Attack: " + status_Enemy.Attack + "\nDefence"
            + status_Enemy.Defense;
    }
}
