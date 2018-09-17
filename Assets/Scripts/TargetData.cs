using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class TargetData : MonoBehaviour
    {
        private ScoreKeeper scorekeeperScript;

        [SerializeField]
        private GameObject _score;
        //public Transform TextTargetName;
        //public Transform TextDescription;
        public Transform Button1;
        public Transform Button2;
        public Text answerTxt;
        public bool ansCheck;
        string tb_name;

        //public Transform PanelDescription;

        //public AudioSource soundTarget;
        //public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
            //add Audio Source as new game object component
            //soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
            scorekeeperScript = (ScoreKeeper)_score.GetComponent<ScoreKeeper>();

            Button1.GetComponent<Button>().onClick.AddListener(delegate {
                if (tb_name != null)
                {
                    ansCheck = scorekeeperScript.CheckAnswer(tb_name, "Button1");
                    Debug.Log(ansCheck);
                    //Debug.Log("######button 1 was pressed");
                    if (ansCheck == true)
                    {
                        printRightAnswer();
                    }
                    else
                        printWrongAnswer();
                }
                

            });

            Button2.GetComponent<Button>().onClick.AddListener(delegate
            {
                //Debug.Log("######button 2 was pressed");
                if (tb_name != null)
                {

                    Debug.Log("reached inside listener, name of target is " + tb_name);

                    ansCheck = scorekeeperScript.CheckAnswer(tb_name, "Button2");

                    Debug.Log("moved after answer check");

                    if (ansCheck == true)
                    {
                        printRightAnswer();
                        Debug.Log("blah2 button 2 correct");
                    }
                    else
                        printWrongAnswer();
                }
                
            });
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();
            

            foreach (TrackableBehaviour tb in tbs)
            {
                tb_name = tb.TrackableName;
                //ImageTarget it = tb.Trackable as ImageTarget;
                //Vector2 size = it.GetSize();

                //Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                //TextTargetName.GetComponent<Text>().text = name;
                //ButtonAction.gameObject.SetActive(true);
                //TextDescription.gameObject.SetActive(true);
                //PanelDescription.gameObject.SetActive(true);


                //If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

            }
        }

        //function to play sound
        //void playSound(string ss)
        //{
        //    clipTarget = (AudioClip)Resources.Load(ss);
        //    soundTarget.clip = clipTarget;
        //    soundTarget.loop = false;
        //    soundTarget.playOnAwake = false;
        //    soundTarget.Play();
        //}

        

        public void printRightAnswer() {
            answerTxt.text = "Right Answer!";
        }

        public void printWrongAnswer() {
            answerTxt.text = "Wrong Answer!";
        }

        public string returnCurrentTrackableName() {
            return tb_name;
        }
    }
}
