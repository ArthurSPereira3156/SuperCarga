﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDAO : MonoBehaviour
{
    public static TrainDAO instance;
    public static string FASE = "Fase";
    public static string ESTRLA_FASES = "EstrelasFase";
    public static string SCORE_TOTAL = "ScoreTotal";
    public static string COINS = "Moedas";
    public static string DIAMANTES = "Diamantes";
    public static TrainDAO getInstance() {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType<TrainDAO>();
        }
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void saveString(string chave, string valor) {
        PlayerPrefs.SetString(chave, valor);
    }
    public string loadString(string chave) {
        return PlayerPrefs.GetString(chave);
    }
    public void saveInt(string chave, int valor) {
        PlayerPrefs.SetInt(chave, valor);
    }
    public int loadInt(string chave) {
        return PlayerPrefs.GetInt(chave);
    }
 
}
