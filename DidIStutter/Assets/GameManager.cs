using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Text Player1_Entered;
    public Text Player1_Next;
    public Text Player1_Remaining;
    public string Player1Ref;
    public int Player1Pos;
    public List<string> Player1Text = new List<string>();


    public Text Player2;
    public List<string> Player2Text = new List<string>();

    // Use this for initialization
    void Start () {
        Player1Ref = "Hello my name is josh";
        UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && (Player1Ref.Length != Player1Pos))
        {
            string searchString = Player1Ref.Substring(Player1Pos, 1).ToLower();
            string nextCharColour = "white";

            if (Input.GetKeyDown((KeyCode)searchString[0]))
            {
                //typing was right
                Player1Pos += 1;
                Debug.Log(Player1Pos);
            }
            else
            {
                //typing was wrong
                nextCharColour = "red";
            }

            UpdateText(nextCharColour);
        }
        if (Player1Ref.Length == Player1Pos)
        {
            UpdateText();
            Debug.Log("Reached the end");
                //move along conversation
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
