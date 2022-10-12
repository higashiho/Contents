using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

    public int HaveCount = 0;   //�����Ă��
    private int maxHaveCount = 1;    //�J�E���g��������ő�l
    private bool isHit;         // �v���C���[�̍U�����󂯂Ă��邩
   [SerializeField]
    private int loopCount = 4;
    [SerializeField]
    private float flashInterval = 0.5f;
    [SerializeField]
    private MeshRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //�A�C�e����������狒�_�ɋA��
        if (other.gameObject.tag == "AttackItem" || other.gameObject.tag == "DefenseItem")
        {
            if (HaveCount < maxHaveCount)
                HaveCount++;
            enemycontroller.HaveItem = true;   // �A�C�e�������t���OON
            
        }
        //���_�ɋA������V�����A�C�e�������ɍs��
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false;  // �A�C�e�������t���OOFF
            if (HaveCount > 0)
                HaveCount--;
        }
        // player�̍U�����󂯂���...
        if(other.gameObject.tag == "Bat")
        {
            enemycontroller.b_move_ok = false;  // �G�l�~�[�s���\�t���OOFF
            enemycontroller.HaveItem = false;   // �A�C�e�������t���OOFF
            if (HaveCount > 0)
                HaveCount--;
            if (isHit)
                return;
            else
                StartCoroutine(Hit());
           // enemycontroller.b_move_ok = false;  // �G�l�~�[�s���\�t���OOFF
            //enemycontroller.HaveItem = false;   // �A�C�e�������t���OOFF
            //if (HaveCount > 0)
             //   HaveCount--;
        }
    }

    IEnumerator Hit()
    {
        isHit = true;

        // �_�Ń��[�v
        for(int i = 0; i < loopCount; i++)
        {
            yield return new WaitForSeconds(flashInterval);
            sprite.enabled = false;

            yield return new WaitForSeconds(flashInterval);
            sprite.enabled = true;
        }

        isHit = false;
    }
}
