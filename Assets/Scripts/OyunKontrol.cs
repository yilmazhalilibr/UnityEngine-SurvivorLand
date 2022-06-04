using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject zombi;
    private float zamanSayaci;
    private float olusumSureci = 3f;
    public Text puanText;
    private int puan;
    public OyuncuKontrol oKontrol;
    // Start is called before the first frame update
    void Start()
    {
        zamanSayaci = olusumSureci;
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci<0)
        {
            Vector3 pos = new Vector3(Random.Range(439.6f,604f), 20.99185f,Random.Range(644f,446f));
            Instantiate(zombi,pos,Quaternion.identity);
            zamanSayaci = olusumSureci;
        }
    }
    public void PuanArttir(int p) 
    {
        puan += p;
        puanText.text = ""+puan;
    }
    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan",puan);
        SceneManager.LoadScene("OyunBitti");
    }
}
 