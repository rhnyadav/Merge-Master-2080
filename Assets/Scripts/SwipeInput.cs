using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    Vector2 startPos;

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch t = Input.GetTouch(0);

        if (t.phase == TouchPhase.Began)
            startPos = t.position;

        if (t.phase == TouchPhase.Ended)
        {
            Vector2 delta = t.position - startPos;

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                if (delta.x > 0) Debug.Log("Swipe Right");
                else Debug.Log("Swipe Left");
            }
            else
            {
                if (delta.y > 0) Debug.Log("Swipe Up");
                else Debug.Log("Swipe Down");
            }
        }
    }
}
