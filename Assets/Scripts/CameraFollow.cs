using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset;

    [SerializeField] float _cameraSmoothness;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _newPosition = Vector3.Lerp(transform.position, _offset + _target.position, _cameraSmoothness); 
        transform.position = _newPosition;
    }
}
