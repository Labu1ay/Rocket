using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour {
    private float _YPosFirstObstacles = 36f;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle"){
            _YPosFirstObstacles += 9f;
            Transform parent = other.transform.parent.transform.parent.transform;
        
            parent.position = new Vector3(parent.position.x, _YPosFirstObstacles, parent.position.z);
            if(GameController.instance.GameStarted){
                parent.GetComponent<Obstacle>().SetRandomPosition();
                GameController.instance.AddScore(1);
            }
        }  
    }
}
