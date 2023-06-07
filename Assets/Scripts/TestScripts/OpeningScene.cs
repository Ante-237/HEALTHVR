using System.Collections;
using UnityEngine;

public class OpeningScene : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject DefaultObject;

    private Animation anim;

    public float WaitTime = 5.0f;

    public readonly int Opening = Animator.StringToHash("open");
        
    void Start()
    {
      
        try
        {
            anim = GetComponent<Animation>();

            Debug.LogWarning("anTe the Tag for the Sceneobject is : " + DefaultObject.GetComponent<VirtualTag>().GetTag().ToString());

            if(DefaultObject.GetComponent<VirtualTag>().GetTag() == "Room_2") {
                animator = DefaultObject.GetComponent<Animator>();

             }

        }catch(System.Exception e)
        {
            Debug.LogWarning(e.Message);

        }


        StartCoroutine(PlayStartAnimation());
    }



    IEnumerator PlayStartAnimation()
    {
        yield return new WaitForSeconds(WaitTime);

        ReduceAnimationSpeed();
        StartAnimationSequence();
    }

    void StartAnimationSequence()
    {
        animator.SetBool(Opening, true);
    }

    public void ReduceAnimationSpeed()
    {
        foreach(AnimationState _state in anim)
        {
            _state.speed = 0.5f;
            Debug.Log("The Name of the Animation Playing is : " + _state.length.ToString());    
        }
    }


    private void OnDisable()
    {
        animator.SetBool(Opening, false);
    }


}
