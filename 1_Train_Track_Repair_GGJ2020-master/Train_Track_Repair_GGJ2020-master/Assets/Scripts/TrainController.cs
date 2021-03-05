using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainController : MonoBehaviour
{

    public int scoreFaseAtual;
    public int scoreHud;
    public int coins;
    public int diamantes;
    public Text TextMoedas;
    public Text TextDiamantes;
    public Text TextScore;
    public Text TextScoreXcoal;
    public Text TextScoreAtualFinalLevel;
    // Start is called before the first frame update
    void Start()
    {
        AdMobController.getInstance().RequestBanner();
        //Screen.orientation = ScreenOrientation.LandscapeRight;
        scoreFaseAtual = 0;
        TextMoedas = GameObject.Find("TextMoedas").GetComponent<Text>();
        TextDiamantes = GameObject.Find("TextDiamantes").GetComponent<Text>();
        TextScore = GameObject.Find("TextScore").GetComponent<Text>();
        //TextScoreXcoal = GameObject.Find("txtScoreXX").GetComponent<Text>();
        //TextScoreAtualFinalLevel = GameObject.Find("txtScoreAtual").GetComponent<Text>();

        scoreHud = TrainDAO.getInstance().loadInt(TrainDAO.SCORE_TOTAL);
        TextScore.text = scoreHud.ToString().PadLeft(6, '0');

        diamantes = TrainDAO.getInstance().loadInt(TrainDAO.DIAMANTES);
        TextDiamantes.text = diamantes.ToString().PadLeft(4, '0');

        coins = TrainDAO.getInstance().loadInt(TrainDAO.COINS);
        TextMoedas.text = coins.ToString().PadLeft(4, '0');
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int qtd){
        scoreHud+=qtd;
        TextScore.text = scoreHud.ToString().PadLeft(6, '0');
        TrainDAO.getInstance().saveInt(TrainDAO.SCORE_TOTAL, scoreHud);
    }
    private void addCoins(){
        coins++;
        scoreFaseAtual++;
        TrainDAO.getInstance().saveInt(TrainDAO.COINS, coins);
    }
    private void addCDiamantes(){
        diamantes+=5;
        scoreFaseAtual++;
        TrainDAO.getInstance().saveInt(TrainDAO.DIAMANTES, diamantes);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin"))
        {
            addCoins();
            Destroy(other.gameObject);
            GameObject efeito =  Instantiate (GameObject.Find("EfeitoAmarelo"));
            efeito.gameObject.transform.localPosition = other.transform.position;
            
            TextMoedas.text = coins.ToString().PadLeft(4, '0');
        }else if (other.gameObject.CompareTag("Diamante"))
        {
            addCDiamantes();
            Destroy(other.gameObject);
            GameObject efeito =  Instantiate (GameObject.Find("EfeitoARosa"));
            efeito.gameObject.transform.localPosition = other.transform.position;
            
            TextDiamantes.text = diamantes.ToString().PadLeft(4, '0');
        }
    }

}
