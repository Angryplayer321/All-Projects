using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class QuestManager : MonoBehaviour
{
	private int[] arr = {2, 3, 1, 0};

	private int cnt=0;

	private Renderer cellRenderer;

	[SerializeField] private Renderer cell0;

	[SerializeField] private Renderer cell1;

	[SerializeField] private Renderer cell2;

	[SerializeField] private Renderer cell3;

	private Color defultColor;

	public static bool gameHasStoped = false;





	private void OnEnable()
	{
		EventManager.
			Instance.AddListener<CellActivatedEvent>(CellActivatedEventHandler);
		EventManager.
			Instance.AddListener<ResetGameEvent>(ResetGameEventHandler);
	}

	private void OnDisable()
	{
		EventManager.
			Instance.RemoveListener<CellActivatedEvent>(CellActivatedEventHandler);
		EventManager.
			Instance.RemoveListener<ResetGameEvent>(ResetGameEventHandler);
	}

	public void CellActivatedEventHandler(CellActivatedEvent cellEvent)
	{
		if (!CommandManager.isUndoing)
		{

			cellRenderer = cellEvent.cellObject.GetComponent<Renderer>();

			defultColor = cellRenderer.material.color;

			if (arr[cnt] == cellEvent.ID)
			{
				cellRenderer.material.SetColor("_Color", Color.green);
				if (cnt == 3)
				{
					EventManager.Instance.Raise(new PlayerWinEvent());
					Time.timeScale = 0;
					gameHasStoped = true;
				}
			}
			else
			{
				cellRenderer.material.SetColor("_Color", Color.red);
				EventManager.Instance.Raise(new PlayerLoseEvent());
				Time.timeScale = 0;
				gameHasStoped = true;

			}
			cnt++;
		}
	}

	private void ResetGameEventHandler(ResetGameEvent resetEvent)
    {
		cnt = 0;
		ResetAllCellColors();
		gameHasStoped = false;
    }

	private void ResetAllCellColors()
    {
		cell0.material.SetColor("_Color", defultColor);

		cell1.material.SetColor("_Color", defultColor);

		cell2.material.SetColor("_Color", defultColor);

		cell3.material.SetColor("_Color", defultColor);

	}


}
