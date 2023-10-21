using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject creditPanel;
    [SerializeField] GameObject rulePanel;
    private void Start()
    {
        creditPanel.SetActive(false);
        rulePanel.SetActive(false);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("playScene");
    }

    public void CreditButton()
    {
        creditPanel.SetActive(true);
    }

    public void RuleButton()
    {
        rulePanel.SetActive(true);
    }

    public void CloseCredit()
    {
        creditPanel.SetActive(false);
    }

    public void CloseRule()
    {
        rulePanel.SetActive(false);
    }
}
