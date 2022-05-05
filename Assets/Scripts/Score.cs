using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoretxt;
    public Stackdetect stack;
    public Timer timeremaining;
    public Count unloaded;
    float points;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void print()
    {
        Debug.Log(" You scored "+ points.ToString()+ " Nice! ");
        UnityEditor.EditorApplication.isPlaying = false;
    }
    // Update is called once per frame
    void Update()
    {

        points = (stack.defaultheight * 100) + (timeremaining.time) + (unloaded.unload*100);
        scoretxt.text =" Score : " + points.ToString();

    }
}
