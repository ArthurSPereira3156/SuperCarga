using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTMP : MonoBehaviour
{
    public TMPro.TMP_Text m_textMeshPro;
    private const string label = "{0}";
    public float m_frame;
    public int _qtdMoedaMax;
    // Start is called before the first frame update

    public void Awake ()
    {
        //m_textMeshPro = this.GetComponent<TMPro.TMP_Text>();
        _qtdMoedaMax = 0;
        m_frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_qtdMoedaMax > m_frame){
            m_textMeshPro.SetText(label, (int)m_frame);
            m_frame += 1;// * Time.deltaTime;
        } else {
             m_textMeshPro.SetText(label, (int)_qtdMoedaMax);
        }
    }
    public void AddScoreTotal(int qtd){
        _qtdMoedaMax  += qtd;
    } 
}
