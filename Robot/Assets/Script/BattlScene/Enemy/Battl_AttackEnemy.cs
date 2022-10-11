using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_AttackEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;  //�e�̃v���n�u

    private GameObject bulletPrefab;    //�q�I�u�W�F�N�g�ύX�p

    //private bool one = true;    //��񂾂�����

    [SerializeField]
    private GameObject canvas;   //�G


    private RectTransform rect; //�g�����X�t�H�[���i�[�p

    [SerializeField]
    private Battl_EnemyController battl_EnemyController;    //�X�N���v�g�i�[�p

    [SerializeField]
    private float waitTime = 3.0f;  //�R���[�`���x���p

    private bool waitShot = false;  //�ł��~�߂�

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�U���ł��邩
    public void Attack()
    {
        if (battl_EnemyController.AttackPoint > 0 && !waitShot)
        {
            waitShot = true;
            StartCoroutine(waitAttack());
        }
    }
    //���ł����班���҂�
    private IEnumerator waitAttack()
    {
        battl_EnemyController.AttackPoint--;
        bulletPrefab = Instantiate(bullet, transform.position, transform.rotation);
        bulletPrefab.transform.SetParent(canvas.transform);
        yield return new WaitForSeconds(waitTime);
        waitShot = false;
    }
}
