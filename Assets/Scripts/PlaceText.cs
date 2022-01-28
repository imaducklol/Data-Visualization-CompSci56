using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceText : MonoBehaviour
{
    public Transform endzone0;
    public Transform endzone1;
    public Transform endzone2;
    public Transform endzone3;
    public Transform endzone4;
    public Transform endzone5;

    public Transform text0;
    public Transform text1;
    public Transform text2;
    public Transform text3;
    public Transform text4;
    public Transform text5;

    // Start is called before the first frame update
    void Start()
    {
        text0.position = endzone0.position;
        text1.position = endzone1.position;
        text2.position = endzone2.position;
        text3.position = endzone3.position;
        text4.position = endzone4.position;
        text5.position = endzone5.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
