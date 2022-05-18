using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RepetirModal : MonoBehaviour
{
    public CircuitManagerL CML;
    public TextMeshProUGUI repetirText;
    private int repeticao;
    
    void Start()
    {
        repeticao = 0;
        repetirText.text = $"Repetir <color=#00FF00>{repeticao}</color> vezes";
    }

    
    void Update()
    {
        
    }

    public void Minus() {
        if(repeticao > 0) {
            repeticao--;
        }
        UpdateText();
    }

    public void Plus() {
        if(repeticao < 9) {
            repeticao++;
        }
        UpdateText();  
    }

    public void Ok() {
        CML.AddRepetition(repeticao);
        repeticao = 0;
        UpdateText();
    }

    private void UpdateText() {
        repetirText.text = $"Repetir <color=#00FF00>{repeticao}</color> vezes";
    }
}
