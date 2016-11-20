using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    private enum State { none, open, close };
    private State st;
    private Quaternion targetRotation;
    public float speed = 1;

    void Start()
    {
        Invoke("Open", 2.5f);
        targetRotation = transform.localRotation;
    }

    public void Close()
    {
       st = State.close;
    }

    public void Open()
    {
        st = State.open;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * speed);
        if (transform.localRotation == targetRotation)
        {
            switch (st)
            {
                case State.open:
                    targetRotation = Quaternion.Euler(0, 0, -120);
                    st = State.none;
                    break;
                case State.close:
                    targetRotation = Quaternion.Euler(0, 0, 0);
                    Invoke("Open", 1f);
                    st = State.none;
                    break;
                default:
                    break;
            }
        }
    }
}
