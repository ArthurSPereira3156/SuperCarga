using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseCOntroller : MonoBehaviour
{
    private GameObject casaFinalColisor ;
    private GameObject casaFinal ;
    public List<GameObject> fases;
    // Start is called before the first frame update
    void Awake() {
        print("carregando fase");
        carregarFase();
        print("FIM  carregando fase");
    }
    void Start()
    {
        
        casaFinalColisor = GameObject.Find("Station4");
        casaFinal = GameObject.Find("House");
        casaFinalColisor.transform.position = casaFinal.transform.position;
    }
    private void carregarFase() {
        int fase = TrainDAO.getInstance().loadInt("Fase");
        print("fase "+fase );
        if(fase < 1 ){
            fase = 1;
        }
        if(fase > (fases.Count-1)){
            fase = 1;
        }
        Instantiate (fases[fase], new Vector3(0,0,0),this.transform.rotation);
        TrainDAO.getInstance().saveInt("Fase",fase);
    }

}
