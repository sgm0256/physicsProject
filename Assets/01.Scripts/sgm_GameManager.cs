using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class sgm_GameManager : MonoSingleton<sgm_GameManager>
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject panel;

    private float divideValue = 100f;
    private float value = 0.15f;

    public float Score { get; private set; }

    private void Update()
    {
        //Test
        /*if(slider.value == 0)
        {
            panel.SetActive(true);
        }*/

        value += Time.deltaTime / divideValue;
        MinusLife(value);
    }

    public void Plus()
    {
        Score += 10;
        slider.value += 15 + value * 15f;
    }

    public void Minus()
    {
        slider.value -= 15 + value * 35f;
        //StartCoroutine("PanelActive"); Test
    }

    private void MinusLife(float value)
    {
        slider.value -= value;
    }

    //Test
    /*IEnumerator PanelActive()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        panel.SetActive(false);
    }*/
}
