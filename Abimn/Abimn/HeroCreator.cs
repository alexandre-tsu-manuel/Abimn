using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Abimn
{
    /// <summary>
    /// Combat instancié
    /// </summary>
    public class HeroCreator : GameType
    {
		private Button arrowL, arrowR, arrowL1, arrowR1;
		private Button back, next, next2, back2, quit, play;
		private Button role1,role2;
		private Entity EditBackground, EditBackground2, EditBackground3;
		private Entity head1, head2, head3, head4, head5, head6;
		private Entity body1, body2, body3, body4, body5;
		private int i, j;
		
 
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public HeroCreator() : base(true)
        {
			/* le edit background devra etre en plein ecran*/
			EditBackground = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2));
			EditBackground.LoadContent(1, Tiles.CharEdit, Center.All);

			EditBackground2 = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2),false);
			EditBackground2.LoadContent(21, Tiles.CharEdit, Center.All);

			EditBackground3 = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2),false);
			EditBackground3.LoadContent(22, Tiles.CharEdit, Center.All);
			
			quit = new Button(new Pos(C.Screen.Width-245, C.Screen.Height - 95));
			quit.LoadContent(9, 10, 9, Tiles.CharEdit);

			next = new Button(new Pos(C.Screen.Width-455, C.Screen.Height-95 ));
			next.LoadContent(7, 8, 7, Tiles.CharEdit);

			next2 = new Button(new Pos(C.Screen.Width-455, C.Screen.Height-95 ),false);
			next2.LoadContent(7, 8, 7, Tiles.CharEdit);

			back = new Button(new Pos(C.Screen.Width - 245, C.Screen.Height - 95),false);
			back.LoadContent(11, 12, 11, Tiles.CharEdit);
			
			back2 = new Button(new Pos(C.Screen.Width - 245, C.Screen.Height - 95), false);
			back2.LoadContent(11, 12, 11, Tiles.CharEdit);

			play = new Button(new Pos(C.Screen.Width - 455, C.Screen.Height - 95), false);
			play.LoadContent(19, 20, 19, Tiles.CharEdit);

			head1 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400),false);
			head1.LoadContent(23,Tiles.CharEdit);

			head2 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400),false);
			head2.LoadContent(24, Tiles.CharEdit);

			head3 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
			head3.LoadContent(25,Tiles.CharEdit);

			head4 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
			head4.LoadContent(26, Tiles.CharEdit);

			head5 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
			head5.LoadContent(27, Tiles.CharEdit);

			head6 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
			head6.LoadContent(28,Tiles.CharEdit);

			body1 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
			body1.LoadContent(29, Tiles.CharEdit);
			
			body2 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
			body2.LoadContent(30, Tiles.CharEdit);
			
			body3 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
			body3.LoadContent(31, Tiles.CharEdit);
			
			body4 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
			body4.LoadContent(32, Tiles.CharEdit);
			
			body5 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
			body5.LoadContent(33, Tiles.CharEdit);

			arrowL1 = new Button(new Pos(C.Screen.Width - 550, C.Screen.Height - 350), true);
			arrowL1.LoadContent(6, 6, 6, Tiles.CharEdit);
			
			arrowR1 = new Button(new Pos(C.Screen.Width - 590, C.Screen.Height - 350), true);
			arrowR1.LoadContent(5, 5, 5, Tiles.CharEdit);

			arrowL =new Button(new Pos(C.Screen.Width-550, C.Screen.Height -400),true);
			arrowL.LoadContent(6,6,6, Tiles.CharEdit);

			arrowR = new Button(new Pos(C.Screen.Width - 590, C.Screen.Height - 400),true);
			arrowR.LoadContent(5, 5, 5, Tiles.CharEdit);

			role1 = new Button(new Pos(C.Screen.Width - 550, C.Screen.Height - 400),false);
			role1.LoadContent(13,14,14, Tiles.CharEdit);
				role2 = new Button(new Pos(C.Screen.Width - 550, C.Screen.Height - 300),false);
				role2.LoadContent(15, 16, 16, Tiles.CharEdit);
		
		
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
			//ecran de base
			if (arrowR.mouseOver() && E.LeftIsReleased())
				{
					i--;
					if (i < 2 )
						i = 6;
				}
				else if (arrowL.mouseOver() && E.LeftIsReleased())
					{
						i++;
						if (i > 6)
							i = 1;
					}
			if (i == 1) //supprimer l'image qui suit et celle qui la precede pour eviter la surcharge d'image sur l'ecran
			{
				head6.Visible = false;
				head1.Visible = true;
				head2.Visible = false;
			}
			else if (i == 2)
			{
				head1.Visible = false;
				head2.Visible = true;
				head3.Visible = false;
			}
			else if (i == 3)
			{
				head2.Visible = false;
				head3.Visible = true;
				head4.Visible = false;
			}
			else if (i == 4)
			{
				head3.Visible = false;
				head4.Visible = true;
				head5.Visible = false;
			}
			else if (i == 5)
			{
				head4.Visible = false;
				head5.Visible = true;
				head6.Visible = false;
			}
			else if (i == 6)
			{
				head5.Visible = false;
				head6.Visible = true;
				head1.Visible = false;
			}


				if (arrowR1.mouseOver() && E.LeftIsReleased())
				{
					j--;
					if (j < 2)
						j = 6;
				}
				else if (arrowL1.mouseOver() && E.LeftIsReleased())
				{
					j++;
					if (j > 6)
						j = 1;
				}
				
			
				if (j == 1)
				{
					body5.Visible = false;
					body1.Visible = true;
					body2.Visible = false;
				}
				else if (j == 2)
				{
					body1.Visible = false;
					body2.Visible = true;
					body3.Visible = false;
				}
				else if (j == 3)
				{
					body2.Visible = false;
					body3.Visible = true;
					body4.Visible = false;
				}
				else if (j == 4)
				{
					body3.Visible = false;
					body4.Visible = true;
					body5.Visible = false;
				}
				else if (j == 5)
				{
					body4.Visible = false;
					body5.Visible = true;
					//body1.Visible = false;
				}
				
			
					
			
			 
			if (quit.mouseOver() && E.LeftIsReleased()) //sortie de l'eddition
				G.currentGame.Pop();

			else if (next.mouseOver() && E.LeftIsReleased()) //ecran 2 
			{
				EditBackground2.Visible = true;
				
				next.Visible = false;
				next2.Visible = true;
				back.Visible = true;
				quit.Visible = false;
				role1.Visible = true;
				role2.Visible = true;
				arrowL.Visible = false;
				arrowR.Visible = false;
				arrowL1.Visible = false;
				arrowR1.Visible = false;
				if (role1.mouseOver() && E.RightIsReleased())
					role2.Visible = false;
				else if (role2.mouseOver() && E.RightIsReleased())
					role1.Visible = false;
				/*body1.Visible = false;
				body2.Visible = false;
				body3.Visible = false;
				body4.Visible = false;
				body5.Visible = false;
				head1.Visible = false;
				head2.Visible = false;
				head3.Visible = false;
				head4.Visible = false;
				head5.Visible = false;
				head6.Visible = false;*/ //ne fait rien images toujours visibles
			}
			else if (back.mouseOver() && E.LeftIsReleased()) //gestion du retour
			{
				if (EditBackground2.Visible == true)
				{
					EditBackground2.Visible = false;
					EditBackground.Visible = true;
					arrowL.Visible = true;
					arrowL1.Visible = true;
					arrowR.Visible = true;
					arrowR1.Visible = true;
					role1.Visible = false;
					role2.Visible = false;
					back.Visible = false;
					quit.Visible = true;
					next2.Visible = false;
					next.Visible = true;
					
				}
				
			
			}
			else if (next2.mouseOver() && E.LeftIsReleased()) // troisieme ecran
			{
				EditBackground3.Visible = true;
				back.Visible = false;
				back2.Visible = true;
				next2.Visible = false;
				next.Visible = false;
				role1.Visible = false;
				role2.Visible = false;
				play.Visible = true;
				
			}
			else if (back2.mouseOver() && E.LeftIsReleased()) // retour sur 2nd ecran
			{
				if (EditBackground3.Visible == true)
				{
					EditBackground3.Visible = false;
					EditBackground2.Visible = true;
					back2.Visible = false;
					back.Visible = true;
					next2.Visible = true;
					play.Visible = false;
					role1.Visible = true;
					role2.Visible = true;

				}
			}
			else if (play.mouseOver() && E.LeftIsReleased()) //lance;ent du jeu
					G.currentGame.Push(new Main()); 

			
		
			
			
					
			
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
			EditBackground.Draw(); 
			EditBackground2.Draw();
			EditBackground3.Draw();
			quit.Draw();
			next.Draw();
			back.Draw();
			back2.Draw();
			next2.Draw();
			play.Draw();
			head1.Draw();
			head2.Draw();
			head3.Draw();
			head4.Draw();
			head5.Draw();
			head6.Draw();
			body1.Draw();
			body2.Draw();
			body3.Draw();
			body4.Draw();
			body5.Draw();
			arrowL.Draw();
			arrowR.Draw();
			arrowL1.Draw();
			arrowR1.Draw();
			role1.Draw();
			role2.Draw();

            // TODO: Add your drawing code here
        }
    }
}
