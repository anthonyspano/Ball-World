using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PromptDialogue : MonoBehaviour
{
    public Text dialogueContent;

    private PickupGem gems;

    public GameObject player;
    public Transform playerMount;

    public Transform gravityWell;

    private Animator anim;

    private void Start()
    {
        gems = GameObject.Find("Player").GetComponent<PickupGem>();
        anim = GetComponent<Animator>();
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

        // flies away segment
        MonoBehaviour[] components = player.GetComponents<MonoBehaviour>();
        
        // Loop through each component and disable it
        foreach (var component in components)
        {
            component.enabled = false;
        }
        Debug.Log(player.GetComponent<Respawn>().enabled);

        // disable gravity
        gravityWell.GetComponent<PlanetGravity>().enabled = false;
        gravityWell.gameObject.SetActive(false);
        Physics.gravity = Vector3.zero;

        // make player child of dragon
        player.transform.SetParent(transform);

        // set mount position
        player.transform.position = playerMount.position;

        // play flying away animation


        // have dragon move for a few seconds
        anim.Play("Flying Loop");
        float i = 3f;
        while(i > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5f);
            i -= Time.deltaTime;
            yield return null;
        }

        //yield return new WaitForSeconds(4f);

        // end the game
        SceneManager.LoadScene("SampleScene");

    }
}
