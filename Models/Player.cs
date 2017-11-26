using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Portal2D.Models
{

    class Player
    {
        // Parâmetros
        //Posição do player iniciada no canto superior esquerdo da tela
        private Vector2 playerPosition;
        // Sprite do player
        private Texture2D playerTexture; 


        // Getters and Setters

        // Altera a posição do player
        public void SetPlayerPosition(Vector2 playerPosition)
        {
            this.playerPosition = playerPosition;
        }

        // Altera posição X do player
        public void SetPlayerPositionX(float playerPositionX)
        {
            playerPosition.X = playerPositionX;
        }
        // Altera posição Y do player
        public void SetPlayerPositionY(float playerPositionY)
        {
            playerPosition.Y = playerPositionY;
        }

        // Altera a sprite do player
        public void SetPlayerTexture(Texture2D playerTexture)
        {
            this.playerTexture = playerTexture;
        }

        // Retorna a posição do player
        public Vector2 GetPlayerPosition => playerPosition;
        // Retorna a largura da sprite do player
        public int GetPlayerWidth => playerTexture.Width;
        // Retorna a sprite do player
        public Texture2D GetPlayerTexture => playerTexture;
        // Retorna a altura da sprite do player
        public int GetPlayerHeight => playerTexture.Height;

        public Player(Texture2D playerTexture)
        {
            SetPlayerTexture(playerTexture);
            SetPlayerPosition(Vector2.Zero);
        }


        public void Initialize(Texture2D playerTexture, Vector2 playerPosition)

        {
            
            SetPlayerTexture(playerTexture);
            SetPlayerPosition(playerPosition);
        }



        public void Update()
        {

        }



        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 0f, Vector2.Zero, 1f,
               SpriteEffects.None, 0f);
        }

    }

}