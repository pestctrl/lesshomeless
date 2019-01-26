using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShakingGame : MonoBehaviour
{
    public GameManager GM;
    public float coinMultiplier;
    public bool coinGameStart;
    public float MoneyGenerated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() {
        MoneyGenerated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinGameStart)
        {
            StartCoroutine(MeasureWait());
        }
    }


    IEnumerator MeasureWait()
    {
        float mult;
        float lastPos = Mathf.Abs(transform.position.magnitude);
        yield return new WaitForSeconds(.4f);
        float Pos = Mathf.Abs(transform.position.magnitude);

        mult = Mathf.Abs(Pos - lastPos) * 50;
        MoneyGenerated = MoneyGenerated + (mult * 1 * Time.deltaTime);
        //print(MoneyGenerated);

    }
}
