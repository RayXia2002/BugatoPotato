using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{

    public Button skip;
    //public TextMP skipText;

    public GameObject moveTutu;
    public GameObject uiTutu;

    public int stage = 0;
    private bool display = true;
    // Start is called before the first frame update
    void Start()
    {
        moveTutu.SetActive(true);
        uiTutu.SetActive(false);
        skip.onClick.AddListener(NextTutorial);
    }

    // Update is called once per frame
    void Update()
    {
        if(display)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void NextTutorial()
    {
        if (stage == 0)
        {
            stage++;
            moveTutu.SetActive(false);
            uiTutu.SetActive(true);
        }
        else if(stage == 1)
        {
            stage++;
            uiTutu.SetActive(false);        
            skip.gameObject.SetActive(false);
        }
    }

    public void DisplayTutorial(bool d)
    {
        display = d;
    }
}
