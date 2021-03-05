using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainStationBehaviour : MonoBehaviour
{
    private const string MENU = "Menu";
    public GameObject hudCompletou;
    private ScoreTMP scoreTMP;
    private TrainController trainController;
    public Animator animationCurtain;
    public Text coalCollectedText;
    public SurfaceEffector2D accelerator;
    public int coalCollected;
    private bool nextlevel;

    public void Start() {
        //ultimo trilho para freiar na estação
        FaseDetail faseDetail = FindObjectOfType(typeof(FaseDetail)) as FaseDetail;
        accelerator = faseDetail.accelerator;
        scoreTMP = FindObjectOfType(typeof(ScoreTMP)) as ScoreTMP;
        trainController = FindObjectOfType(typeof(TrainController)) as TrainController;
        //hudCompletou.SetActive(false);
        nextlevel = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            if(!nextlevel){
                StartCoroutine(nextLevel());
            }
        }else if (other.gameObject.CompareTag("Coal"))
        {
            coalCollected++;
        }
    }

    public void BtnNextLevel(){
        StartCoroutine(BtnNextLevelIEnum());
    }
    public IEnumerator BtnNextLevelIEnum(){
        if(coalCollected==0){
            coalCollected =1;
        }
        scoreTMP.AddScoreTotal(trainController.scoreFaseAtual * coalCollected);
        trainController.addScore(trainController.scoreFaseAtual * coalCollected);
        yield return new WaitForSeconds(1.5f);
        animationCurtain.SetBool("end", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void btnMenu() {
         SceneManager.LoadScene(MENU);
    }

    IEnumerator nextLevel()
    {
        nextlevel = true;
        yield return new WaitForSeconds(1f);
        coalCollectedText.enabled = true;
        coalCollectedText.text = "Coal Collected: " + coalCollected;
        accelerator.speed = 0;
        yield return new WaitForSeconds(1.5f);
        int fase = TrainDAO.getInstance().loadInt("Fase");
        print("FASE "+fase);
        if(fase < 1 ){
            fase = 1;
        }
        fase = fase + 1;
        //salva no formato para abrir a proxima fase
        TrainDAO.getInstance().saveInt(TrainDAO.FASE,fase);
        //salva no formato apara abrir o menu selct fdase ESTRELAS
        TrainDAO.getInstance().saveInt(TrainDAO.FASE+fase,1);

        //abrir painel completou
        hudCompletou.SetActive(true);

        //mostrar X2
        string p = (" X "+ coalCollected.ToString());
        trainController.TextScoreXcoal.text = p;

        trainController.TextScoreAtualFinalLevel.text = trainController.scoreFaseAtual.ToString();

        //calcular pontos
        //scoreTMP.AddScoreTotal(pontos);
        //fecha a tela preta

    }
}
