#nullable disable

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Bg;
using SpaceJoeDotNet.Utils;
using Color = Microsoft.Xna.Framework.Color;
using SpaceJoeDotNet.GameManager;

namespace SpaceJoeDotNet;

enum GameState
{
    Menu,
    InGame,
    Paused,
    GameOver,
    Shop
}

public partial class SpaceJoeGame : Game
{
    SpriteBatch _spriteBatch;
    SpriteFont _gameFont;

    Player _player;
    Background _background;
    IAsteroidManager _asteroidManager;
    IProjectileManager _projectileManager;
    ICollisionManager _collisionManager;

    float _scoreCounter;

    GameState _gameState = GameState.Menu;

    public SpaceJoeGame()
    {
        Instance = this;
        Graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true; 
    }

    public GraphicsDeviceManager Graphics { get; }
    public static SpaceJoeGame Instance { get; private set; }
}