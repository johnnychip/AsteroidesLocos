using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
	{
		private static GameManager instance;

		public static GameManager Instance
		{
			get
			{ 
				return instance;
			}
		}

		private int score;

		public int Score
		{
			get
			{ 
				return score;
			}
		}

		private void Awake ()
		{
			if (instance != null)
				Destroy (gameObject);
			else
				instance = this;
		}

		public void NotifyHit ()
		{
			score++;
		}
	}

