using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public static bool SpaceIsPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
