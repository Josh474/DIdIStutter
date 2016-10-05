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
    public Text fungusdialogue;

    public Image girl;
    public Image guy;
    public Image[] test;
    public Image[] guytest;

    public AudioSource sound;
    public AudioEchoFilter sound1;

    public float soundlerptimer;
    public float soundlerptotal = 3f;

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
            girl.sprite = test[7].sprite;
            guy.sprite = guytest[4].sprite;
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            Player1Ref = ("I had an amazing time too.");
        }
        if (Player1Line == 2)
        {
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("oh yeah me too. Me too.");
        }
        if (Player1Line == 3)
        {
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            Player1Ref = ("the movie was great");
        }
        if (Player1Line == 4)
        {
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            Player1Ref = ("I loved the swiss chocolate flavour and the chocolate sauce on top.");
        }
        if (Player1Line == 5)
        {
            guy.sprite = guytest[2].sprite;
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("yep, me too.");
        }
        if (Player1Line == 6)
        {
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            Player1Ref = ("its cool the way it bounces off everything too.");
        }
        if (Player1Line == 7)
        {
            guy.sprite = guytest[7].sprite;
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("yeah I wonder.");
        }
        if (Player1Line == 8)
        {
            guy.sprite = guytest[8].sprite;
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("aaaaaadmantm or something?");
        }
        if (Player1Line == 9)
        {
            soundlerptimer = soundlerptotal;
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            Player1Ref = ("the blue of your dress matches your eyes");
        }
        if (Player1Line == 10)
        {
            Player1Ref = ("your wavy hair is adoreable");
        }
        if (Player1Line == 11)
        {
            Player1Ref = ("your lips... soft looking");
        }
        if (Player1Line == 12)
        {
            guy.sprite = guytest[0].sprite;
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("thanks.");
            girl.sprite = test[4].sprite;
        }
        if (Player1Line == 13)
        {
            guy.sprite = guytest[4].sprite;
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            fungusdialogue.fontSize = 90;
            Player1Ref = ("id love to go out again on saturday.");
        }
        if (Player1Line == 14)
        {
            Player1Ref = ("the party sounds great.");
        }
        if (Player1Line == 15)
        {
            Player1Ref = ("oh who's your favourite band?");
        }
        if (Player1Line == 16)
        {
            guy.sprite = guytest[6].sprite;
            Player1Ref = ("don't you think it's too soon to meet your whole family?");
            girl.sprite = test[3].sprite;
        }
        if (Player1Line == 17)
        {
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("arrruhhhhhmm I think im busy saturday.");
            girl.sprite = test[1].sprite;
        }
        if (Player1Line == 18)
        {
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            Player1Ref = ("I feel intoxicated by you.");
        }
        if (Player1Line == 19)
        {
            Player1Ref = ("I cant breathe when Im around you.");
        }
        if (Player1Line == 20)
        {
            Player1Ref = ("this has been the best night of my life.");
        }
        if (Player1Line == 21)
        {
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("youre cool.");
        }
        if (Player1Line == 22)
        {
            guy.sprite = guytest[6].sprite;
            enteredcolor = "#0B96F9FF";
            Remainingcolor = "#F9900BFF";
            Player1Ref = ("I want to love you.");
        }
        if (Player1Line == 23)
        {
            Player1Ref = ("you brighten my incredibly dim world.");
        }
        if (Player1Line == 24)
        {
            Player1Ref = ("you bring joy to my world.");
        }
        if (Player1Line == 25)
        {
            enteredcolor = "green";
            Remainingcolor = "#FFFFFF74";
            Player1Ref = ("…");
        }
        if (Player1Line == 26)
        {
            Player1Ref = ("sorry");
            girl.sprite = test[5].sprite;
        }
        if (Player1Line == 27)
        {
            guy.sprite = guytest[4].sprite;
            Player1Ref = ("yeahhh");
            sound.pitch = 1f;
            sound1.enabled = false;
        }
        if (Player1Line == 28)
        {
            guy.sprite = guytest[8].sprite;
            Player1Ref = ("I am kinda weird.");
            girl.sprite = test[2].sprite;
        }
        if (Player1Line == 29)
        {
            Player1Ref = ("I just have trouble speaking sometimes.");
        }
        if (Player1Line == 30)
        {
            guy.sprite = guytest[1].sprite;
            Player1Ref = ("I think I really like you.");
        }
        if (Player1Line == 31)
        {
            Player1Ref = ("of course. I would really like to get to know you better.");
            girl.sprite = test[7].sprite;
        }
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if(soundlerptimer > 0)
        {
            soundlerptimer -= Time.deltaTime;
            sound.pitch = Mathf.Lerp(1f, 0.41f, 1f - (soundlerptimer / soundlerptotal));
            sound1.enabled = true;
        }

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
                if (Player1Line == 1)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }

                else if (Player1Line == 3)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 4)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 6)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 9)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 10)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 11)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 13)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 14)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 15)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 16)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 18)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 19)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 20)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 22)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 23)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 24)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 25)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }
                else if (Player1Line == 27)
                {
                    CharacterFinishedTalking();
                    allowCharacterToTalk = false;
                }

                else if (allowCharacterToTalk)
                {
                    //move along conversation
                    canPlayerType = false;
                    Dialogue.ExecuteBlock("FinishedTyping");
                }
            }
        }
    }
    public string enteredcolor = "green";
    public string Remainingcolor = "#FFFFFF74";


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

        Player1_Entered.text = "<color=\"" + enteredcolor + "\">" + enteredText + "</color>";
        Player1_Next.text = "<color=\"#00000000\">" + enteredText + "</color>" +
                         "<color=\"" + nextCharColour + "\"><b>" + nextChar + "</b></color>";
        Player1_Remaining.text = "<color=\"#00000000\">" + enteredText + "</color>" +
                         "<color=\"#00000000\"><b>" + nextChar + "</b></color>" +
                         "<color=\"" + Remainingcolor + "\">" + remainingText + "</color>";
    }

    public void textsizechange(int sizechange)
    {
        fungusdialogue.fontSize = sizechange;
    }
}
