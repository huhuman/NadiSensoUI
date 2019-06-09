using UnityEngine;

namespace NADISystemEditor
{
    /// <summary>
    /// NADI編輯模式主要執行
    /// </summary>
    public class NADISystemEditor : MonoBehaviour
    {

        [Header("邏輯物件")] public LogicObject logicObject = new LogicObject();
        
//        [Header("顯示")] public Display display = new Display();

//        [Header("警報")] public Alarm alarm = new Alarm();

//        [Header("視窗佈局")] public WindowsLayout windowsLayout = new WindowsLayout();

//        [Header("系統連線")] public SystemConnection systemConnection = new SystemConnection();

//        [Header("設定")] public Setting setting = new Setting();

        [Header("時間軸")] public TimeBar timeBar = new TimeBar();

//        [Header("樹狀選單")] public TreeMenu treeMenu = new TreeMenu();

//        [Header("狀態")] public Status status = new Status();


        [ContextMenu("初始化")]
        private void Awake()
        {
            logicObject.OnAwake(this);
            timeBar.OnAwake(this);
//            status.OnAwake(this);
        }

        private void Update()
        {
            logicObject.OnUpdate();
            timeBar.OnUpdate();
//            status.OnUpdate();
        }
    }
}