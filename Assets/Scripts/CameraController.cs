using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
   private Transform transform;
   private Vector3 direction = Vector3.zero;

   [SerializeField] [Range(0f, 10f)] private float damp = 0.5f;
   [SerializeField] [Range(0f, 1000f)] private float scroll = 0.5f;
   [SerializeField] [Range(0f, 30f)] private float mouseSens = 10f;
   
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    
    void Update()
    {
       direction = transform.position;
       float mw = Input.GetAxis("Mouse ScrollWheel");
       if (Input.GetKey(KeyCode.W))
          direction += transform.up;
       if (Input.GetKey(KeyCode.S))
           direction -= transform.up;
       if (Input.GetKey(KeyCode.A))
           direction -= transform.right;
       if (Input.GetKey(KeyCode.D))
           direction += transform.right;
       if (Input.GetKey(KeyCode.Mouse2))
           direction += new Vector3(-Input.GetAxis("Mouse X"),-Input.GetAxis("Mouse Y"), 0) * mouseSens;
       if (mw > 0.1)
           direction += transform.forward * scroll;
       if (mw < -0.1)
           direction -= transform.forward * scroll;

       transform.position = Vector3.Lerp(transform.position, direction, damp);
    }
}
