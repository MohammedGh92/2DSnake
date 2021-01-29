using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller responsible for game over phase.
/// </summary>
public class GameOverController : SubController<UIGameOverRoot>
{
    public override void EngageController()
    {
        ui.GameOverView.OnRestartGame += RestartGame;
        base.EngageController();
    }

    public override void DisengageController()
    {
        base.DisengageController();
        // Detaching UI events.
        ui.GameOverView.OnRestartGame -= RestartGame;
    }

    /// <summary>
    /// Handling UI Replay Button Click.
    /// </summary>
    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
