using UnityEngine;



public class DynamicCut : MonoBehaviour
{
    [SerializeField]
    [Range(0, 11)]
    private int CutLevel;

    private int previousLevel = 0;

    [SerializeField]
    private bool CheckSwap = false;

    [SerializeField]
    private GameObject[]  CutHands = new GameObject[12];


    private void OnEnable()
    {
        foreach (GameObject c in CutHands)
        {
            c.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(CheckSwap)
        {
            HandSwap();
        }  
    }

    void HandSwap()
    {
        try
        {
            CutHands[CutLevel].SetActive(true);
            if (CutLevel != previousLevel)
            {
                CutHands[previousLevel].SetActive(false);
            }

            previousLevel = CutLevel;

        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.LogWarning("Index Out of Range, with Accessing Cut Hands");
        }

            
    }
}
