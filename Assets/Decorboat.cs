using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorboat : MonoBehaviour
{
    float Timec = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timec += Time.deltaTime;

        float x = 5 * 5 * Timec;
        float y = 0;
        float z = 5*5*Timec;
        
        transform.position=new Vector3(10*x, y, 10*z);
    }
}
