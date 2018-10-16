

using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject TargetObject;

    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);

    float distance = 3f;
    public float diffR = 0.01f;

    //Unityちゃんとカメラの距離
    private float difference;

    private void Start()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

        

    }   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newAngle = MainCamera.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
            MainCamera.gameObject.transform.localEulerAngles = newAngle;

            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            var rotation = Quaternion.LookRotation(TargetObject.transform.position - MainCamera.transform.position);

            MainCamera.transform.DORotateQuaternion(rotation, 0.5f)
                .SetEase(Ease.InOutBounce)
                .OnComplete(() => Debug.Log("Finished"));
        }
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            transform.position += transform.forward * scroll;
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

    }

}
    
