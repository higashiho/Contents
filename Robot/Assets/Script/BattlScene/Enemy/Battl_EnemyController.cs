using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_EnemyController : MonoBehaviour
{

    public float Speed; //�v���C���[�̃X�s�[�h

    private RectTransform rect; //�g�����X�t�H�[���i�[�p

    [SerializeField]
    private float random;       //�����_���l�i�[�p

    private float Min = 0, Max = 2; //�����_���̍ŏ��l�A�ő�l

    private float change = 1;   //�E�����̕ύX�l

    private bool wait = false;  //��~
    private float waitTime = 5.0f;  //��~����
    public float Judges;       //�E������


    public int AttackPoint; //�U����
    public int DefensePoint;    //�h���
    public int Hp;   //�q�b�g�|�C���g
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
        //�E
        if (Judges >= change)
            rect.localPosition += new Vector3(Speed, 0, 0);
        //��
        else
            rect.localPosition -= new Vector3(Speed, 0, 0);
    }

   

    //�ܕb�Ɉ�������ς���
    private IEnumerator waitJudge()
    {
        //�O���P��
        Judges = Random.Range(Min, Max);
        yield return new WaitForSeconds(waitTime);
        wait = false;
    }
}
