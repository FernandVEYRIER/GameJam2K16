using UnityEngine;
using System.Collections.Generic;

public class RotateMap : MonoBehaviour {

    public float speed = 1f;
    public enum State { none, right, left, left180, right180, left270, right270, left360, right360 };
    private Queue<State> queue = new Queue<State>();
    private static readonly Quaternion[] rotations = {
        Quaternion.AngleAxis(0, Vector3.forward),
        Quaternion.AngleAxis(90, Vector3.forward),
        Quaternion.AngleAxis(-90, Vector3.forward),
            Quaternion.AngleAxis(180, Vector3.forward),
        Quaternion.AngleAxis(-180, Vector3.forward)
    };
    
    private State status;

    private Quaternion targetRotation;
    // Use this for initialization
    void Start() {
        targetRotation = transform.rotation;
    }

    public void rotate(State st)
    {
        if (transform.rotation == targetRotation)
        {
            if (State.right180 == st)
            {
                queue.Enqueue(State.right);
                queue.Enqueue(State.right);
            }
            else if (State.left180 == st)
            {
                queue.Enqueue(State.left);
                queue.Enqueue(State.left);
            }
            else
                queue.Enqueue(st);
            status = st;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation == targetRotation && queue.Count != 0)
        {
            targetRotation *= rotations[(int)queue.Peek()];
            queue.Dequeue();
            status = State.none;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * speed * Time.deltaTime);
    }
}
