using UnityEngine;
using strange.extensions.command.impl;
using UnityEngine.SceneManagement;

public class FirstCommand : EventCommand
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    public override void Execute()
    {
        dispatcher.Dispatch(GameEvents.CommandEvent.ToCreateService);
        Object.DontDestroyOnLoad(GameObject.Find("GameRoot"));
        GameObject sdv = new GameObject("C2GView");
        sdv.AddComponent<C2GView>();
        UnityEngine.Object.DontDestroyOnLoad(sdv);
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }


}

