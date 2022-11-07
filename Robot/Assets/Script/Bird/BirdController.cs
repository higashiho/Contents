using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private const float speed = 20.0f;                  // 挙動スピード
    [SerializeField, HeaderAttribute("攻撃するキャラ")]
    private GameObject target;                          // 突撃するキャラ

    private Vector3 homePos;                            // 初期位置

    private bool back = false;                          // 地面に当たったか

    private float destroyTime = 3.0f;                   // 消えるまでの時間

    [SerializeField]
    private GameObject markingPrefab;                   // プレハブ取得用
    private bool onMove = false;

    private GameObject marking;

    // trueかfalseをランダムにどちらか返す
    private bool randomBool()
    {
        int max = 2;
        return Random.Range(0, max) == 0;
    }


    void Awake()
    {
        if(randomBool())
            target = GameObject.FindWithTag("Player");
        else
            target = GameObject.FindWithTag("Enemy");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target.transform.position);

        homePos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(onMove)
            move();
        else 
            tagetMarking();
    }

    private void move()
    {
        if(!back)
            this.transform.position += transform.forward * speed * Time.deltaTime;
        else
            this.transform.position = Vector3.MoveTowards(transform.position, homePos, speed * Time.deltaTime);

        if(back && homePos == this.transform.position)
            Destroy(this.gameObject, destroyTime);

    }

    public void GoBack()
    {
        transform.LookAt(homePos);
        back = true;
    }

    private void tagetMarking()
    {
        if(marking == null)
            marking = Instantiate(markingPrefab, target.transform.position, Quaternion.identity);

        float m_waitTime = 2.0f;
        Debug.Log(m_waitTime);

        while(true)
        {
            m_waitTime -= Time.deltaTime;
            Debug.Log(m_waitTime);
            if(m_waitTime <= 0)
            {
                onMove = true;
                break;
            }
        }
    }
}
