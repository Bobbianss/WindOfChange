using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 4f;
    
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, _rotationSpeed) * Time.deltaTime);
    }
}
