using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PhaseCounter : MonoBehaviour
{
    private int phaseCount = 1;
    private int winnerCounter;
    public RandomLocation randomLocation;
    public TextMeshProUGUI phaseLabel;

    public PowerCounter p1area1;
    public PowerCounter p1area2;
    public PowerCounter p1area3;
    public PowerCounter p2area1;
    public PowerCounter p2area2;
    public PowerCounter p2area3;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    public GameObject p1win;
    public GameObject p2win;

    public AudioManager audioManager;

    private void Start()
    {
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        yield return null;
        p1area1.kategoriArea = randomLocation.firstLocation.ToString();
        p2area1.kategoriArea = randomLocation.firstLocation.ToString();
        if (image1 != null)
        {
            image1.GetComponent<Animator>().enabled = true;
            image1.GetComponent<TempatSampahAnim>().FirstLocationAnim();
            audioManager.trashbinRevealed();
        }
        DisplayCount();
    }
    public void CountUp()
    {
        phaseCount++;
        if(phaseCount == 3)
        {
            p1area2.kategoriArea = randomLocation.secondLocation.ToString();
            p2area2.kategoriArea = randomLocation.secondLocation.ToString();
            if (image2 != null)
            {
                image2.GetComponent<Animator>().enabled = true;
                image2.GetComponent<TempatSampahAnim>().SecondLocationAnim();
                audioManager.trashbinRevealed();
            }
        }
        else if(phaseCount == 5)
        {
            p1area3.kategoriArea = randomLocation.thirdLocation.ToString();
            p2area3.kategoriArea = randomLocation.thirdLocation.ToString();
            if (image3 != null)
            {
                image3.GetComponent<Animator>().enabled = true;
                image3.GetComponent<TempatSampahAnim>().ThirdLocationAnim();
                audioManager.trashbinRevealed();
            }
        }
        else if(phaseCount > 6)
        {
            if(p1area1.power > p2area1.power) {winnerCounter++;}
            else {winnerCounter--;}
            if (p1area2.power > p2area2.power) {winnerCounter++;}
            else {winnerCounter--;}
            if (p1area3.power > p2area3.power) {winnerCounter++;}
            else {winnerCounter--;}
            if (winnerCounter > 0)
            {
                p1win.SetActive(true);
                audioManager.playerWinning();
                StartCoroutine(BackToMenuCountDown());
            }
            else 
            {
                p2win.SetActive(true);
                audioManager.playerWinning();
                StartCoroutine(BackToMenuCountDown());
            }
        }
        DisplayCount();
    }

    void DisplayCount()
    {
        phaseLabel.text = phaseCount.ToString();
    }

    IEnumerator BackToMenuCountDown()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Mainmenu");
    }

}
