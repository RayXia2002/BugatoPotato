using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{

    public Button skip;

    public GameObject moveTutu;
    public GameObject uiTutu;

    private int stage = 0;
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
        
    }

    void NextTutorial()
    {
        if (stage == 0)
        {
            stage++;

        }
        gameObject.SetActive(false);
    }
}
