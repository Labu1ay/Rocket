using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour {
    [SerializeField] private Transform _target;
    private void LateUpdate() {
        if(_target.position.y >= transform.position.y){
            transform.position = new Vector3(transform.position.x, _target.position.y, transform.position.z);
        }    
    } 
}
