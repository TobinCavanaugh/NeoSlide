using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Quaternion originRotation;
    
    [Header("Intensities")]
    public float moveIntensity = 1f;
    public float tiltAmount = 1f;
    public float maxTiltAmount = 35f;
    
    [Header("Smoothing")]
    public float rotSmooth = 10f;
    public float moveSmooth = .1f;

    [Header("Rotational Axes")] 
    public bool xRotation = true;
    public bool yRotation = true;
    public bool zRotation = true;

    void Start() {
        originRotation = transform.localRotation;
    }

    // This is done in late update so it happens AFTER the animator
    void LateUpdate() {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        
        UpdateSway(xMouse, yMouse);
        TiltSway(xMouse, yMouse);
    }

    /// <summary>
    /// Side to side move sway
    /// </summary>
    /// <param name="xMouse">X mouse input</param>
    /// <param name="yMouse">Y mouse input</param>
    void UpdateSway(float xMouse, float yMouse) {
        
        Quaternion xAdj = Quaternion.AngleAxis(-moveIntensity * xMouse, Vector3.up);
        Quaternion yAdj = Quaternion.AngleAxis(moveIntensity * yMouse, Vector3.right);
        Quaternion tarRot = originRotation * xAdj * yAdj;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, tarRot, Time.deltaTime * moveSmooth);
    }

    /// <summary>
    /// Side to side tilting sway
    /// </summary>
    /// <param name="xMouse">X mouse input</param>
    /// <param name="yMouse">Y mouse input</param>
    void TiltSway(float xMouse, float yMouse) {
        float tiltX = Mathf.Clamp(yMouse * tiltAmount, -maxTiltAmount, maxTiltAmount);
        float tiltY = Mathf.Clamp(xMouse * tiltAmount, -maxTiltAmount, maxTiltAmount);
        
        Quaternion finalRot = Quaternion.Euler(
            new Vector3(
                xRotation ? -tiltX : 0f,
                yRotation ? -tiltY : 0f,
                zRotation ? tiltY : 0f
            ));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRot * originRotation, Time.deltaTime * rotSmooth);
    }
}


