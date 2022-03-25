using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int _score;
    public Text _scoretxt;
    private void UpdateScore()
    {
       _scoretxt.text = "Score -- " + _score.ToString();
    }
    private void Update() {
        UpdateScore();
    }
}
