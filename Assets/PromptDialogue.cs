using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptDialogue : MonoBehaviour
{
    public Text dialogueContent;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.CompareTag("Player"))
        {

            StartCoroutine(BeginQuest());
        }
    }

    private IEnumerator BeginQuest()
    {
        // well hello little ball
        dialogueContent.text = "Well, look at what we have here!";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "It seems you are in a bit of a predicament. Perhaps one that both of us can benefit from.";

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "If you collect all of the gems on this planet, I will fly you out. Deal?";

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "";

    }
}
