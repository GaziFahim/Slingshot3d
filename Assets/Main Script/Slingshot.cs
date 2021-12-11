using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public static Slingshot instnce;
    public Transform LeftPoint;
    public Transform RightPoint;
    public Transform CenterPoint;

    LineRenderer slingshotString;


    //public LineRenderer Line;
    //public GameObject ball;
    //public GameObject LeftSide;
    //public GameObject RightSide;
    //public GameObject Hook;
    private void Awake()
    {
        instnce = this;
    }
    void Start()
    {
        //Line.positionCount = 5;
      slingshotString = GetComponent<LineRenderer>();
    }

    void Update()
    {

        //Line.SetPosition(0, LeftSide.transform.position);
        //if (ball == null || ball.GetComponent<SpringJoint>() == null)
        //{
        //    Line.SetPosition(1, Hook.transform.position);
        //    Line.SetPosition(2, Hook.transform.position);
        //    Line.SetPosition(3, Hook.transform.position);
        //}
        //else
        //{
        //    Line.SetPosition(1, new Vector3(ball.transform.position.x - 0.5f, ball.transform.position.y, ball.transform.position.z + 1f));
        //    Line.SetPosition(2, new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z - 1f));
        //    Line.SetPosition(3, new Vector3(ball.transform.position.x + 0.5f, ball.transform.position.y, ball.transform.position.z + 1f));
        //}
        //Line.SetPosition(4, RightSide.transform.position);

         slingshotString.SetPositions(new Vector3[3] { LeftPoint.position, CenterPoint.position, RightPoint.position });

    }

    
}
