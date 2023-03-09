using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrab : XRGrabInteractable
{

    public List<XRGrabInteractable> secondHandGrabPoints = new List<XRGrabInteractable>();
    private IXRSelectInteractor secondInteractor;
    private Quaternion attachInitialRotation;
    public enum TwoHandRotationType { None, First, Second}
    public TwoHandRotationType twoHandRotationType;
    public bool SnapToSecondHand = true;
    private Quaternion initialRotationOffset;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        
        foreach(var item in secondHandGrabPoints)
        {
            item.selectEntered.AddListener(OnSecondHandGrab);
            item.selectExited.AddListener(OnSecondHandRelease);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (secondInteractor != null && firstInteractorSelecting != null)
        {
            if (SnapToSecondHand)
            {
                firstInteractorSelecting.transform.rotation = GetTwoHandRotation();
            }
            else
            {
                firstInteractorSelecting.transform.rotation = GetTwoHandRotation() * initialRotationOffset;
            }
            //selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }

        base.ProcessInteractable(updatePhase);
    }
    
    private Quaternion GetTwoHandRotation()
    {
        Transform attachTransform1 = firstInteractorSelecting.transform;
        Transform attachTransform2 = secondInteractor.transform;

        switch(twoHandRotationType)
        {
            case TwoHandRotationType.None: 
                return Quaternion.LookRotation(attachTransform2.position - attachTransform1.position);

            case TwoHandRotationType.First:
                return Quaternion.LookRotation(attachTransform2.position = attachTransform1.position, firstInteractorSelecting.transform.up);

            case TwoHandRotationType.Second:
                return Quaternion.LookRotation(attachTransform2.position = attachTransform1.position, secondInteractor.transform.up);

            default:
                return Quaternion.LookRotation(attachTransform2.position - attachTransform1.position, secondInteractor.transform.up);


        }
    }

    public void OnSecondHandGrab(SelectEnterEventArgs args)
    {
        Debug.Log("SECOND HAND GRAB");
        secondInteractor = args.interactorObject;
        initialRotationOffset = Quaternion.Inverse(GetTwoHandRotation()) * secondInteractor.transform.rotation;

    }
    public void OnSecondHandRelease(SelectExitEventArgs args)
    {
        Debug.Log("SECOND HAND RELEASE");
        secondInteractor = null;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("First Grab Enter");
        attachInitialRotation = args.interactorObject.transform.localRotation;
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("First Grab Exit");

        secondInteractor = null;
        args.interactorObject.transform.localRotation = attachInitialRotation;
        base.OnSelectExited(args);
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        bool isAlreadyGrabbed = firstInteractorSelecting != null && !interactor.Equals(firstInteractorSelecting);
        return base.IsSelectableBy(interactor) && !isAlreadyGrabbed;
    }
    

}
