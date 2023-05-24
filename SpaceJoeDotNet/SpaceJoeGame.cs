#nullable disable

using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Bg;
using SpaceJoeDotNet.GameManager;

[assembly:InternalsVisibleTo("SpaceJoeDotNet.Tests")]
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
    SaveLoadManager _saveLoadManager;

    GameState _gameState = GameState.Menu;
    bool _gameSaved;
    bool _loadError;

    public SpaceJoeGame()
    {
        Graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true; 
    }

    public GraphicsDeviceManager Graphics { get; }
    public int Width => Graphics.PreferredBackBufferWidth;
    public int Height => Graphics.PreferredBackBufferHeight;
}