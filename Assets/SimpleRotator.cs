using UnityEngine;

public enum RotationAxis
{
    XAXIS,
    YAXIS,
    ZAXIS
}
[DisallowMultipleComponent]
public class SimpleRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = default;
    [SerializeField] RotationAxis rotationAxis = RotationAxis.YAXIS;
    [SerializeField] bool reverse = false;

    private void Update()
    {
        var actualRotationSpeed = reverse ? rotationSpeed * Time.deltaTime : -rotationSpeed * Time.deltaTime;
        switch (rotationAxis)
        {
            case RotationAxis.XAXIS:
                transform.Rotate(new Vector3(actualRotationSpeed, 0f, 0f));
                break;
            case RotationAxis.ZAXIS:
                transform.Rotate(new Vector3(0f, 0f, actualRotationSpeed));
                break;
            default:
                transform.Rotate(new Vector3(0f, actualRotationSpeed, 0f));
                break;
        }
    }
}
