using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Portal2D.Models;
using System.Collections.Generic;

namespace Portal2D
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;

        // Player input
        // Teclado
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        // Gamepad 
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        //Mouse s
        MouseState currentMouseState;
        MouseState previousMouseState;

        // A movement speed for the player
        float playerMoveSpeed;


        //List<Wall> walls;
        Wall[] wall;
        Texture2D auxiliarTexture;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        
        protected override void Initialize()
        {
            base.Initialize();
            //walls = new List<Wall>();
        }

        //Carrega os assets do jogo.
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here

            // Instanciando a variável que se comunica com a placa gráfica.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Seta a posição inicial do player
            // Load the player resources
            Vector2 playerPosition = new Vector2(400,400);

            //player.Initialize(Content.Load<Texture2D>("Graphics\\player"), playerPosition);


            // Seta  uma variável como textura para poder passar no new Player()
            // Para o player deixar de ser Null
            auxiliarTexture = Content.Load<Texture2D>("player");

            player = new Player(auxiliarTexture); // antes de fazer isso player sempre era
                                                  // = null

            // Setando a constante de velocidade do player
            playerMoveSpeed = 8.0f;

            //inicialização do player
            player.Initialize(auxiliarTexture, playerPosition);

            // Trocando a textura do auxiliar, para a wall deixar de ser Null
            auxiliarTexture = Content.Load<Texture2D>("wall");
            wall = new Wall[56];

            // Instanciando as paredes
            for (int i = 1; i < 57; i++)
            {
                wall[i - 1] = new Wall(auxiliarTexture);
            }

            for(int i = 1; i < 29; i++)
            {

                // Inicialização das paredes
                if (i < 16) //Inicializando as posições das paredes horizontais
                {
                    wall[i-1].Initialize(//Content.Load<Texture2D>("wall"), 
                        new Vector2(100 + i * 32, 432),
                        true, true);

                    wall[i + 27].Initialize(//Content.Load<Texture2D>("wall"),
                        new Vector2(100 + i * 32, 16),
                        true, true);


                }

                else if (i > 15) //Inicializando as posições das paredes verticais
                {
                    wall[i - 1].Initialize(//Content.Load<Texture2D>("wall"),
                        new Vector2(132, 432 - ((i - 15) * 32)),
                        true, true);

                    wall[i + 27].Initialize(//Content.Load<Texture2D>("wall"),
                        new Vector2(580, 432 - ((i - 15) * 32)),
                        true, true);
                }
            }
                            
        }

        //Pelo que eu entendi, descarrega a memória
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Save the previous state of the keyboard and game pad so we can determine single key/button presses

            previousGamePadState = currentGamePadState;

            previousKeyboardState = currentKeyboardState;



            // Read the current state of the keyboard and gamepad and store it

            currentKeyboardState = Keyboard.GetState();

            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            UpdatePlayer(gameTime);
        }

        private void UpdatePlayer(GameTime gameTime)

        {
            //// Get Thumbstick Controls
            //player.Position.X += currentGamePadState.ThumbSticks.Left.X * playerMoveSpeed;
            //player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * playerMoveSpeed;

            // Use the Keyboard / Dpad
            if (currentKeyboardState.IsKeyDown(Keys.A) || currentGamePadState.DPad.Left == ButtonState.Pressed)
            {
                player.SetPlayerPositionX(player.GetPlayerPosition.X - playerMoveSpeed);
            }

            if (currentKeyboardState.IsKeyDown(Keys.D) || currentGamePadState.DPad.Right == ButtonState.Pressed)
            {
                player.SetPlayerPositionX(player.GetPlayerPosition.X + playerMoveSpeed);
            }

            if (currentKeyboardState.IsKeyDown(Keys.W) || currentGamePadState.DPad.Up == ButtonState.Pressed)
            {
                player.SetPlayerPositionY(player.GetPlayerPosition.Y - playerMoveSpeed);
            }

            if (currentKeyboardState.IsKeyDown(Keys.S) || currentGamePadState.DPad.Down == ButtonState.Pressed)
            {
                player.SetPlayerPositionY(player.GetPlayerPosition.Y + playerMoveSpeed);
            }

            // Make sure that the player does not go out of bounds
            //player.Position.X = MathHelper.Clamp(player.SetPlayerPositionX(player.GetPlayerPosition.X), 0, GraphicsDevice.Viewport.Width - player.Width);
            //player.Position.Y = MathHelper.Clamp(player.SetPlayerPositionX(player.GetPlayerPosition.Y), 0, GraphicsDevice.Viewport.Height - player.Height);
        }

        // Desenha o jogo
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // Start drawing
            spriteBatch.Begin();

            // Desenha o Player
            player.Draw(spriteBatch);

            // Desenha as paredes
            for (int i = 1; i < 57; i++)
            {
                wall[i-1].Draw(spriteBatch);
            }

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
