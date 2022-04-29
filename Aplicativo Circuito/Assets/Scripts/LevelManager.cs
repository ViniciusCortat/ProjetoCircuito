using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public List<Image> Edges;
    public List<GameObject> Locks;
    public List<Image> StatusBall;

    private Puzzles puzzles;
    
    void Start()
    {
        puzzles = Puzzles.GetInstance();
        RemoveLock();
        StatusBallColor();
    }

    private void RemoveLock() {
        for(int i=0;i<17;i++) {
            if(puzzles.GetStatus(i) != "Incompleto") {
                Edges[i].color = Color.yellow;
                Locks[i].SetActive(false);
            }
        }
    }

    private void StatusBallColor() {
        for(int i=0;i<18;i++) {
            
            if(puzzles.GetStatus(i) == "Incompleto") {
                StatusBall[i].color = Color.red;
            }
            if(puzzles.GetStatus(i) == "Completo") {
                StatusBall[i].color = Color.yellow;
            }
            if(puzzles.GetStatus(i) == "Best") {
                StatusBall[i].color = Color.green;
            }
        }
    }
}
