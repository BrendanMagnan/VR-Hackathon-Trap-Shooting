using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{

    public XRController leftRay;
    public XRController rightRay;
    public XRController sniperRay;

    public InputHelpers.Button rayActivationButton;
    public float activationThreshold = 0.1f;

    public bool enableRightTeleport { get; set; } = true;
    public bool enableLeftTeleport { get; set; } = true;

    public bool enableSniperRay { get; set; } = false;

    [SerializeField] GameObject sniperRayTransform;
    [SerializeField] GameObject attachTransform;
    [SerializeField] GameObject attachTransformReset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftRay)
        {
            leftRay.gameObject.SetActive(enableLeftTeleport && CheckIfActivated(leftRay));

            /*
            else if (enableSniperRay && CheckIfActivated(leftRay))
            {
                
                leftRay.gameObject.SetActive(true);
            }
            attachTransform.transform.position = sniperRayTransform.transform.position;
            */

        }
        if (rightRay)
        {
            rightRay.gameObject.SetActive(enableRightTeleport && CheckIfActivated(rightRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, rayActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

    public void ReleaseLeftGrab()
    {
        attachTransform.transform.position = attachTransformReset.transform.position;
    }

}
