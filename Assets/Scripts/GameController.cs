using UnityEngine;
using System.Collections;

public class GameController : Singleton<GameController> {

	protected GameController () {}

	Player sPlayer;

	//Controllers
	UIController sUIController;

	//Score managers
	ScoreKeeper sScoreKeeper;
	LifeKeeper sLifeKeeper;
	CoinKeeper sCoinKeeper;

	//PowerUps
	HeartGenerator sHeartGenerator;

    //Member variables
    public string mGameMenuSceneName;

	// Use this for initialization
	void Start () {
	
	}

	
	void Awake()
	{
		sPlayer = Player.Instance;
		
		//Controllers
		sUIController = UIController.Instance;
		
		//Score managers
		sScoreKeeper = ScoreKeeper.Instance;
		sLifeKeeper = LifeKeeper.Instance;
		sCoinKeeper = CoinKeeper.Instance;
		
		//PowerUps
		sHeartGenerator = HeartGenerator.Instance;

		//Toolbox.RegisterComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die()
	{
		Debug.Log("GameController::Die()");
		sLifeKeeper.LifeLost ();
		if (!sLifeKeeper.isLifeLeft ())
			GameOver ();
		sUIController.LivesChanged (sLifeKeeper.getLivesLeft ());
	}

	public void GameOver()
	{
		Debug.Log("GameController::GameOver()");
		sPlayer.Die ();
        Application.LoadLevel(mGameMenuSceneName);
	}

	public void CoinCollected()
	{
		sCoinKeeper.CoinCollected ();
		sUIController.CoinCollected (sCoinKeeper.getCoinsCollected());
	}

	public int getCoinsCollected()
	{
		return sCoinKeeper.getCoinsCollected();
	}

	public void ScoreChanged(int score)
	{
		sUIController.ScoreChanged (score);
	}

	public void HeartCollected()
	{
		sLifeKeeper.LifeGained ();
		sUIController.LivesChanged (sLifeKeeper.getLivesLeft());
	}

	public void SpawnPowerUp ()
	{
		sHeartGenerator.SpawnObject ();
	}

    public void JumpButtonPressed()
    {
        sPlayer.Jump();
    }

    public void DownButtonPressed()
    {
        sPlayer.ComeDown();
    }
}
