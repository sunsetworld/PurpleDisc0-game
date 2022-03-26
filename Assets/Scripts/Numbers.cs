using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    int hundred = 100;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(hundred);
            hundred++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
