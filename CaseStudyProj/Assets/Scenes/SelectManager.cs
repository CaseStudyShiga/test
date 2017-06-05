﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Area
{
	public int ID;
	public string Name;
	public int Difficulty;
	public int StageNumMax;

	public Area(int id, string t, int n)
	{
		this.ID = id;
		this.Name = t;
		this.Difficulty = n;

		switch (this.ID)
		{
			case 0:
				this.StageNumMax = 2;
				break;
			case 1:
				this.StageNumMax = 0;
				break;
			case 2:
				this.StageNumMax = 0;
				break;
			case 3:
				this.StageNumMax = 0;
				break;
			case 4:
				this.StageNumMax = 0;
				break;
			default:
				this.StageNumMax = 0;
				break;
		}
	}
}

class SelectManager
{
	static SelectManager _instance;

	public static SelectManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SelectManager();
				_instance.InitField();
			}
			return _instance;
		}
	}

	List<Area> _areaList;
	int _stageID;

	public List<Area> AreaList { get { return this._areaList; } }
	public int StageID { get { return this._stageID; } set { this._stageID = value; } }

	void InitField()
	{
		this._areaList = new List<Area>();
		this._areaList.Add(new Area(0, "新宿", 1));
		this._areaList.Add(new Area(0, "つつじヶ丘", 2));
		this._areaList.Add(new Area(0, "群馬", 3));
		this._areaList.Add(new Area(0, "HAL東京", 4));
		this._areaList.Add(new Area(0, "魔界", 5));
		this._stageID = 0;
	}
}