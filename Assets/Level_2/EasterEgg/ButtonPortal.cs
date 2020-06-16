using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPortal : MonoBehaviour
{
    private bool OnButton = false;
    private Vector3 StartPos;
    private Vector3 EndPos;
    private HealthHelper health;
    private bool buttonActive = false;

    public GameObject GladosPanel;
    public GameObject[] TextGlados;
    private int Glados = 0;
    private bool Say = false;
    private bool Help = false;

    private AudioSource source;
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", 1);
        StartPos = gameObject.transform.position;
        EndPos= new Vector3(StartPos.x, StartPos.y-1f, StartPos.z);
        health = GameObject.Find("Robot Player").GetComponent<HealthHelper>();
        source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnButton)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, StartPos, Time.deltaTime * 3);
        
    }
    private void CloseGlados()
    {
        TextGlados[Glados].SetActive(false);
        GladosPanel.SetActive(false);
        switch (Glados)
        {
            case 0:
                Glados++;
                break;
            case 1:
                Glados++;
                break;
            case 2:
                break;
            case 3:
                Glados++;
                break;
            case 4:
                ;
                break;

            default:
                break;
        }
        Say = false;
    }
    public void GladosSay()
    {
        if (OnButton && health._health <= 10 && !buttonActive)
        {
            TextGlados[Glados].GetComponent<AudioSource>().Stop();
            CloseGlados();
            StopAllCoroutines();
            Glados = 3;
            buttonActive = true;
            health._health = GameObject.Find("Robot Player").GetComponent<HealthHelper>().MaxHealth;
            GameObject NPC = GameObject.Find("NPC Enemy");
            for (int i = 0; i < NPC.transform.childCount; i++)
            {
                NPC.transform.GetChild(i).GetComponent<HealthHelper>().GetDamage(200, null);
            }
            NPC = GameObject.Find("NPC Allies");
            float maxHealth = NPC.transform.GetChild(0).GetComponent<HealthHelper>()._health;
            for (int i = 0; i < NPC.transform.childCount; i++)
            {
                NPC.transform.GetChild(i).GetComponent<HealthHelper>()._health = maxHealth;
            }
        }
        if (!Say) {
            Debug.Log(Glados);
            Say = true;
            GladosPanel.SetActive(true);
            TextGlados[Glados].SetActive(true);
            StartCoroutine(volume_clip(TextGlados[Glados].GetComponent<AudioSource>().clip.length));
            Invoke("CloseGlados",5);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot Player"))
        {
            OnButton = true;
            GladosSay();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Robot Player"))
        {
            GladosSay();
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPos, Time.deltaTime * 3);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Robot Player"))
            OnButton = false;
    }
    IEnumerator volume_clip(float time)
    {
        source.mute = true;
        yield return new WaitForSeconds(time);
        source.mute = false;
        yield return null;
    }
}
