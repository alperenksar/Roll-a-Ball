using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float _horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up,-_rotationSpeed*_horizontalInput*Time.deltaTime);
    }
}
