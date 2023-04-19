using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine.XR;
using UnityEngine.XR.MagicLeap;


public class SymptomDetector : MonoBehaviour
{
    public UnityEvent OnSymptomDetected;
    public UnityEvent onSymptomEnded;
    private bool isSymptomDetected = false;
    private Vector3 previousFixationPoint = Vector3.forward;
    private float symptomValue = 0f;
    private int frameCount = 0;
    private readonly float threshold = 0.1f;
    private MagicLeapInputs mlInputs;
    private MagicLeapInputs.EyesActions eyesActions;

    TMPro.TextMeshProUGUI debugText;

    void Start()
    {
        onSymptomEnded = new UnityEvent();
        onSymptomEnded = new UnityEvent();
        // debugText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<TMPro.TextMeshProUGUI>();

        // Initialize Magic Leap Eye Tracking
        InputSubsystem.Extensions.MLEyes.StartTracking();

        // Initialize Magic Leap inputs to capture input data
        mlInputs = new MagicLeapInputs();
        mlInputs.Enable();

        // Initialize Eyes Actions using mlInputs
        eyesActions = new MagicLeapInputs.EyesActions(mlInputs);
    }

    void Update()
    {
        detectSymptom();
    }

    private void detectSymptom()
    {
        // Cumulatively sum symptom value
        symptomValue += fixationPointChange();

        // check threshold every 10 frames
        frameCount += 1;
        if (frameCount >= 450)
        {
            // debugText.SetText((symptomValue / 450).ToString());
            if (symptomValue / 450 >= threshold)
            {
                if (!isSymptomDetected)
                {
                    OnSymptomDetected.Invoke();
                    isSymptomDetected = true;
                }
            }
            else
            {
                if (isSymptomDetected)
                {
                    onSymptomEnded.Invoke();
                    isSymptomDetected = false;
                }
            }
            frameCount = 0;
            symptomValue = 0f;
        }
    }

    private float fixationPointChange()
    {
        var eyes = eyesActions.Data.ReadValue<UnityEngine.InputSystem.XR.Eyes>();
        Vector3 fixationPoint = eyes.fixationPoint;
        float res = Vector3.Distance(fixationPoint, previousFixationPoint);
        previousFixationPoint = fixationPoint;
        return res;
    }
}
