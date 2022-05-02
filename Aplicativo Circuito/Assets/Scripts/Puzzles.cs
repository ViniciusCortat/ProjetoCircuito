using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Puzzles
{
    private Puzzles() {
        Status = new List<string>();
        for(int i = 0; i < 15; i++) {
            Status.Add("Incompleto");
        }
    }

    private static Puzzles _instance;

    public static Puzzles GetInstance() {
        if(_instance == null) {
            _instance = new Puzzles();
        }
        return _instance;
    }

    private List<string> Status;

    public string GetStatus(int i) {
        return Status[i];
    }

    public void SetStatus(string status, int i) {
        if(Status[i] == "Incompleto" || Status[i] == "Completo") {
            Status[i] = status;
        }
        
    }
}
