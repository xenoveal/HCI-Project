using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	Transform camTransform;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	[SerializeField] public float shakeAmount = 0.00001f;
    bool isRun = false;
    bool isMove = false;
	
	Vector3 originalPos;
	void Start()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		    originalPos = camTransform.localPosition;
		}
	}
	void Update()
	{
        changeButtonState();
        if(isRun && isMove){
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }
        else{

			camTransform.localPosition = originalPos;
        }
	}

    void changeButtonState(){
		if ( Input.GetButtonDown("Fire3") ) //run state active
		{
            isRun = true;
		}
		if( Input.GetButtonUp("Fire3") )
		{
            isRun = false; //run not active
		}
		if ( Input.GetButtonDown("Horizontal")||Input.GetButtonDown("Vertical") ) //move state active
		{
            isMove = true;
		}
		if( Input.GetButtonUp("Horizontal")||Input.GetButtonUp("Vertical") )
		{
            isMove = false; //run not active
		}
    }
}
