using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

   

    [Header("Particles")]
    public GameObject particleA;
    public GameObject particleB;


    [Header("Texts")]
    public GameObject textA;
    public GameObject textB;

    [Header("position")]
    public GameObject player;

    [Header("Audio")]
    public AudioSource audio;
   
    private void Start()
    {

        audio.GetComponent<AudioSource>();

        particleA.SetActive(false);
        particleB.SetActive(false);

        textA.SetActive(false);
        textB.SetActive(false);

        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BoxA"))
        {

            audio.Play();
            particleA.SetActive(true);
            textA.SetActive(true);
             
           
        }

        if(collision.gameObject.CompareTag("BoxB"))
        {
            audio.Play();
            particleB.SetActive(true);
            textB.SetActive(true);
          
        }

        if(collision.gameObject.CompareTag("BoxC"))// && (collision.gameObject.CompareTag("Player")))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));


            Debug.Log("going back");
        }
    }
}