using UnityEngine;

//Collects the players input and stores it for other scripts to access
public class PlayerInput : MonoBehaviour
{

    public string rollingInputName = "Horizontal";
    public string jumpInputName = "Vertical";
    public string flipInputName = "Flip";

    [HideInInspector] public float rollingInput;
    [HideInInspector] public bool jumpInput;
    [HideInInspector] public bool flipInput;

    private void Update()
    {

        CollectInput();

        if (Input.GetButton("Quit"))
        {

            Application.Quit();

        }

    }

    void CollectInput()
    {

        rollingInput = Input.GetAxis(rollingInputName);
        jumpInput = Input.GetButton(jumpInputName);
        flipInput = Input.GetButtonDown(flipInputName);

    }
}
