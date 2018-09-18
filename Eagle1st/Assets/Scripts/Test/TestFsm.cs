using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFsm : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EagleFSM.Instance.GameBeginCallBack = TestGameBegin;

        EagleFSM.Instance.StartState(EagleFSM.EagleState.IDLE);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A click");
            EagleFSM.Instance.Perform(EagleFSM.EagleFSMEvent.GameBegin);
        }
    }

    // Update is called once per frame
    void TestGameBegin () {
        Debug.Log("yeah!!!!!!!");
	}
}
