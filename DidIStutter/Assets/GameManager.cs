using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Fungus;

public class GameManager : MonoBehaviour
{

    public Text Player1_Entered;
    public Text Player1_Next;
    public Text Player1_Remaining;
    public string Player1Ref;
    public int Player1Pos;
    //public List<string> Player1Text = new List<string>();
    public int Player1Line = 0;

    public Flowchart Dialogue;
    public bool canPlayerType = false;

    // Use this for initialization
    void Start()
    {
        // Player1Text.Add("Oh yeah (surprised) me too. Me too.");
        UpdateText();
    }

    public void CharacterFinishedTalking()
    {
        canPlayerType = true;

        Player1Pos = 0;
        Player1Line += 1;

        if (Player1Line == 1)
        {
            Player1Ref = ("Oh yeah? me too. Me too.");
        }
        if (Player1Line == 2)
        {
            Player1Ref = ("Yeah I wonder hey?");
        }
        if (Player1Line == 3)
        {
            Player1Ref = ("He throws it around likes it weighs nothing as well.");
        }
        if (Player1Line == 4)
        {
            Player1Ref = ("Haha, admantm or something?");
        }

        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayerType)
        {


            if (Input.anyKeyDown && (Player1Ref.Length != Player1Pos))
            {
                string searchString = Player1Ref.Substring(Player1Pos, 1).ToLower();
                string nextCharColour = "white";

                if (Input.GetKeyDown((KeyCode)searchString[0]) ||
                    (Input.GetKeyDown(KeyCode.Slash) && (searchString[0] == '?')))
                {
                    //typing was right
                    Player1Pos += 1;
                    Debug.Log(Player1Pos);
                }
                else if(!Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.RightShift) && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Backspace))
                {
                    //typing was wrong
                    nextCharColour = "red";
                }

                UpdateText(nextCharColour);
            }

            //most effects in here
            //if on this line, this position. do stuff playerpos1 will adapt.

            if (Player1Ref.Length == Player1Pos)
            {
                UpdateText();
                Debug.Log("Reached the end");

                bool allowCharacterToTalk = true;

                //for extending multiple lines into before fungus triggers
                if (Player1Line == 2)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }

                if (allowCharacterToTalk)
                {
                    //move along conversation
                    canPlayerType = false;
                    Dialogue.ExecuteBlock("FinishedTyping");
                }
            }
        }
    }

    void UpdateText(string nextCharColour = "white")
    {
        string enteredText = Player1Ref.Substring(0, Player1Pos);
        string nextChar = "";
        string remainingText = "";

        // is there at least one more character left?
        if (Player1Pos < Player1Ref.Length)
            nextChar = Player1Ref.Substring(Player1Pos, 1);

        // is there at least 2 more characters left?
        if (Player1Pos < (Player1Ref.Length - 1))
            remainingText = Player1Ref.Substring(Player1Pos + 1);

        Player1_Entered.text = "<color=\"green\">" + enteredText + "</color>";
        Player1_Next.text = "<color=\"#00000000\">" + enteredText + "</color>" +
                         "<color=\"" + nextCharColour + "\"><b>" + nextChar + "</b></color>";
        Player1_Remaining.text = "<color=\"#00000000\">" + enteredText + "</color>" +
                         "<color=\"#00000000\"><b>" + nextChar + "</b></color>" +
                         "<color=\"white\">" + remainingText + "</color>";
    }
}
