using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class changinghandV : MonoBehaviour
{
    [SerializeField]
    private Grabbable theGrabbable;
    [SerializeField]
    private OneGrabRotateTransformer rotationObject;

    private HandGrabInteractable[] _handGrabInteractables;


    private void Awake()
    {
        Initialize();
        SetupRotationObject();
        AssignPointElementsSetup();
    }

    void Initialize()
    {
        gameObject.AddComponent<Grabbable>();
        gameObject.AddComponent<OneGrabRotateTransformer>();

        theGrabbable = GetComponent<Grabbable> ();
        rotationObject = GetComponent<OneGrabRotateTransformer> ();


    }

    void SetupRotationObject()
    {
        theGrabbable.InjectOptionalOneGrabTransformer(rotationObject);
        theGrabbable.TransferOnSecondSelection = true;
        rotationObject.InjectOptionalRotationAxis(OneGrabRotateTransformer.Axis.Forward);


        rotationObject.Constraints.MinAngle.Constrain = true;
        rotationObject.Constraints.MaxAngle.Constrain = true;

        rotationObject.Constraints.MinAngle.Value = 0;
        rotationObject.Constraints.MaxAngle.Value = 180;
    
    }

    void AssignPointElementsSetup()
    {
       _handGrabInteractables =  gameObject.GetComponentsInChildren<HandGrabInteractable>();
        foreach(var handGrabInteractable in  _handGrabInteractables)
        {
            handGrabInteractable.InjectOptionalPointableElement(theGrabbable);
        }
    }

    private void OnDisable()
    {
        rotationObject.Constraints.MaxAngle.Value = 360;
    }



}
