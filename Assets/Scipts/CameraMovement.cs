using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // [SerializeField]
    // private float horizontalSpeed = 2.0F;
    //[SerializeField]
    //private float verticalSpeed = 2.0F;
    //[SerializeField]
    //private float minAngle = -45.0f;
    //[SerializeField]
    //private float maxAngle = 45.0f;

    //float v = 0;

    //  float h = 0;

    // GameObject character;

    [SerializeField]
    private Transform camHolder;
    [SerializeField]
   
    





    private void Awake()
    {
        //myVector = new Vector3(camHolder.position.x+n, camHolder.position.y, camHolder.position.z);
        //GameObject camObject = (GameObject)Instantiate(cameraMain, myVector, camHolder.rotation);
        //camObject.transform.SetParent(camHolder);
        transform.SetParent(camHolder);
       
    }


    private void Start()
    {
      //  character = this.transform.parent.gameObject;
      //  Debug.Log(character);
    }

    // Update is called once per frame
    void Update()
    {


       
      //  h = horizontalSpeed * Input.GetAxis("Mouse X");   //moving side
       // character.transform.Rotate(0, h, 0);

     //   v -= verticalSpeed * Input.GetAxis("Mouse Y"); //- for invert axis  moving up+down

     //   v = Mathf.Clamp(v, minAngle, maxAngle);


        // transform.eulerAngles = new Vector3(v,0,0);


       // float yAngle = transform.localEulerAngles.y;

       // transform.localEulerAngles = new Vector3(v, yAngle, 0);

        // transform.Rotate(-v, 0, 0);
        // transform.Rotate(Vector3.up,-2*Time.deltaTime);


    }
}
