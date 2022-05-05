using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count: MonoBehaviour
{
    public int unload = 0;
    
    [SerializeField] private Text numtxt;
    [SerializeField]  bool inside = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "block")
        {
            inside = true;
            unload++; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "block")
        {
            inside = false;
            unload--; }
    }

    // Update is called once per frame
    void Update()
    {
      numtxt.text = "Unloaded : " + unload.ToString();
    }
}
