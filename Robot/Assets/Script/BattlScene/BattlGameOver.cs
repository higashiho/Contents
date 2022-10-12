using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattlGameOver : MonoBehaviour
{

    [SerializeField]
    private Battle_PlayerController battle_PlayerController;        //�X�N���v�g�i�[�p

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOvber(); 
    }
    private void gameOvber()
    {
        if (battle_PlayerController.Hp <= 0)
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
