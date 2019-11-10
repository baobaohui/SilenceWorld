using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryThisTime : MonoBehaviour
{
    public float destoryTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destoryTime);
    }

    
}
