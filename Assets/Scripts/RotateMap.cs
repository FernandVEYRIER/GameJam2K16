using UnityEngine;
using System.Collections.Generic;

public class RotateMap : MonoBehaviour {

    public float speed = 1f;
    public enum State { none, right, left };
    private static readonly Quaternion[] rotations = {
        Quaternion.AngleAxis(0, Vector3.forward),
        Quaternion.AngleAxis(90, Vector3.forward),
        Quaternion.AngleAxis(-90, Vector3.forward)
    };
    private Queue<State> queue = new Queue<State>();
    private State status;

    private Quaternion targetRotation;
    // Use this for initialization
    void Start() {
        targetRotation = transform.rotation;
    }

    public void rotate(State st)
    {
        //if (transform.rotation == targetRotation)
        //{
            status = st;
            queue.Enqueue(st);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation == targetRotation && queue.Count > 0)
        {
            targetRotation *= rotations[(int)queue.Peek()];
            queue.Dequeue();
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        if (transform.rotation == targetRotation && (queue.Count == 0 || queue.Peek() != State.none))
            status = State.none;
    }

    public State getState()
    {
        return status;
    }
}
