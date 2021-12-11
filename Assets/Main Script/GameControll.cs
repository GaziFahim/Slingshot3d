using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public GameObject objectplay;
    public float xpos,zpos;



    void Start()
    {
        InvokeRepeating("Spawnobj", 1, 6);
    }

    // Update is called once per frame



    public void Spawnobj()
    {

       xpos = Random.Range(-1.05f, 7.64f);
        zpos = Random.Range(32f,50f);


        Instantiate(objectplay, new Vector3(xpos, 4.21f, zpos), Quaternion.Euler(0f, 180f, 0f));
    }

}
