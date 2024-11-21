using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Topic_4_monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bomb;
        Rectangle bombRect;
        float seconds;
        SoundEffect explode;
        SoundEffectInstance explodeInstance;
        Texture2D cuttersTexture;
        SpriteFont timeFont;
        MouseState mouseState;
        Texture2D explosion;
        Rectangle explosionRect;
        bool done;
        Rectangle cuttersRect;
        bool finish;
        Rectangle greenRect, greenRect2, redRect, redRect2, redRect3;
        SoundEffect cheer;
        SoundEffectInstance cheerInstance;
        bool cheering; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bombRect = new Rectangle(50,50,700,400);
            explosionRect = new Rectangle(0,0, 700, 570);
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.ApplyChanges();
            seconds = 0f;
            done = false;
            cuttersRect = new Rectangle(0,0, 100,100);
            base.Initialize();
            finish = false;
            greenRect = new Rectangle(490,160,110,15);
            greenRect2 = new Rectangle(680, 180, 30, 60);
            redRect = new Rectangle(490, 180, 100, 25);
            redRect2 = new Rectangle(670, 170, 80, 10);
            redRect3 = new Rectangle(715, 180, 35, 75);
            cheering = false;  
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bomb = Content.Load<Texture2D>("bomb");
            timeFont = Content.Load<SpriteFont>("timeFont");
            explode = Content.Load<SoundEffect>("explosion");
            explodeInstance = explode.CreateInstance();
            cuttersTexture = Content.Load<Texture2D>("Untitled");
            explosion = Content.Load<Texture2D>("explosion.2");
            cheer = Content.Load<SoundEffect>("CHEERING_AND_CLAPPING_cct");
            cheerInstance = cheer.CreateInstance();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";
            cuttersRect.Location = mouseState.Position;
            if (!finish)
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (seconds > 15)
            {
                seconds = 0f;
                explodeInstance.Play();
                done = true;

                
                
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (done)
            {
                 if (explodeInstance.State == SoundState.Stopped)
                    Exit();
            }
            if (cheering)
                if (cheerInstance.State == SoundState.Stopped)
                    Exit();    
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (greenRect.Contains(mouseState.Position))
                {
                    finish = true;
                    cheerInstance.Play();
                    cheering = false;
                }



                if (greenRect2.Contains(mouseState.Position))
                {
                    finish = true;
                    cheerInstance.Play();
                    cheering = true;
                }            
            
            
                if (redRect.Contains(mouseState.Position))
                {
                    seconds = 0f;
                    explodeInstance.Play();
                    done = true;
                }
            
            
            
                if (redRect2.Contains(mouseState.Position))
                {
                    seconds = 0f;
                    explodeInstance.Play();
                    done = true;
                }
            
            
            
                if (redRect3.Contains(mouseState.Position))
                {
                    seconds = 0f;
                    explodeInstance.Play();
                    done = true;
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(bomb, bombRect, Color.White);   
            _spriteBatch.DrawString(timeFont, (15 - seconds).ToString("00.0"), new Vector2(270, 200), Color.Black);
            if (done == true)
            {
                _spriteBatch.Draw(explosion, explosionRect, Color.White);
            }
            _spriteBatch.Draw(cuttersTexture, cuttersRect, Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
