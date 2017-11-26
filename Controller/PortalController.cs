using System;
using Microsoft.Xna.Framework;
using Portal2D.Models;


namespace Portal2D.Controller
{
    class PortalController
    {
        public void CollisionWithPlayer(Player player, Portal entryPortal, Portal exitPortal)

        {
            Rectangle rectangle1, rectangle2, rectangle3;

            rectangle1 = new Rectangle((int)player.GetPlayerPosition.X,
                (int)player.GetPlayerPosition.Y,
                player.GetPlayerWidth,
                player.GetPlayerHeight);


            rectangle2 = new Rectangle((int)entryPortal.GetPortalPosition.X,
                (int)entryPortal.GetPortalPosition.Y,
                entryPortal.GetPortalWidth,
                entryPortal.GetPortalHeight);

            rectangle3 = new Rectangle((int)exitPortal.GetPortalPosition.X,
                (int)exitPortal.GetPortalPosition.Y,
                exitPortal.GetPortalWidth,
                exitPortal.GetPortalHeight);

            // Se estiver colidindo com o portal de entrada
            if (rectangle1.Intersects(rectangle2) /*&& entryPortal.GetPortalMoved == true*/)
            {
                player.SetPlayerPosition(exitPortal.GetPortalPosition /* + new Vector2(
                                         player.GetPlayerXspeed, player.GetPlayerYspeed)*/);

            }

            // Se estiver colidindo com o portal de saida
            if (rectangle1.Intersects(rectangle3) /*&& exitPortal.GetPortalMoved == true*/)
            {
                player.SetPlayerPosition(entryPortal.GetPortalPosition /* + new Vector2(
                                         player.GetPlayerXspeed, player.GetPlayerYspeed)*/);

            } //Nessa parte da some de vetores talvez seja melhor somar o resultado da mutiplicação
              //entre o sinal da velocidade do player com o tamanho da largura, acho que vai evitar bug

        }

        private Boolean CollisionWithWall(Portal portal, Wall[] wall)

        {
            Rectangle rectangle1, rectangle2;

            rectangle1 = new Rectangle((int)portal.GetPortalPosition.X,
                (int)portal.GetPortalPosition.Y,
                portal.GetPortalWidth,
                portal.GetPortalHeight);


            for (int i = 0; i < wall.Length; i++)

            {
                rectangle2 = new Rectangle((int)wall[i].GetWallPosition.X,
                    (int)wall[i].GetWallPosition.Y,
                    wall[i].GetWallWidth,
                    wall[i].GetWallHeight);


                if (rectangle1.Intersects(rectangle2))
                {
                    return true;

                }

            }
            return false;
        }


    }
}

