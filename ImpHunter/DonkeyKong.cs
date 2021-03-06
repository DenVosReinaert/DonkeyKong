﻿using ImpHunter.GameStates;
using Microsoft.Xna.Framework;

namespace DonkeyKong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DonkeyKong : GameEnvironment
    {
        public DonkeyKong()
        {
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            Screen = new Point(800, 800);
            ApplyResolutionSettings();




            // TODO: use this.Content to load your game content here
            GameStateManager.AddGameState("Level1", new Level1());
            GameStateManager.AddGameState("Level2", new Level2());

            GameStateManager.AddGameState("TitleScreenState", new TitleScreenState());
            GameStateManager.AddGameState("WinState", new WinState());
            GameStateManager.AddGameState("GameOverState", new GameOverState());
            GameStateManager.AddGameState("Thank You For Playing", new ThankYouForPlayingState());


            GameStateManager.SwitchTo("TitleScreenState");
        }

    }
}
