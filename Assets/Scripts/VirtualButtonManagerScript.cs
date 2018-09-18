using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Vuforia;
using TMPro;


public class VirtualButtonManagerScript : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbBlah2;
    public TextMeshProUGUI answerTxt;
    public TargetData tgScript;
    public GameObject arcam;
    private ScoreKeeper scoreKeeperScript;
    public GameObject Score;
    private bool rightOrWrong;
    private IEnumerator coroutine;
    private string defaultTxt = "Hover over the next target!";



    // Use this for initialization
    void Start () {

        answerTxt.text = "Hover over the targets";
        scoreKeeperScript = (ScoreKeeper)Score.GetComponent<ScoreKeeper>();
        vbBlah2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        tgScript = arcam.GetComponent<TargetData>();

    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("#### Button pressed ####");
        Debug.Log("Current target is : " + tgScript.returnCurrentTrackableName());
        //answerTxt.text = tgScript.returnCurrentTrackableName();
        //Debug.Log(this.name + "marker name" + tgScript.returnCurrentTrackableName());

        if (scoreKeeperScript.checkIfVisited(tgScript.returnCurrentTrackableName()) == false)
        {
            Debug.Log("this hasnt been visited");
            rightOrWrong = scoreKeeperScript.CheckAnswer(tgScript.returnCurrentTrackableName(), this.name);
            Debug.Log("answer checked and value returned");
            if (rightOrWrong == true)
            {
                //answerTxt.text = "Right answer!"; // 
                Debug.Log("Right Answer");
                scoreKeeperScript.increaseScore();
                coroutine = displayCouroutine("right answer!");
                StartCoroutine(coroutine);
            }
            else
            {
                //answerTxt.text = "wrong answer!"; // couroutine = displayCouroutine("wrong answer.."); StartCouroutine(couroutine);
                Debug.Log("Wrong answer");
                coroutine = displayCouroutine("wrong answer...");
                StartCoroutine(coroutine);
            }

        }
        else {
            //answerTxt.text = "already answered"; // couroutine = displayCouroutine("already answered"); StartCouroutine(couroutine);
            Debug.Log("Already answered");
            coroutine = displayCouroutine("already answered");
            StartCoroutine(coroutine);
        }


    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("#### Button released ####");
        //answerTxt.text = "Vb released";

    }

    // Update is called once per frame
    void Update () {
        //answerTxt.text = "Hover over the next target";
	}

    private IEnumerator displayCouroutine(string dispTxt)
    {
        while (true)
        {
            answerTxt.text = dispTxt;
            yield return new WaitForSeconds(3.0f);
            answerTxt.text = defaultTxt;
            break;
            
        }
    }
}


