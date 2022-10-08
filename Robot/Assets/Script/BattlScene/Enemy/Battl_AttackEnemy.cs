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
    private GameObject Enemy;   //�G


    private RectTransform rect; //�g�����X�t�H�[���i�[�p


    [SerializeField]
    private int attack = 0;     //�U���ł����

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if (attack > 0)
        {
            bulletPrefab = Instantiate(bullet, transform.position, transform.rotation);
            bulletPrefab.transform.SetParent(Enemy.transform);
            attack--;
        }
    }
}
