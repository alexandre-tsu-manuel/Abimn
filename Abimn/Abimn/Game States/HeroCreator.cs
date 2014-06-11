using Microsoft.Xna.Framework;

namespace Abimn
{
    /// <summary>
    /// Editeur de personnage
    /// </summary>
    public class HeroCreator : GameType
    {
		private Entity arrowL, arrowR, arrowL1, arrowR1;
        private Entity back, next, next2, back2, quit, play;
        private Entity role1, role2;
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
        public HeroCreator() : base(true) { }

        public override void Initialize()
        {
			/* le edit background devra etre en plein ecran*/
			EditBackground = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2));
            EditBackground.LoadContent("char edit", "background", Center.All);

			EditBackground2 = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2),false);
            EditBackground2.LoadContent("char edit", "21", Center.All);

			EditBackground3 = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2),false);
            EditBackground3.LoadContent("char edit", "22", Center.All);

            quit = new Entity(new Pos(C.Screen.Width - 245, C.Screen.Height - 95));
            quit.LoadContent("char edit", "9", "10", "9");

            next = new Entity(new Pos(C.Screen.Width - 455, C.Screen.Height - 95));
            next.LoadContent("char edit", "7", "8", "7");

			next2 = new Entity(new Pos(C.Screen.Width-455, C.Screen.Height-95 ),false);
            next2.LoadContent("char edit", "7", "8", "7");

			back = new Entity(new Pos(C.Screen.Width - 245, C.Screen.Height - 95),false);
            back.LoadContent("char edit", "11", "12", "11");
			
			back2 = new Entity(new Pos(C.Screen.Width - 245, C.Screen.Height - 95), false);
            back2.LoadContent("char edit", "11", "12", "11");

			play = new Entity(new Pos(C.Screen.Width - 455, C.Screen.Height - 95), false);
            play.LoadContent("char edit", "19", "20", "19");

			head1 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400),false);
            head1.LoadContent("char edit", "23");

			head2 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400),false);
            head2.LoadContent("char edit", "24");

			head3 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
            head3.LoadContent("char edit", "25");

			head4 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
            head4.LoadContent("char edit", "26");

			head5 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
            head5.LoadContent("char edit", "27");

			head6 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 400), false);
            head6.LoadContent("char edit", "28");

			body1 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
            body1.LoadContent("char edit", "29");
			
			body2 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
            body2.LoadContent("char edit", "30");
			
			body3 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
            body3.LoadContent("char edit", "31");
			
			body4 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
            body4.LoadContent("char edit", "32");
			
			body5 = new Entity(new Pos(C.Screen.Width - 750, C.Screen.Height - 390), false);
            body5.LoadContent("char edit", "33");

			arrowL1 = new Entity(new Pos(C.Screen.Width - 550, C.Screen.Height - 350), true);
            arrowL1.LoadContent("char edit", "6");
			
			arrowR1 = new Entity(new Pos(C.Screen.Width - 590, C.Screen.Height - 350), true);
            arrowR1.LoadContent("char edit", "5");

			arrowL =new Entity(new Pos(C.Screen.Width-550, C.Screen.Height -400),true);
            arrowL.LoadContent("char edit", "6");

			arrowR = new Entity(new Pos(C.Screen.Width - 590, C.Screen.Height - 400),true);
            arrowR.LoadContent("char edit", "5");

			role1 = new Entity(new Pos(C.Screen.Width - 550, C.Screen.Height - 400),false);
            role1.LoadContent("char edit", "13", "14", "14");

			role2 = new Entity(new Pos(C.Screen.Width - 550, C.Screen.Height - 300),false);
            role2.LoadContent("char edit", "15", "16", "16");
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
			//ecran de base
			if (arrowR.IsClicked())
			{
				i--;
				if (i < 2)
					i = 6;
			}
            else if (arrowL.IsClicked())
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

            if (arrowR1.IsClicked())
			{
				j--;
				if (j < 2)
					j = 6;
			}
            else if (arrowL1.IsClicked())
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

            if (quit.IsClicked()) //sortie de l'édition
                this.State = State.Exit;
            else if (next.IsClicked())
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
                if (role1.IsClicked())
					role2.Visible = false;
                else if (role2.IsClicked())
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
            else if (back.IsClicked() && EditBackground2.Visible) //gestion du retour
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
            else if (next2.IsClicked()) // troisieme ecran
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
            else if (back2.IsClicked() && EditBackground3.Visible) // retour sur 2nd ecran
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
            else if (play.IsClicked()) //lancement du jeu
				G.currentGame.Push(new Main());
        }

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
        }
    }
}
