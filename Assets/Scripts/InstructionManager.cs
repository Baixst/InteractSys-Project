using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionManager : MonoBehaviour
{
    public GameObject InstructionPanel;
    public TextMeshProUGUI instructionText;

    [TextArea(2, 3)]
    public List<string> instructions; 
    private Animator animator;
    public int currentInstruction = 0;

    void Start()
    {
        animator = InstructionPanel.GetComponent<Animator>();
        CloseInstructionPanel();
        StartCoroutine(ShowFirstInstruction());
        SetInstructionTextTo(instructions[0]);
    }

    IEnumerator ShowFirstInstruction()
    {
        yield return new WaitForSeconds(2f);
        InstructionPanel.SetActive(true);
        animator.SetTrigger("ShowFirstInstruction");
    }

    private IEnumerator ShowInstruction(int index)
    {
        yield return new WaitForSeconds(1f);
        SetInstructionTextTo(instructions[index]);
        InstructionPanel.SetActive(true);
        animator.SetTrigger("ShowNextInstruction");
    }

    public void ShowNextInstruction()
    {
        currentInstruction++;
        StartCoroutine(ShowInstruction(currentInstruction));
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
