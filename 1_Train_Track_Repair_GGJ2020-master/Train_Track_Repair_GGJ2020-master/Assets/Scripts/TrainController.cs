using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public int coins;
    public int diamantes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject);
            GameObject efeito =  Instantiate (GameObject.Find("EfeitoAmarelo"));
            efeito.gameObject.transform.localPosition = other.transform.position;
        }else if (other.gameObject.CompareTag("Diamante"))
        {
            diamantes++;
            Destroy(other.gameObject);
            GameObject efeito =  Instantiate (GameObject.Find("EfeitoARosa"));
            efeito.gameObject.transform.localPosition = other.transform.position;
        }
    }

}
