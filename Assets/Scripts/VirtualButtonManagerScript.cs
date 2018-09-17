using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Vuforia;

public class VirtualButtonManagerScript : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbBlah2;
    public Text answerTxt;
    public TargetData tgScript;
    public GameObject arcam;
    private ScoreKeeper scoreKeeperScript;
    public GameObject Score;
    private bool rightOrWrong;



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
        answerTxt.text = tgScript.returnCurrentTrackableName();
        //Debug.Log(this.name + "marker name" + tgScript.returnCurrentTrackableName());

        if (scoreKeeperScript.checkIfVisited(tgScript.returnCurrentTrackableName()) == false)
        {
            Debug.Log("this hasnt been visited");
            rightOrWrong = scoreKeeperScript.CheckAnswer(tgScript.returnCurrentTrackableName(), this.name);
            Debug.Log("answer checked and value returned");
            if (rightOrWrong == true)
            {
                answerTxt.text = "Right answer!";
                Debug.Log("Right Answer");
                scoreKeeperScript.increaseScore();
            }
            else
            {
                answerTxt.text = "wrong answer!";
                Debug.Log("Wrong answer");
            }

        }
        else {
            answerTxt.text = "already answered";
            Debug.Log("Already answered");
        }


    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("#### Button released ####");
        //answerTxt.text = "Vb released";

    }

    // Update is called once per frame
    void Update () {
		
	}
}


