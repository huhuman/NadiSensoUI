# NadiSensoUI

統一 namespace
```csharp
namespace SensorUI {}
```
專案結構
![](https://i.imgur.com/AR7Jme0.png)
統一在UI資料夾內，根據不同的sensor創建資料夾，裡面至少包含 :
1. Prefab資料夾
2. Scene資料夾
3. Scripts資料夾

## SensorManagerBase.cs
Sensor管理，這個腳本有用Singleton模式，一個場景內只需要放一個。
基本上這腳本不需修改也不用繼承，只負責管理跟呼叫
* 要呼叫管理器可使用
``` csharp
SensorManagerBase.Instance
```
* 公用方法
``` csharp
// sensor會在awake時註冊到Dictionary內
public void AddSensor (string sensorType, SensorBase sensorBase) {}

// 透過管理器來控制所有指定sensor的UI的顯示
public void ShowUI (string sensorType) {}

// 透過管理器來控制所有指定sensor的UI的關閉
public void CloseUI (string sensorType) {}
```

## SensorBase.cs
不同的sensor就繼承這個腳本
* 共用參數
``` csharp
// 指定sensor種類名稱，例如sample內空調、對講機等
public string sensorType;

// 要顯示的 UI
public SensorUIBase sensorUI;

// 對應的資料ID，這邊可先用模擬資料的方式
public int dataId;
```
* 公用方法，由不同的sensor各自覆寫
```csharp
// 複寫顯示 UI 時該怎麼拿資料及處理資料並顯示UI與把資料指定給UI，可能會有的額外功能是顯示動畫
// 可以先模擬需要的資料，例如 data=["20度"]。如果之後收到的資料格式不是string[]，就也在這部份把資料處理成string[]
// 然後打開UI並呼叫sensorUI.Show(data)
public virtual void ShowUI () {}

// 複寫關閉 UI ，可能會有的額外功能是關閉動畫
public virtual void CloseUI () {}
```
* 私有方法
```csharp
// 在Awake時sensor把自己透過sensor類型註冊到管理器內
protected virtual void Awake () {
    SensorManagerBase.Instance.AddSensor (sensorType, this);
}
```

## SensorUIBase.cs
* 公用方法，由不同的UI各自繼承覆寫
``` csharp
// 覆寫收到資料後各 UI 怎麼繪製資料
public virtual void Show (string[] data) {}

// 覆寫UI關閉
public virtual void Close () {}
```
