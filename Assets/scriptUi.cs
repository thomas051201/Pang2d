using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class scriptUi : MonoBehaviour
{
    bool labelFPS = false, labelPosition = false;
    float delay = 2.0f;
    float FPS;
    //Texture tex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {


        //GUI.Label(new Rect(140, 25, 100, 20), FPS.ToString());

        if (GUI.Button(new Rect(20, 20, 100, 20), "Button FPS"))
        {
            labelFPS = !labelFPS;
            print(labelFPS);
            print(FPS);
        }
        if (GUI.Button(new Rect(20, 50, 100, 20), "Button Position"))
        {
            labelPosition = !labelPosition;
            print(labelPosition);
            print(transform.position.x);
            print(transform.position.y);
        }
        delay += Time.deltaTime;

        if (labelFPS)
        {
            GUI.Label(new Rect(140, 20, 100, 20), FPS.ToString());
            if (delay > 1)
            {
                delay = 0;
                FPS = 1 / Time.deltaTime;

            }
        }
        if (labelPosition)
        {
            GUI.Label(new Rect(140, 50, 100, 20), Mathf.Round(transform.position.x).ToString() + "/" + Mathf.Round(transform.position.y).ToString()); //mathRound permet d'arrondir a l'unité 
        }
    }
}
