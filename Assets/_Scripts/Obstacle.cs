using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] private Transform _centerObstacle;
    public void SetRandomPosition() => _centerObstacle.position = new Vector3(Random.Range(-3.5f, 3.6f), 
                                                                              _centerObstacle.position.y, 
                                                                              _centerObstacle.position.z);
}
