using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour {
    public static GameController instance;
    [HideInInspector] public bool GameStarted;
    [SerializeField] private UnityEvent GameOver;
    private void Start(){
        if(instance == null) instance = this; 
    }
    public void StartEventGameOver() => GameOver.Invoke();
}
