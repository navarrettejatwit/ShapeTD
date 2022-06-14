using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class State
{
    protected static Play play = new Play();

    protected static GameOver gameOver = new GameOver();

    protected static Reset reset = new Reset();

    protected static Pause pause = new Pause();

    public enum STATE
    {
        PLAY, GAMEOVER, RESET, PAUSE
    }
    public enum EVENT
    {
        EXIT, UPDATE, ENTER
    }

    public STATE name;

    protected EVENT stage;

    protected State nextState;

    protected GameManager gameManager;

    public State()
    {
        gameManager = GameManager.instance();
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            nextState.stage = EVENT.ENTER;
            return nextState;
        }

        return this;
    }
}


public class Play : State
{
    public Play() : base()
    {
        name = STATE.PLAY;
        stage = EVENT.ENTER;
    }

    public override void Enter()
    {
        gameManager = GameManager.instance();
        stage = EVENT.ENTER;
        base.Enter();
    }

    public override void Update()
    {
        //if (gameManager.dead() == true)
        //{
            nextState = gameOver;
            stage = EVENT.EXIT;
            return;
        //}
        //if (Input.GetKeyDown(KeyCode.P))
        //{
            //nextState = pause;
            //stage = EVENT.EXIT;
            //return;
        //}
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class GameOver : State
{
    public GameOver() : base()
    {
        name = STATE.GAMEOVER;
        stage = EVENT.ENTER;
    }

    public override void Enter()
    {
        gameManager = GameManager.instance();
        stage = EVENT.ENTER;
        //gameManager.gameOver();
        base.Enter();
    }

    public override void Update()
    {
        //gameManager.gameOverCanvas(true);
        //if (gameManager.gameOverCanvas.activeSelf)
        //{
            nextState = reset;
            stage = EVENT.EXIT;
        //}
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Reset : State
{
    public Reset() : base()
    {
        name = STATE.RESET;
        stage = EVENT.ENTER;
    }

    public override void Enter()
    {
        gameManager = GameManager.instance();
        stage = EVENT.ENTER;
        //gameManager.reset();
        base.Enter();
    }

    public override void Update()
    {
        nextState = play;
        stage = EVENT.EXIT;
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Pause : State
{
    public Pause() : base()
    {
        name = STATE.RESET;
        stage = EVENT.ENTER;
    }

    public override void Enter()
    {
        gameManager = GameManager.instance();
        stage = EVENT.ENTER;
        base.Enter();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            nextState = play;
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}