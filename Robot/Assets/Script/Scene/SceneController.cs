using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private FadeController fadeController;
    [SerializeField] private GameObject FadeObject;
    public bool SceneMove = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();     // Esc�L�[�������ꂽ��A�v���I��
        }

        if (SceneMove)
        {
            if (Input.GetKeyDown(KeyCode.Return))   // Enter�L�[�������ꂽ�Ƃ�
            {
                if (SceneManager.GetActiveScene().name == "GameClearScene")     // ���݂̃V�[����GameClearScene�Ȃ�
                {
                    SceneMove = false;
                    fadeController.fadeOutStart(0, 0, 0, 0, "TittleScene");    // �t�F�[�h�A�E�g����TittleScene��ǂݍ���
                }
                if (SceneManager.GetActiveScene().name == "GameOverScene")     // ���݂̃V�[����GameOverScene�Ȃ�
                {
                    SceneMove = false;
                    fadeController.fadeOutStart(0, 0, 0, 0, "TittleScene");    // �t�F�[�h�A�E�g����TittleScene��ǂݍ���
                }
                if (SceneManager.GetActiveScene().name == "TittleScene")    // ���݂̃V�[����TittleScene�Ȃ�
                {
                    SceneMove = false;
                    fadeController.fadeOutStart(0, 0, 0, 0, "MainScene");    // �t�F�[�h�A�E�g����MainScene��ǂݍ���
                }
            }
        }
    }
}
