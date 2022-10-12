using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Attack_Enemy : MonoBehaviour
{
    
    private Text text;      //テキスト格納用
    public int DefaultStatus = 0;       //ステータス初期値

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
        text.text = "Attack: " + DefaultStatus;
    }
}
