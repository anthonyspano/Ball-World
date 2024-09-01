using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptDialogue : MonoBehaviour
{
    public Text dialogueContent;

    private PickupGem gems;

    private void Start()
    {
        gems = GameObject.Find("Player").GetComponent<PickupGem>();
    }

    void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.CompareTag("Player"))
        {
            if(gems.GemCount < gems.MaxGemCount)
                StartCoroutine(BeginQuest());
            else
                StartCoroutine(EndQuest());
        }
    }

    private IEnumerator BeginQuest()
    {

        dialogueContent.text = "Well, look at what we have here!";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "It seems you are in a bit of a predicament. Perhaps one that both of us can benefit from.";

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "If you collect all X of the gems on this planet, I will fly you out. Deal?";

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "";

    }

    private IEnumerator EndQuest()
    {
        dialogueContent.text = "Well I'll be a monkey's uncle... You did it!";

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "Hop on my back and i'll take you out of here.";


        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        dialogueContent.text = "";

        // flies away

        

    }
}
