using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //スクリプト格納用

    [SerializeField]
    private GameObject attackText = default; //アタックテキスト
    [SerializeField]
    private GameObject defenseText = default; //ディフェンステキスト
    [SerializeField]
    private GameObject junpText = default; //junpテキスト
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        statusText();
    }
    private void statusText()
    {
        Text AttackText = attackText.GetComponent<Text>();
        Text DefenseText = defenseText.GetComponent<Text>();
        Text JunpText = junpText.GetComponent<Text>();
        AttackText.text = "Attack × " + battle_PlayerController.AttackPoint;
        DefenseText.text = "Defense × " + battle_PlayerController.DefensePoint;
        JunpText.text = "Junp × " + battle_PlayerController.JunpPoint;
    }
}
