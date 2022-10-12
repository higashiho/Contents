using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUp_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject statusUI;//�㏸����UI
    [SerializeField]
    private GameObject CoveredObject;//�X�e�[�^�X���㏸����I�u�W�F�N�g
    [SerializeField]
    private Vector3 AdjPosition;//UI�o���ʒu�̒����p

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void ViewDamage(int _damage)//�X�e�[�^�X�A�b�v�����̏㏸
    {
        GameObject _damageObj = Instantiate(statusUI);
        _damageObj.GetComponent<TextMesh>().text = _damage.ToString();//int��string�Ƃ��Ĉ���
        _damageObj.transform.position = CoveredObject.transform.position + AdjPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttackItem")
        {
            ViewDamage(1);//�i�j���̐������\�������
        }
        if (other.gameObject.tag == "DefenceItem")
        {
            ViewDamage(1);//�i�j���̐������\�������
        }
    }
}
