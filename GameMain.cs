using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.XInput;
using System.Collections.ObjectModel;
using System.Drawing;
using Untitled_Project.DrawHelpers;
using Untitled_Project.GameState;

namespace Untitled_Project
{
    public class GameMain : Game
    {
        private static GameMain instance;
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private GameStateManager gameStateManager;

        /******************GRAPHICS******************/
        public int[] resolution = new int[2] { 1024, 768 };
        public int TargetWidth = 1024;
        public int TargetHeight = 768;
        public Matrix Scale;
        /******************GRAPHICS******************/

        /******************SPRITEFONTS******************/
        public SpriteFont spriteFont;
        /******************SPRITEFONTS******************/

        /******************SPRITESHEETS******************/
        public Texture2D MenuArrowSpritesheet;
        public Texture2D BlockSpritesheet;
        public Texture2D WizardSpritesheet;
        public Texture2D TargetSpritesheet;
        public Texture2D WoodTilingSpritesheet;
        public Texture2D SimpleProjectileSpritesheet;
        public Texture2D NekoSpritesheet;
        public int characterSelection = 1;
        /******************SPRITESHEETS******************/

        /*LEVEL XML FILEPATHS*/
        public string[] Levels = new string[] {
            "C:\\Users\\erdat\\source\\repos\\Untitled Project\\LevelCreation\\LevelXMLs\\Level1.xml",
            "C:\\Users\\erdat\\source\\repos\\Untitled Project\\LevelCreation\\LevelXMLs\\Level2.xml"
        };
        /*LEVEL XML FILEPATHS*/

        public static GameMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameMain();

                    //set up graphics and initial screen size
                    instance.graphics = new GraphicsDeviceManager(instance)
                    {
                        IsFullScreen = false,
                        PreferredBackBufferWidth = 1024,
                        PreferredBackBufferHeight = 768,
                    };

                    instance.Content.RootDirectory = "Content";

                    instance.IsMouseVisible= true;
                }
                return instance;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            //Initialize the DrawHelpers with screen bounds
            DrawHelperManager.Initialize(TargetWidth, TargetHeight);

            //Creating and initializing the GameStateManager
            gameStateManager = new GameStateManager(this);
            gameStateManager.Initialize();

            //Set initial resolution scale, to be updated with the resolution
            SetScale(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        protected override void LoadContent()
        {
            spriteFont = Content.Load<SpriteFont>("Fonts/ArialFont18");
            MenuArrowSpritesheet = Content.Load<Texture2D>("Menu/MenuArrow");
            BlockSpritesheet = Content.Load<Texture2D>("Blocks/BlockSpritesheet");
            WizardSpritesheet = Content.Load<Texture2D>("Wizard/Wizard");
            TargetSpritesheet = Content.Load<Texture2D>("Misc/Target");
            WoodTilingSpritesheet = Content.Load<Texture2D>("Backgrounds/WoodTiling");
            SimpleProjectileSpritesheet = Content.Load<Texture2D>("Projectiles/SimpleProjectile");
            NekoSpritesheet = Content.Load<Texture2D>("Wizard/pipo-nekonin025");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            gameStateManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Scale);
            gameStateManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected static void Reset()
        {
            instance = new GameMain();
        }

        public static void SetScale(int width, int height)
        {
            float scaleX = (float)width / Instance.TargetWidth;
            float scaleY = (float)height / Instance.TargetHeight;
            Instance.Scale = Matrix.CreateScale(new Vector3(scaleX, scaleY, 1));
        }

        public static void UpdateResolution(int newWidth, int newHeight)
        {
            Instance.graphics.PreferredBackBufferWidth = newWidth;
            Instance.graphics.PreferredBackBufferHeight = newHeight;
            Instance.graphics.ApplyChanges();

            //Update Scale for drawing
            SetScale(newWidth, newHeight);
        }
    }
}