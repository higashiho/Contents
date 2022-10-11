using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    private bool isFadeOut = false; //�t�F�[�h�A�E�g�t���O
    private bool isFadeIn = true;   //�t�F�[�h�C���t���O
    private float fadeSpeed = 0.75f;    //�t�F�C�h�A�E�g�X�s�[�h
    [SerializeField] private Image fadeImage = default;
    private float red, green, blue, alpha;  // ��, ��, ��, �����x
    private string afterScene;
    public SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        SetRGBA(0, 0, 0, 1);
        SceneManager.sceneLoaded += fadeInStart;    // �V�[���J�ڊ������Ƀt�F�[�h�C���J�n
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)   // �t�F�[�h�C���t���O��true�̂Ƃ�1��Đ�
        {
            alpha -= fadeSpeed * Time.deltaTime;    // �����x�����X�ɏグ��(���邭�Ȃ�)
            SetColor();
            if (alpha <= 0) // �����x��0��菬�����Ȃ��(fadeImage�����S�ɓ����ɂȂ�)
                isFadeIn = false;
        }
        if (isFadeOut)  // �t�F�[�h�A�E�g�t���O��true�̂Ƃ�
        {
            alpha += fadeSpeed * Time.deltaTime;    // �����x�����X�ɏグ��(�Â��Ȃ�)
            SetColor();
            if (alpha >= 1) // �����x��1���傫���Ȃ��(fadeImage�����S�ɕ\������Đ^���ÂɂȂ�)
            {
                isFadeOut = false;
                sceneController.SceneMove = true;
                SceneManager.LoadScene(afterScene); // ���̃V�[���Ɉڂ�
            }
        }
    }

    private void fadeInStart(Scene scene, LoadSceneMode mode)   // �t�F�[�h�C�����n�܂�
    {
        isFadeIn = true;
    }

    public void fadeOutStart(int red, int green, int blue, int alpha, string nextScene) // �t�F�[�h�A�E�g���n�܂�
    {
        SetRGBA(red, green, blue, alpha);
        SetColor();
        isFadeOut = true;
        afterScene = nextScene;
    }

    private void SetColor()     // �F����֐�
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    private void SetRGBA(int r, int g, int b, int a)    // �F�̒l��ݒ肷��֐�
    {
        red = r;
        green = g;
        blue = b;
        alpha = a;
    }
}
