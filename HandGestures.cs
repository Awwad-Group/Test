using UnityEngine;
using Leap;

public class HandGestures : MonoBehaviour
{
    Controller controller;
    Frame frame;
    Hand rightHand = new Hand();
    Hand leftHand = new Hand();
    private float previous_Right_Hand_Visible_Time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AssigningRightAndLeftHands();
    }

    private void AssigningRightAndLeftHands()
    {
        controller = new Controller(); // controller is a Controller object
        frame = controller.Frame();
        //if statment because in case of no hand detected, so no hands[0] from the start.
        if (frame.Hands.Count > 0)
        {
            for (int i = 0; frame.Hands.Count > i; i++)
            {
                if (frame.Hands[i].IsRight) rightHand = frame.Hands[i];
                else leftHand = frame.Hands[i];
            }
        }
    }

    public bool Is_RightHand_ThumpUp_Gesture()
    {
        var rightThumpExtended = rightHand.Fingers[0].IsExtended;
        var rightIndexExtended = rightHand.Fingers[1].IsExtended;
        var rightMeddleExtended = rightHand.Fingers[2].IsExtended;
        var rightRingExtended = rightHand.Fingers[3].IsExtended;
        var rightPinkyExtended = rightHand.Fingers[4].IsExtended;
        if (rightThumpExtended && !rightIndexExtended && !rightMeddleExtended && !rightRingExtended && !rightPinkyExtended)
            return true;
        else
            return false;
    }

    public bool Is_RightHand_ClosedHand_Gesture()
    {
        var rightThumpExtended = rightHand.Fingers[0].IsExtended;
        var rightIndexExtended = rightHand.Fingers[1].IsExtended;
        var rightMeddleExtended = rightHand.Fingers[2].IsExtended;
        var rightRingExtended = rightHand.Fingers[3].IsExtended;
        var rightPinkyExtended = rightHand.Fingers[4].IsExtended;
        if (!rightThumpExtended && !rightIndexExtended && !rightMeddleExtended && !rightRingExtended && !rightPinkyExtended)
            return true;
        else
            return false;
    }

    public float Difference()
    {
        return rightHand.Fingers[0].TipPosition.x - rightHand.Fingers[4].TipPosition.x;
    }

    public bool IsRightHandDetectable()
    {
        if (rightHand.TimeVisible > previous_Right_Hand_Visible_Time)
        {
            previous_Right_Hand_Visible_Time = rightHand.TimeVisible;
            return true;
        }
        else
        {
            previous_Right_Hand_Visible_Time = rightHand.TimeVisible;
            return false;
        }
    }
    /*
    public float Get_RightHand_Pitch()
    {
        float pitch = rightHand.Direction.Pitch;
        return pitch;
    }

    public float Get_RightHand_Yaw()
    {
        float yaw = rightHand.Direction.Yaw;
        return yaw;
    }

    public float Get_RightHand_Roll()
    {
        float roll = rightHand.Direction.Roll;
        return roll;
    }*/
}
