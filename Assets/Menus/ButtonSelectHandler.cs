using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectHandler : MonoBehaviour
{
    public int currentButtonIdx = 0;
    public GameObject currentButton;
    public GameObject[] buttons;

    private void Start()
    {
        buttons = GameObject.Find("MenuHandler").GetComponent<ButtonHolder>().buttons;
        currentButton = buttons[currentButtonIdx];
    }

    public void SelectNextButton()
    {
        currentButtonIdx++;
        if (currentButtonIdx >= buttons.Length)
        {
            currentButtonIdx = 0;
        }
        currentButton = buttons[currentButtonIdx];
        Debug.Log("TERTRTTREER");
    }

    public void SelectPreviousButton()
    {
        currentButtonIdx--;
        if (currentButtonIdx < 0)
        {
            currentButtonIdx = buttons.Length - 1;
        }
        currentButton = buttons[currentButtonIdx];
    }

    public void PressCurrentButton()
    {
        currentButton.GetComponent<Button>().onClick.Invoke();
    }
}
