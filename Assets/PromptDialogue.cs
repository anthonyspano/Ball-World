using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptDialogue : MonoBehaviour
{
    public GameObject dialogueBox;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            bool b = dialogueBox.activeSelf;
            dialogueBox.SetActive(!b);
            //dialogueBox.enabled = !dialogueBox.enabled;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("zzz");
            
            // display dialogue box
            //dialogueBox.enabled = true;
            dialogueBox.SetActive(true);
        }
    }
}
