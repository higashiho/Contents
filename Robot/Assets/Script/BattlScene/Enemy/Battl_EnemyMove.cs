using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_EnemyMove : MonoBehaviour
{

    [SerializeField]
    private float speed; //�v���C���[�̃X�s�[�h

    private RectTransform rect; //�g�����X�t�H�[���i�[�p

    [SerializeField]
    private float random;       //�����_���l�i�[�p

    private float Min = 0, Max = 2; //�����_���̍ŏ��l�A�ő�l

    private float change = 1;   //�E�����̕ύX�l

    private bool wait = false;  //��~
    private float waitTime = 5.0f;  //��~����

    [SerializeField]
    private float judges;       //�E������
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            StartCoroutine(waitJudge());
            wait = true;
        }
        move();
    }

    private void move()
    {
        if (judges <= change)
            rect.localPosition += new Vector3(speed, 0, 0);
        else
            rect.localPosition -= new Vector3(speed, 0, 0);
    }

    //�ܕb�Ɉ�������ς���
    private IEnumerator waitJudge()
    {
        //�O���P��
        judges = Random.Range(Min, Max);
        yield return new WaitForSeconds(waitTime);
        wait = false;
    }
}
