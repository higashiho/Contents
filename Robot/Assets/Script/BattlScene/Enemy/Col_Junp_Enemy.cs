using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Junp_Enemy : MonoBehaviour
{
    [SerializeField]
    private Battl_EnemyController battl_EnemyController;    //�X�N���v�g�i�[�p
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //�v���C���[�̋�������������W�����v����
        if (other.gameObject.tag == "PlayerBullet")
        {
            battl_EnemyController.Junp();
            battl_EnemyController.JunpPoint--;
        }
    }
}
