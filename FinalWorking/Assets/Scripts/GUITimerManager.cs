using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUITimerManager : MonoBehaviour
{
    static public GUITimerManager Instance;

    Text Text_PartyTime;

    public Image FillBar;   // associated fill bar
    public GameObject AttackButton; // associated attack button

    public float curTime = 0f;      // current timer value      default is 0
    public float maxTime = 100f;    // maximum timer value      default is 100
    public float fSpeed = 9f;       // increment speed          default is 9

    private float barFillAmount;

	void Awake()
    {
        Instance = this;
        Text_PartyTime = GetComponent<Text>();
        Text_PartyTime.text = curTime.ToString() + " / " + maxTime.ToString();
        FillBar = FillBar.GetComponent<Image>();
    }

    void Update()
    {
        // update current time
        curTime += fSpeed * Time.deltaTime;
        barFillAmount = (curTime / 100f);

        if (curTime > 99)
        {
            // if the bar is filled, show the attack button
            curTime = 100f;
            AttackButton.SetActive( true );
        }
        else
        {
            // otherwise, hide it
            AttackButton.SetActive( false );
        }

        FillBar.fillAmount = barFillAmount;
        Text_PartyTime.text = curTime.ToString() + " / " + maxTime.ToString();
    }
}
