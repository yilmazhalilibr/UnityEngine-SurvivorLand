using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHareket : MonoBehaviour
{
    public GameObject kalp;
    private GameObject oyuncu;
    private int zombieCan = 3;
    private float mesafe;
    private OyunKontrol oKontrol;
    private AudioSource aSource;
    private bool zombieDie=false;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("Oyuncu");
        oKontrol = GameObject.Find("_Scripts").GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position,oyuncu.transform.position);
        if (mesafe < 10f)
        {
            if(!aSource.isPlaying)
            aSource.Play();
            if(!zombieDie)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else
        {
            if (aSource.isPlaying)
                aSource.Stop();
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals ("mermi"))
        {
            zombieCan--;
            if (zombieCan==0)
            {
                zombieDie = true;
                oKontrol.PuanArttir(10);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
                Instantiate(kalp, transform.position, Quaternion.identity);
                
            }
        }
    }
}
