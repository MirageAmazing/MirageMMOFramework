using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Character
{
    public IReactiveProperty<UInt64> Health { get; private set; }
    public IReactiveProperty<bool> IsDead { get; private set; }

    public Character(UInt64 health)
    {
        Health = new ReactiveProperty<UInt64>(health);
        IsDead = Health.Select(x => x <= 0).ToReactiveProperty<bool>();
    }
}

public class RxTest : MonoBehaviour {

    public Slider slider;

    Character player = new Character(1000);

    public void Awake()
    {
       
    }

    void Start()
    {
        slider.OnValueChangedAsObservable().Subscribe(x => player.Health.Value = (ulong)(x*1000));

        player.IsDead.Where(x => x == true).Subscribe(x=>MyConsole.Color(Color.red));
        player.IsDead.Where(x => x == false).Subscribe(x=>MyConsole.Color(Color.green));
        //player.Health.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
