using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchCzlowieka : MonoBehaviour
{
    float krok = 1.52f;
    float start = -5.34f;
    float x = 0f;
    public GameObject row1, row2, row3, row4, row5, row6, row7;

    private void Start()
    {
        allRowsHides();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Info.Instance.wykonywanyRuch && Info.Instance.kolejnosc.Contains("CZLO") && Info.Instance.poOpadnieciu)
        {
            bool onBoard = false;
                
            x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            for (int i = 1; i < 8; i++)
            {
                    if (x > start + (i - 1) * krok && x < start + i * krok)
                    {
                        Info.Instance.kolumnaCzlowieka = i - 1;
                        onBoard = true;
                        allRowsHides();
                    }
            }
            if (onBoard)
            {
                    //    Info.Instance.kolejnosc = x.ToString();
                   
                if(Info.Instance.canNext)
                {
                    Info.Instance.nowyRuchCzlowieka = true;
                    StartCoroutine("WaitForFall");
                }
            }
            
        }

        if (!Info.Instance.kolejnosc.Contains("CZLO") || Info.Instance.poOpadnieciu == false)
        {
            allRowsHides();
        }

        if (!Info.Instance.wykonywanyRuch && !Info.Instance.czyKoniec && Info.Instance.kolejnosc.Contains("CZLO") && Info.Instance.poOpadnieciu)
        {
            float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            for (int i = 1; i < 8; i++)
            {

                if (y > start + (i - 1) * krok && y < start + i * krok)
                {
                    if (i == 1) { allRowsHides(); row1.SetActive(true); }
                    if (i == 2) { allRowsHides(); row2.SetActive(true); }
                    if (i == 3) { allRowsHides(); row3.SetActive(true); }
                    if (i == 4) { allRowsHides(); row4.SetActive(true); }
                    if (i == 5) { allRowsHides(); row5.SetActive(true); }
                    if (i == 6) { allRowsHides(); row6.SetActive(true); }
                    if (i == 7) { allRowsHides(); row7.SetActive(true); }
                }
            }
            if (y < start || y > start + 7 * krok)
            {
                allRowsHides();
            }
        }
    }

    public void allRowsHides()
    {
        row1.SetActive(false);
        row2.SetActive(false);
        row3.SetActive(false);
        row4.SetActive(false);
        row5.SetActive(false);
        row6.SetActive(false);
        row7.SetActive(false);
    }

    IEnumerator WaitForFall()
    {
        Info.Instance.canNext = false;
        Info.Instance.poOpadnieciu = false;
        yield return new WaitForSeconds(3f);
        Info.Instance.canNext = true;
    }
}
