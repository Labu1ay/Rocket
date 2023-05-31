using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RocketMove : MonoBehaviour {
    private Rigidbody _rigidbody;
    [SerializeField] private float _forceValue;
    private Vector2 _touchStartPosition;
    private Vector2 _touchPosition;
    private bool _isTouched;
    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update() {
        
        if(Input.GetMouseButtonDown(0)){
            if(GameController.instance.GameStarted == false){
                GameController.instance.GameStarted = true;
                _forceValue *= 2f;
            }

            _isTouched = true;
            _touchStartPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0)){
            _touchPosition = Input.mousePosition;
            Vector3 torque = new Vector3(0f, 0f, Mathf.Clamp((3f * Vector2.Distance(new Vector2(0f, _touchPosition.x),
                new Vector2(0f, _touchStartPosition.x)) / Screen.width) * 45f * (_touchPosition.x >= _touchStartPosition.x ? 1 : -1) , -45f, 45f));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-torque), Time.deltaTime *500f);
        }
        if(Input.GetMouseButtonUp(0)){
            _isTouched = false;
        }
        if(_isTouched == false){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.deltaTime * 100f);
        }
    }
    private void FixedUpdate() {
        if(Input.GetMouseButton(0) || GameController.instance.GameStarted == false){
            _rigidbody.AddForce(transform.up *_forceValue, ForceMode.VelocityChange);
        }     
    }
}
