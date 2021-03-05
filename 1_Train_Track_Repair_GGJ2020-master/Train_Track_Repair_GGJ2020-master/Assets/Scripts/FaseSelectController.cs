using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseSelectController : MonoBehaviour
{
    private const string FASE_DAO = "Fase";
    private const string BTN_ABERTO = "BtnAberto";
    private const string BTN_ABERTO_1 = "BtnAbertto1";
    private const string BTN_ABERTO_2 = "BtnAbertto2";
    private const string BTN_ABERTO_3 = "BtnAbertto3";
    public List <GameObject> listaFases;
    // Start is called before the first frame update
    void Start()
    {
        // muda para retrato para escolher as fases
        //Screen.orientation = ScreenOrientation.Portrait;
        int indice = 1;
        //percorre as fases para abrir 
        foreach (var item in listaFases)
        {
            AbrirFase(item, indice);
            indice++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AbrirFase(GameObject obj, int indice) {
        //verifica se a fase ja foi aberta: 1 aberto, 0 fechado
        int fase = TrainDAO.getInstance().loadInt(FASE_DAO+indice);
        if(fase == 1){
            //abre a imagem com a quantidade de estrelas correspondentes
            int QtdEstrelas = TrainDAO.getInstance().loadInt(TrainDAO.ESTRLA_FASES+indice);
            for (int i = 0; i < obj.transform.childCount; i++){
                GameObject child = obj.transform.GetChild(i).gameObject;

                if(QtdEstrelas == 0){
                    if(child.name == BTN_ABERTO) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(QtdEstrelas == 1){
                    if(child.name == BTN_ABERTO_1) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(QtdEstrelas == 2){
                    if(child.name == BTN_ABERTO_2) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(QtdEstrelas == 3){
                    if(child.name == BTN_ABERTO_3) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(child.name == "Text") {
                    child.SetActive(true);
                }
                
            }
        }

    }

    public void btnAbrirFase(int fase) {
         //salva no formato para abrir a proxima fase
        TrainDAO.getInstance().saveInt(TrainDAO.FASE,fase);
        SceneManager.LoadScene("LevelDinamico");
    }
}
