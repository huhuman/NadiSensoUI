using Lean.Touch;
using UnityEngine;

namespace NADILeanTouch
{
    /// <summary>
    /// [模組]：LeanTouch 攝影機
    /// </summary>
    public class LeanTouchCamera : MonoBehaviour
    {
        /// <summary>
        /// 攝影機設定
        /// </summary>
        public CameraSetting cameraSetting;

        public LeanTouchSetting leanTouchSetting;
        public GUI3DCamera gui3DCamera;

        [ContextMenu("初始化")]
        public void Awake()
        {
            cameraSetting.OnAwake(this);
            leanTouchSetting.OnAwake(this);
            gui3DCamera.OnAwake(this);
            gui3DCamera.UpdateSetting(cameraSetting.pivot.gameObject, cameraSetting.camera);
        }

        private void Start()
        {
            cameraSetting.OnStart();
            gui3DCamera.OnStart();
        }

        private void Update()
        {
            cameraSetting.OnUpdate();
            gui3DCamera.OnUpdate();
        }

        public void LateUpdate()
        {
            //更新3d gui攝影機
            if (gui3DCamera != null && cameraSetting != null)
            {
                //更新GUI 3d 
                gui3DCamera.UpdateSetting(cameraSetting.pivot.gameObject, cameraSetting.camera);
                //更新3DGUI看著攝影機
                gui3DCamera.UpdateBillboardLookAt();
            }
        }

        /// <summary>
        /// 觸碰設定
        /// </summary>
        [System.Serializable]
        public class LeanTouchSetting
        {
            private LeanTouch leanTouch;
            private LeanSelect leanSelect;
            private LeanFingerTap leanFingerTap;

            public void OnAwake(MonoBehaviour monoBehaviour)
            {
                leanTouch = monoBehaviour.transform.Find("LeanTouch").GetComponent<LeanTouch>();
                leanSelect = monoBehaviour.transform.Find("LeanTouch").GetComponent<LeanSelect>();
                leanFingerTap = monoBehaviour.transform.Find("LeanTouch").GetComponent<LeanFingerTap>();
            }
        }

        /// <summary>
        /// 攝影機設定
        /// </summary>
        [System.Serializable]
        public class CameraSetting
        {
            /// <summary>
            /// 當前攝影機
            /// </summary>
            public Camera camera;

            /// <summary>
            /// 攝影機軸心
            /// </summary>
            public Transform pivot;

            public LeanPitchYawSmooth leanPitchYawSmooth;
            public LeanCameraMoveSmooth leanCameraMoveSmooth;
            public LeanCameraZoomSmooth leanCameraZoomSmooth;

            public void OnAwake(MonoBehaviour monoBehaviour)
            {
                pivot = monoBehaviour.transform.Find("Pivot").transform;
                camera = pivot.transform.Find("Camera")
                    .GetComponent<Camera>();
                leanPitchYawSmooth = pivot.GetComponent<LeanPitchYawSmooth>();
                leanCameraMoveSmooth = pivot.GetComponent<LeanCameraMoveSmooth>();
                leanCameraZoomSmooth = pivot.GetComponent<LeanCameraZoomSmooth>();
            }
            
            public void OnStart()
            {
                //防止官方對攝影機參數的BUG
                camera.rect = new Rect(0, 0, 1, 1);
            }
            
            public void OnUpdate()
            {
                //防止官方對攝影機參數的BUG
                if (camera.rect != new Rect(0, 0, 1, 1))
                {
                    camera.rect = new Rect(0, 0, 1, 1);
                }
            }
        }

        /// <summary>
        /// 使用在LeanTouch的 3dgui攝影機
        /// </summary>
        [System.Serializable]
        public class GUI3DCamera
        {
//            [Header("GUI3d軸心")] 
            /// <summary>
            /// GUI3d軸心
            /// </summary>
            private GameObject pivot;

//            [Header("GUI3d用攝影機")] 
            /// <summary>
            /// GUI3d用攝影機
            /// </summary>
            public Camera camera;

            public void OnAwake(MonoBehaviour monoBehaviour)
            {
                pivot = monoBehaviour.transform.Find("GUI3DCameraPivot").gameObject;
                camera = pivot.transform.Find("GUI3DCamera")
                    .GetComponent<Camera>();
            }

            public void OnStart()
            {
                camera.rect = new Rect(0, 0, 1, 1);
            }

            public void OnUpdate()
            {
                //防止官方對攝影機參數的BUG
                if (camera.rect != new Rect(0, 0, 1, 1))
                {
                    camera.rect = new Rect(0, 0, 1, 1);
                }
            }

            public void UpdateSetting(GameObject pivot, Camera targetCamera)
            {
                if (this.pivot != null)
                {
                    this.pivot.transform.position = pivot.transform.position;
                    this.pivot.transform.localEulerAngles = pivot.transform.localEulerAngles;
                    camera.transform.position = targetCamera.transform.position;
                    camera.fieldOfView = targetCamera.fieldOfView;
                }
            }

            /// <summary>
            /// 更新：讓3DGUI看著攝影機(選擇標籤 為 Billboard 的物件就會看著這個3d攝影機，正z朝目標，可在子物件加上180度旋轉軸)
            /// </summary>
            public void UpdateBillboardLookAt()
            {
                if (camera != null)
                {
                    GameObject[] billboards = GameObject.FindGameObjectsWithTag("Billboard");
                    foreach (GameObject billboard in billboards)
                    {
                        billboard.transform.LookAt(camera.transform);
                        billboard.transform.eulerAngles =
                            new Vector3(camera.transform.eulerAngles.x + 180,
                                camera.transform.eulerAngles.y - 0,
                                camera.transform.localEulerAngles.z + 180);
                    }
                }
            }
        }
    }
}