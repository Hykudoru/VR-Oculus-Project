/*using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour 
{
	public delegate void SomeEvent(Rigidbody rb);
	public event SomeEvent CallBehaviors;

	public void OnCallBehaviors(Rigidbody rb)
	{
		if (CallBehaviors != null) {
			CallBehaviors(rb);
		}
	}

}

//Master Scripts
public class GameManagerMaster : MonoBehaviour 
{
	public delegate void GameManagerEventHandler();
	public static event GameManagerEventHandler MenuToggleEvent;
	public static event GameManagerEventHandler InventoryUIToggleEvent;
	public static event GameManagerEventHandler RestartLevelEvent;
	public static event GameManagerEventHandler GoToMenuSceneEvent;
	public static event GameManagerEventHandler GameOverEvent;

	public bool isGameOver;
	public bool isInventoryUIActive;
	public bool isMenuActive;

	public void CallMenuToggleEvent()
	{
		if (MenuToggleEvent != null) {
			MenuToggleEvent();
		}
	}

	public void CallInventoryUIToggle()
	{
		if (InventoryUIToggleEvent != null) {
			InventoryUIToggleEvent();
		}
	}
		
}

//GameManager Scripts
public class GameManagerTogglePause : MonoBehaviour
{
	private GameManagerMaster gameManagerMaster;
	private bool isPaused;

	void OnEnable()
	{
		init();
		gameManagerMaster.MenuToggleEvent += TogglePause;
		gameManagerMaster.InventoryUIToggleEvent += TogglePause;
	}

	void OnDisable()
	{
		gameManagerMaster.MenuToggleEvent -= TogglePause;
		gameManagerMaster.InventoryUIToggleEvent -= TogglePause;
	}

	void init()
	{
		gameManagerMaster = GetComponent<GameManagerMaster>();
	}

	void TogglePause()
	{
		if (isPaused) {
			Time.timeScale = 1;
			isPaused = false;
		} else {
			Time.timeScale = 0;
			isPaused = true;
		}
	}

}
*/