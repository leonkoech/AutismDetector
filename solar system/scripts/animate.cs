using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class animate : MonoBehaviour
{
    //public GameObject sphereCollection;
    //public GameObject debugCube;
    string focusedPlanet;
    public float opacity = 0.6f;
    private bool isDetected = false;

    private SymptomDetector _symptomDetector;

    private MagicLeapInputs _magicLeapInputs;
    private MagicLeapInputs.ControllerActions _controllerActions;

    private string[] planetNames = new string[] { "mercury", "venus", "earth", "mars", "jupiter", "saturn", "uranus", "neptune", "pluto" };
    private int triggerCount = 0;
    //public SymptomDetector symptomDetector;


    public float speed = 10f;
    public Transform center;
    private Vector3 axis = Vector3.up;

    void Start()
    {
        InitiatePlanetMovement();
        InitiateSymptomDetector();
        InitiateControllerListeners();
    }

    void InitiatePlanetMovement()
    {
        focusedPlanet = planetNames[triggerCount];
        AnimateAllPlanets();
    }
    void InitiateSymptomDetector()
    {
        _symptomDetector = GetComponent<SymptomDetector>();
        _symptomDetector.OnSymptomDetected.AddListener(StopAnimatingPlanets);
        _symptomDetector.onSymptomEnded.AddListener(AnimateAllPlanets);

    }
    void InitiateControllerListeners()
    {
        _magicLeapInputs = new MagicLeapInputs();
        _magicLeapInputs.Enable();
        _controllerActions = new MagicLeapInputs.ControllerActions(_magicLeapInputs);
        _controllerActions.Bumper.performed += HandleOnBumper;
        _controllerActions.Trigger.performed += HandleOnTrigger;

    }

    private void HandleOnBumper(InputAction.CallbackContext obj)
    {
        bool bumperClicked = obj.ReadValueAsButton();
        if (bumperClicked) {
            triggerCountUpdate();
        }
        focusedPlanet = planetNames[triggerCount];

    }

    private void HandleOnTrigger(InputAction.CallbackContext obj)
    {
        float triggerValue = obj.ReadValue<float>();
        if (triggerValue > 0)
        
            isDetected = !isDetected;
       
    }

    private void triggerCountUpdate()
    {
        if(triggerCount <= 8 && triggerCount >= 0)
        {
             triggerCount++;
        }
        else
        {
            // reset trigger count to 0
            triggerCount = 0;
        }
       
    }


    void Update()
    {
        Animate(!isDetected); 
    }
    public void AnimateAllPlanets()
    {
        isDetected = false;
    }
    
    public void StopAnimatingPlanets()
    {
        isDetected = true;
    }
     void Animate(bool isAnimating)
    {
        // Loop through each child object
        foreach (Transform child in transform)
        {
            // Get the name of the child object
            string childName = child.gameObject.name;
            if (childName != focusedPlanet)
            {
                if (isAnimating)
                {
                    float objectSpeed = SpeedCalculation(child.gameObject);
                    child.gameObject.transform.RotateAround(center.position, axis, objectSpeed * Time.deltaTime);
                    //ReduceOpacity(child.gameObject);
                }
                else
                {
                    ReduceOpacity(child.gameObject);
                }
            }
        }

    }

    void ReduceOpacity(GameObject gameObject)
    {
        Material material = gameObject.GetComponent<Renderer>().material;

        Color color = material.color;

        color.a = opacity;

        material.color = color;
    }

    
    float SpeedCalculation(GameObject gameObject)
    {
       float z_index =  Mathf.Abs(gameObject.transform.position.z);
        if (z_index < 1)
        {
            z_index = 1;
        }
        return (1 / z_index)*speed;
    }


    private void OnDestroy()
    {
        _controllerActions.Bumper.performed -= HandleOnBumper;
        _controllerActions.Trigger.performed -= HandleOnTrigger;

        _magicLeapInputs.Dispose();
    }
}
