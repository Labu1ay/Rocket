using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    [HideInInspector] public bool GameStarted;
    [SerializeField] private UnityEvent GameOver;
    [SerializeField] private UnityEvent GameStart;
    private int _score;
    [SerializeField] private Text _textScore;
    [SerializeField] private Text _textRecord;
    private void Start(){
        if(instance == null) instance = this; 
        UpdateTextRecord();
        UpdateTextScore();

    }
    public void StartEventGameOver() => GameOver.Invoke();
    public void StartEventGameStart() => GameStart.Invoke();
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void AddScore(int value){
        _score += value;
        UpdateTextScore();
    }
    private void UpdateTextScore() => _textScore.text = "Счёт: " + _score.ToString();
    private void UpdateTextRecord() => _textRecord.text = "Лучший Результат: " + PlayerPrefs.GetInt("Record");
    public void CheckRecord(){
        if(_score > PlayerPrefs.GetInt("Record")){
            PlayerPrefs.SetInt("Record", _score);
        }
    }
}
