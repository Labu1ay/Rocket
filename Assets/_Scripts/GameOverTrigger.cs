using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other) => GameController.instance.StartEventGameOver();  
}
