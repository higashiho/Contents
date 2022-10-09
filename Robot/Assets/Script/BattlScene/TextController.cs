using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //�X�N���v�g�i�[�p

    [SerializeField]
    private GameObject attackText = default; //�A�^�b�N�e�L�X�g
    [SerializeField]
    private GameObject defenseText = default; //�f�B�t�F���X�e�L�X�g
    [SerializeField]
    private GameObject junpText = default; //junp�e�L�X�g
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
        AttackText.text = "Attack �~ " + battle_PlayerController.AttackPoint;
        DefenseText.text = "Defense �~ " + battle_PlayerController.DefensePoint;
        JunpText.text = "Junp �~ " + battle_PlayerController.JunpPoint;
    }
}
