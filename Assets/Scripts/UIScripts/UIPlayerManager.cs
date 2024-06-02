using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIPlayerManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image coolDownImage;
    private bool isCoolingDown;
    [SerializeField]private float waitTime;

    public UnityEvent OnCooledDown = new UnityEvent();

    public void StartCoolDown()
    {
        isCoolingDown = true;
        coolDownImage.gameObject.SetActive(true);
        coolDownImage.fillAmount = 1f;
    }
        
        
        
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolingDown)
        {
            coolDownImage.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            if (coolDownImage.fillAmount <= 0)
            {
                isCoolingDown = false;
                OnCooledDown.Invoke();
            }
        }
        
    }
}
