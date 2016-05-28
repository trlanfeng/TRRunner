using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        Normal,
        Faild,
        Success
    }
    GameState gameState = GameState.Normal;
    public Transform player;
    public float dieX;
    public float dieY;
    public CanvasGroup Panel_Success;
    public CanvasGroup Panel_Faild;
    void Start()
    {
        gameState = GameState.Normal;
    }

    void Update()
    {
        if ((player.position.x < dieX || player.position.y < dieY) && gameState == GameState.Normal)
        {
            Time.timeScale = 0;
            showUI(-1);
            gameState = GameState.Faild;
        }
    }

    void hideUI()
    {
        Panel_Success.DOFade(0, 1f).SetEase(Ease.OutElastic);
        Panel_Faild.DOFade(0, 1f).SetEase(Ease.OutElastic).SetUpdate(true);
    }

    void showUI(int type)
    {
        if (type == 1)
        {
            Panel_Success.DOFade(1, 1f).SetEase(Ease.OutElastic).SetUpdate(true);
            Panel_Success.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic).SetUpdate(true);
        }
        else if (type == -1)
        {
            Panel_Faild.DOFade(1, 1f).SetEase(Ease.OutElastic).SetUpdate(true);
            Panel_Faild.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic).SetUpdate(true);
        }
    }
}
