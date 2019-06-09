using NADISystemEditor;

public class TimeBarComponent : BaseComponent
{
    /// <summary>
    /// 時間軸物件
    /// </summary>
    public TimeBar timeBar;

    public GUITimeBar guiTimeBar;

    public override void Awake()
    {
        base.Awake();
        //取得管理者的邏輯物件
        timeBar = nadiSystemEditor.timeBar;

        //取得GUI組件
        guiTimeBar = GetComponent<GUITimeBar>();
    }

    private void Start()
    {
        //註冊 當前時間 的方式
        timeBar.events.currentTimeEvent += OnCurrentTime;
        
    }

    private void Update()
    {
        //發起事件
        timeBar.events.OnCurrentTime();
    }

    /// <summary>
    /// 執行當前時間
    /// </summary>
    public double OnCurrentTime()
    {
        if (timeBar.currentTime != guiTimeBar.GetValue())
        {
            /*決定要註冊的內容*/
            timeBar.currentTime = guiTimeBar.GetValue();
//            Debug.Log("檢查是否一直運行");
        }
        return guiTimeBar.GetValue();
    }

    private void OnDestroy()
    {
        //銷毀時 取消對管理者的註冊(*任何不再使用狀態時取消註冊)
        timeBar.events.currentTimeEvent -= OnCurrentTime;
        
    }
}