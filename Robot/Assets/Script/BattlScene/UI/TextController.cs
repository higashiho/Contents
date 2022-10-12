using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //�X�N���v�g�i�[�p

    [SerializeField]
    private Battl_EnemyController battl_EnemyController;    //�X�N���v�g�i�[�p

    [SerializeField]
    private Text playerAttackText = default; //player�A�^�b�N�e�L�X�g
    [SerializeField]
    private Text playerDefenseText = default; //player�f�B�t�F���X�e�L�X�g
    [SerializeField]
    private Text enemyAttackText = default; //enemy�A�^�b�N�e�L�X�g
    [SerializeField]
    private Text enemyDefenseText = default; //enemy�f�B�t�F���X�e�L�X�g

    [SerializeField]
    private Slider playerHpSlider;    //playerHp�X���C�_�[

    [SerializeField]
    private Slider enemyHpSlider;   //EnemyHp�X���C�_�[

    public bool OneMaxValue = true;   //�X���C�_�[�}�b�N�X�o�����[�A�^�b�`�p
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        statusText();
        statusSlider();
    }

    //Status�\��
    private void statusText()
    {
        playerAttackText.text = "Attack �~ " + battle_PlayerController.AttackPoint;
        playerDefenseText.text = "Defense �~ " + battle_PlayerController.DefensePoint;

        enemyAttackText.text = "Attack �~ " + battl_EnemyController.AttackPoint;
        enemyDefenseText.text = "Defense �~ " + battl_EnemyController.DefensePoint;
    }

    //�X���C�_�[�\��
    private void statusSlider()
    {
        if (OneMaxValue)
        {
            playerHpSlider.maxValue = battle_PlayerController.Hp;
            enemyHpSlider.maxValue = battl_EnemyController.Hp;
        }
        playerHpSlider.value = battle_PlayerController.Hp;
        enemyHpSlider.value = battl_EnemyController.Hp;
        OneMaxValue = false;
    }

}
