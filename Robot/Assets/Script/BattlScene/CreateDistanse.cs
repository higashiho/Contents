using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDistanse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    //‹——£
    public int distanse(GameObject Player, GameObject Enemy)
    {
        Vector2 posP = Player.transform.position;
        Vector2 posE = Enemy.transform.position;
        float fDis = posP.x - posE.x;
        int iDis = (int)fDis;
        return iDis;
    }
}
