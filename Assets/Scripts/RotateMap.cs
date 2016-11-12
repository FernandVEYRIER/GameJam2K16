using UnityEngine;

public class RotateMap : MonoBehaviour {

    public float speed = 1f;
    private Quaternion qRight;
    private Quaternion qLeft;
    private enum State { none, right, left };
    private State status;

    private Quaternion targetRotation;
    // Use this for initialization
    void Start() {
        targetRotation = transform.rotation;
        qRight = Quaternion.AngleAxis(90, Vector3.forward);
        qLeft = Quaternion.AngleAxis(-90, Vector3.forward);
    }

    public void rotateLeft()
    {
        if (targetRotation == transform.rotation)
            status = State.left;
    }

    public void rotateRight()
    {
        if (targetRotation == transform.rotation)
            status = State.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == State.right)
        {
            targetRotation *= qRight;
            status = State.none;
        }
        else if (status == State.left)
        {
            targetRotation *= qLeft;
            status = State.none;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * speed * Time.deltaTime);
    }
}
