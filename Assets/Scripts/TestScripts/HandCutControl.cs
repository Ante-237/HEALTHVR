using Oculus.Interaction.HandGrab;
using Oculus.Interaction;
using UnityEngine;
using Unity.VisualScripting;

[System.Serializable]
public struct EndPointValues
{
    public float maxV;
    public float minV;
};

[RequireComponent(typeof(Rigidbody))]
public class HandCutControl : MonoBehaviour
{
    [SerializeField]
    private Grabbable theGrabbable;
    [SerializeField]
    private OneGrabTranslateTransformer translateObject;


    [SerializeField]
    [Tooltip("Activates the Knife to be locked to certain axis for cutting")]
    private bool isConstrainted = false;

    private HandGrabInteractable[] _handGrabInteractables;


    public EndPointValues Xvalues;
    public EndPointValues Yvalues;
    public EndPointValues Zvalues;

    private void Start()
    {
        Initialize();
        SetupRotationObject();
        AssignPointElementsSetup();
    }

    void RunSetup()
    {
        if (isConstrainted)
        {
            
            SetupConstraint();
         
            isConstrainted = false;
        }
    }

    private void Update()
    {
        RunSetup();
    }

    void Initialize()
    {
        gameObject.AddComponent<Grabbable>();
        gameObject.AddComponent<OneGrabTranslateTransformer>();
        theGrabbable = GetComponent<Grabbable>();
        translateObject = GetComponent<OneGrabTranslateTransformer>();
    }

    void SetupRotationObject()
    {
        theGrabbable.InjectOptionalOneGrabTransformer(translateObject);
        theGrabbable.TransferOnSecondSelection = true;

  

    }

    void SetupConstraint()
    {

        translateObject.Constraints.MaxZ.Constrain = true;
        translateObject.Constraints.MaxX.Constrain = true;
        translateObject.Constraints.MaxY.Constrain = true;


        translateObject.Constraints.MinZ.Constrain = true;
        translateObject.Constraints.MinX.Constrain = true;
        translateObject.Constraints.MinY.Constrain = true;


        translateObject.Constraints.MaxX.Value = Xvalues.maxV;
        translateObject.Constraints.MinX.Value = Xvalues.minV;
        translateObject.Constraints.MaxY.Value = Yvalues.maxV;
        translateObject.Constraints.MinY.Value = Yvalues.minV;
        translateObject.Constraints.MaxZ.Value = Zvalues.maxV;
        translateObject.Constraints.MinZ.Value = Zvalues.minV;

    }

    void AssignPointElementsSetup()
    {
        _handGrabInteractables = gameObject.GetComponentsInChildren<HandGrabInteractable>();
        foreach (var handGrabInteractable in _handGrabInteractables)
        {
            handGrabInteractable.InjectOptionalPointableElement(theGrabbable);
        }
    }

  

}
