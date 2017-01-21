using UnityEngine;
using System.Collections;

public class PlayerVars : MonoBehaviour
{
    public float lStickX;
    public float lStickY;

    public float aButton;
    public float bButton;
    public float xButton;
    public float yButton;

    public float rStickX;
    public float rStickY;
    public float shootStickSensitivity = 0.88f;

    //public float swingTrig;
    //public float shootTrig;

    //public string swing = "RT";
    //public string shoot = "LT";

    public Vector3 mousePos;

    void Update()
    {
        lStickX = Input.GetAxis("Horizontal");
        lStickY = Input.GetAxis("Vertical");

        rStickX = Input.GetAxis("RHorizontal");
        rStickY = Input.GetAxis("RVertical");

        aButton = Input.GetAxis("");

        //swingTrig = Input.GetAxis(swing);
        //shootTrig = Input.GetAxis(shoot);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 mousePt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    rStickX = mousePt.x / mousePt.magnitude;
        //    rStickY = mousePt.y / mousePt.magnitude;
        //}
        //if (Input.GetMouseButtonDown(0))
        //{

        //shootTrig = 1.0f;

        //}
    }

    public void newGame()
    {
        //damageRatio = 0.0f;
    }
}
