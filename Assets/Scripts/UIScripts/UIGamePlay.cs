using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGamePlay : MonoBehaviour
{
    public static UIGamePlay singleton;

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI uiPlayerHealthText;
    [SerializeField] TextMeshProUGUI uiScoreText;

    [SerializeField] Transform GridLayout;
    [SerializeField] GameObject NukeGridPrefab;
    [SerializeField] private Stack<GameObject> NukeStack = new Stack<GameObject>();

    private int uiNukeCount = 0;

    private void Awake()
    {
        singleton = this;
        scoreManager.OnTotalScoreChanged.AddListener(UpdateUIScoreText);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUIPlayerHealthText(int health)
    {
        uiPlayerHealthText.text = "Health: " + health.ToString();
    }

    private void UpdateUIScoreText(int newScore)
    {
        uiScoreText.text = "Score: " + newScore.ToString();
    }

    public void ChangeNukeGrid(int currentNukeCount)
    {
        //Nuke Added
        if (uiNukeCount < currentNukeCount)
        {
            NukeAdded();
        } //Nuke Used
        else if (uiNukeCount > currentNukeCount)
        {
            NukeUsed();
        }
        else
        {
            Debug.Log("Nuke didn't change");
        }

        uiNukeCount = currentNukeCount;
    }

    private void NukeAdded()
    {
        GameObject nukeIcon = Instantiate(NukeGridPrefab, GridLayout.transform.position, Quaternion.identity);
        nukeIcon.transform.SetParent(GridLayout);
        NukeStack.Push(nukeIcon);
    }

    private void NukeUsed()
    {
        Debug.Log("pop stack");
        Destroy(NukeStack.Pop().gameObject);
    }
}
