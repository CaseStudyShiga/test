﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : CharBase
{
	GameObject _player;

	void ClickEvent()
	{
		var stage = this.Status.Stage.GetComponent<Stage>();

		this.SetStatusUI();

		if (this.Status.IsSelect == false)
		{
			this.OtherPlayersSelectOff();
			this.Status.SelectOn();

			stage.ClearPossibleMovePanel();
			stage.Search(this.Status.X, this.Status.Y - 1, this.Status.Move, 1);
			stage.Search(this.Status.X + 1, this.Status.Y, this.Status.Move, 2);
			stage.Search(this.Status.X, this.Status.Y + 1, this.Status.Move, 3);
			stage.Search(this.Status.X - 1, this.Status.Y, this.Status.Move, 4);
		}
		else
		{
			this.Status.SelectOff();
			stage.ClearPossibleMovePanel();
		}
	}

	void SetStatusUI()
	{
		var stage = this.Status.Stage.GetComponent<Stage>();
		var statusUIObj = stage.transform.parent.Find("TopUI/StatusUI");

		if (statusUIObj)
		{
			var statusUI = statusUIObj.GetComponent<StatusUI>();
			statusUI.SetHpText(this.Status.Hp.ToString(), this.Status.HpMax.ToString());
			statusUI.SetSimpleText("Name", this.Status.Name);
			statusUI.SetSimpleText("Attack", this.Status.Attack.ToString());
			statusUI.SetSimpleText("Move", this.Status.Move.ToString());
			statusUI.SetSimpleText("Range", this.Status.Range.ToString());
			statusUI.transform.parent.GetComponent<TopUI>().SetFaceSprite(this._player.GetComponent<Image>().sprite);
		}
	}

	public GameObject Create(Transform stage, StatusBase.eType type, int x, int y)
	{
		_player = this.CreateChild(type, "player", stage.Find("Players"), stage.gameObject, new Vector2(90, 90));
		_player.GetComponent<StatusBase>().SelectOff();
		_player.GetComponent<Button>().onClick.AddListener(this.ClickEvent);

		this.Status.SetColor(new Color32(255, 255, 255, 255), new Color32(200, 200, 255, 255), new Color32(255, 193, 143, 255), new Color32(150, 150, 150, 255));
		this.Status.SetPos(x, y);
		this.Status.MovedOff();
		this.Status.IsPlayer = true;

		return _player;
	}

	void OtherPlayersSelectOff()
	{
		foreach (Transform child in this._player.transform.parent)
		{
			child.GetComponent<StatusBase>().SelectOff();
		}
		this.Status.SelectOn();
	}
}