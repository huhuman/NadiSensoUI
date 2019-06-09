using Battlehub.RTCommon;
using Lean.Touch;

namespace NADISystemEditor
{
    /// <summary>
    /// 邏輯物件組件: 此處建立 觸碰組件關係，從新實作邏輯物件
    /// </summary>
    public class LogicObjectComponent : BaseComponent
    {
        /// <summary>
        /// 邏輯物件
        /// </summary>
        public LogicObject logicObject;

        /// <summary>
        /// 選擇方式 Runtime Editor
        /// </summary>
        public ExposeToEditor exposeToEditor;

        /// <summary>
        /// 選擇方式 Lean Touch
        /// </summary>
        public LeanSelectable leanSelectable;

        public override void Awake()
        {
            base.Awake();
            //取得管理者的邏輯物件
            logicObject = nadiSystemEditor.logicObject;
            //
            exposeToEditor = GetComponent<ExposeToEditor>();
            leanSelectable = GetComponent<LeanSelectable>();
        }

        private void Start()
        {
            RegisterSelectModeForRuntimeEditor();
            RegisterSelectModeForLeanTouch();
        }

        /// <summary>
        /// 註冊選擇模式: RuntimeEditor
        /// </summary>
        public void RegisterSelectModeForRuntimeEditor()
        {
            exposeToEditor.Selected.AddListener(arg0 =>
            {
                logicObject.events.selectedEvent += OnSelected;
                logicObject.events.OnSelected();
            });

            exposeToEditor.Unselected.AddListener(arg0 =>
            {
                logicObject.events.deselectedEvent += OnDeselected;
                logicObject.events.OnDeselected();
                //移除註冊
                OnDestroy();
            });
        }

        /// <summary>
        /// 註冊選擇模式: LeanTouch
        /// </summary>
        public void RegisterSelectModeForLeanTouch()
        {
            leanSelectable.OnSelect.AddListener(arg0 =>
            {
                logicObject.events.selectedEvent += OnSelected;
                logicObject.events.OnSelected();
                
                //取得註冊數量
//                logicObject.events.GetSelectedHandleListLength();
            });

            leanSelectable.OnDeselect.AddListener(() =>
            {
                logicObject.events.deselectedEvent += OnDeselected;
                logicObject.events.OnDeselected();
                
                //移除註冊
                OnDestroy();

            });
        }

        public void OnSelected()
        {
            logicObject.SetGameObject(gameObject);
//            Debug.Log("選擇了 " + gameObject);
        }

        public void OnDeselected()
        {
            logicObject.SetGameObject(null);
//            Debug.Log("取消選擇了 " + gameObject);
        }

        private void OnDestroy()
        {
            logicObject.events.selectedEvent -= OnSelected;
            logicObject.events.deselectedEvent -= OnDeselected;
        }
        
    }
}