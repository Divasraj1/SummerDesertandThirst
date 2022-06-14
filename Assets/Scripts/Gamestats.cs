using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamestats : MonoBehaviour
{
    [SerializeField]
    private int timer = 100;

    [SerializeField]
    private int maxBarrels = 20;

    [SerializeField]
    private int currentBarrels = 0;

    public TMP_Text timertext;
    public TMP_Text barrelstext;

    public GameObject LevelLostScreen;
    public GameObject LevelWonScreen;
    // Start is called before the first frame update
    void Start()
    {
        timertext.text = timer.ToString();
        barrelstext.text = "0/" + maxBarrels.ToString();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CollectBarrel()
    {
        currentBarrels += 1;
        barrelstext.text = currentBarrels.ToString() + "/" + maxBarrels.ToString();

        if(timer > 0 && currentBarrels == maxBarrels)
        {
            LevelWonScreen.SetActive(true);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        timer -= 1;
        timertext.text = timer.ToString();
        StartCoroutine("Timer");

        if(timer <= 0)
        {
            StopCoroutine(Timer());
            print("TimeOut");
            //Make Menu scene enable
            LevelLostScreen.SetActive(true);
            //Stop Controller
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
