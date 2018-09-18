using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Details {

    public string name;
    public bool isVisited;
    public string correctAnswer;

}

public class ScoreKeeper : MonoBehaviour {
    public int score;
    Details[] deetz = new Details[4];
    public TextMeshProUGUI scoreTxt;



    // Use this for initialization
    void Start () {

        score = 0;
        deetz[0] = new Details();
        deetz[0].name = "blah1";
        deetz[0].isVisited = false;
        deetz[0].correctAnswer = "blah1_button1";
        deetz[1] = new Details();
        deetz[1].name = "blah2";
        deetz[1].isVisited = false;
        deetz[1].correctAnswer = "blah2_button1";
        deetz[2] = new Details();
        deetz[2].name = "blah3";
        deetz[2].isVisited = false;
        deetz[2].correctAnswer = "blah3_button1";
        deetz[3] = new Details();
        deetz[3].name = "blah4";
        deetz[3].isVisited = false;
        deetz[3].correctAnswer = "blah4_button1";


    }
	
	// Update is called once per frame
	void Update () {
        scoreTxt.text = "score : " + score;
	}
    public void increaseScore() {
        score++;
    }

    public bool checkIfVisited(string markerName) {

        bool found = false;
        bool ans = false;
        foreach (Details deet in deetz) {
            if (deet.name == markerName) {
                found = true;
                ans = deet.isVisited;
    
            }
        }

        if (found == false)
            return false;
        else
            return ans;
        
    }

    public bool CheckAnswer(string detectedName, string corrAns)
    {
        bool rval=false;
        int i;

        for (i=0;i<4;i++) {
            Debug.Log(deetz[i].name + " IS NOT " + detectedName + " i = " + i);

            if (deetz[i].name == detectedName && deetz[i].isVisited == false)
            {
                Debug.Log(deetz[i].name + " == " + detectedName + " i = " + i );
                if (corrAns == deetz[i].correctAnswer)
                {
                    Debug.Log("Correct");
                    rval = true;
                    deetz[i].isVisited = true;
                    Debug.Log("isVisited changed to true");
                    break;
                    //return rval;
                }
                else
                {
                    Debug.Log("InCorrect");
                    rval = false;
                    deetz[i].isVisited = true;
                    Debug.Log("isVisited changed to true");
                    break;
                    //return rval;
                }

            }
            else {
                Debug.Log("tracker Name was'nt found");
                rval = false;
            }
                
        }

        return rval;

    }

}
