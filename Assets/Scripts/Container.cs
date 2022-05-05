using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Container : MonoBehaviour
{
    public AudioSource bang;
    [SerializeField] public bool inside = false;
    //[SerializeField] public Text numtxt;
    [SerializeField] public int innum ;


    


    // Start is called before the first frame update
    void Start()
    {
        
        bang = GetComponent<AudioSource>();
        //Loadtext ts = GetComponent<Loadtext>();
    }

    void OnCollisionEnter (Collision other) {

        bang.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        inside= true;
       // innum +=1;
        //numtxt.text = innum.ToString();
    }

    void OnTriggerExit(Collider other)
    {
        inside = false;
        //innum -= 1;
       // numtxt.text = innum.ToString();
    }

    // Update is called once per frame
    void Update()
    {



    }
}

