using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionManager : MonoBehaviour
{
    public GameObject InstructionPanel;
    public TextMeshProUGUI instructionText;
    public List<string> instructions; 
    private Animator animator;
    private int currentInstruction = 0;

    void Start()
    {
        animator = InstructionPanel.GetComponent<Animator>();
        CloseInstructionPanel();
        StartCoroutine(ShowFirstInstruction());
    }

    IEnumerator ShowFirstInstruction()
    {
        yield return new WaitForSeconds(2f);
        InstructionPanel.SetActive(true);
        animator.SetTrigger("ShowFirstInstruction");
    }


    public void ShowNextInstruction()
    {
        currentInstruction++;
        SetInstructionTextTo(instructions[currentInstruction]);
        InstructionPanel.SetActive(true);
        animator.SetTrigger("ShowNextInstruction");
    }

    public void SetInstructionTextTo(string text)
    {
        instructionText.text = text;
    }

    public void CloseInstructionPanel()
    {
        animator.SetTrigger("CloseInstruction");
        InstructionPanel.SetActive(false);
    }
}
