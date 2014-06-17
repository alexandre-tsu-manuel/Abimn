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

namespace Abimn.Game_States
{
    class Interact : GameType
    {
        private Entity fond_interact;
        private Color color_font;
        private Vector2 vect;
        private int _idtext;
        private string talk;
        private int conv, choice;
        private bool ask;


        public Interact(int n)
            : base(false)
        {
            conv = n;
        }

        public override void Initialize()
        {
            Cursor.SetVisibility(true);

            fond_interact = new Entity();
            fond_interact.Initialize(new Pos(fond_interact.Pos.X, fond_interact.Pos.Y + 470));
            fond_interact.LoadContent("interact", "boite_dialogue");


            talk = "";
            _idtext = 1;
            color_font = Color.White;
            vect.X = 30;
            vect.Y = 500;
            choice = 1;
            ask = false;
        }

        public string Dialogue(int conv)
        {
            switch (conv)
            {
                case 1: switch (_idtext)
                    {
                        case 1: return "Ou suis-je?";
                        case 2: return "Le noir... \n Impossible de me souvenir d'autre chose...";
                        case 3: return "Qui suis-je?";
                        case 4: return "Il ne me reste rien. Meme pas un nom...";
                        case 5: return "Mais... J'entends du bruit au loin... Il y a quelqu'un?";
                        default:
                            return "";

                    }
                case 2: switch (_idtext)
                    {
                        case 1: return "Bienvenue jeune ame. \nComment vous sentez vous?\n";
                        case 2: ask = true;
                            return " [W]-Comme si j'etait tombee du quatrieme etage... \n [X]-Bien. Merci. \n [C]-Qui etes-vous?";
                        case 3: return "Ne vous en faites pas. Je suis la pour vous aider. \nJ'aurai besoin de votre nom pour verifier votre dossier.";
                        case 4: 
                              ask = true;
                            return "[W]-Euh... \n[X]-Je ne sais pas... \n[C]-Francoise. \n[V]-J'ai demande avant!";
                        case 5: if (choice == 4)
                            { return "Je m'appelle Ferdinand. \nVoulez vous bien me dire votre nom a present?\nVous ne vous souvenez pas de votre nom? Voila qui est curieux... \nEt complique..."; }
                            else
                        { return "Vous ne vous souvenez pas de votre nom? Voila qui est curieux... \nEt complique...";}
                        case 6: return "...";
                        case 7: return "Cela ne m'arrange pas. Toutes les ames qui arrivent ici doivent etre \netiquetees pour pouvoir etre aiguillees...";
                        case 8: return "Je ne vois qu'une personne pour regler cette affaire. \nVous devriez aller voir Monsieur Longplancher, \nle responsable de l'orienation.";
                        case 9: return "Si vous voulez bien me laisser, d'autres arrivants ne devraient pas tarder.";
                    default:
                            return "";

                    }
                case 3: switch (_idtext)
                    {
                        case 1: return "Toujours la?";
                        case 2: return "Allons Allons. Vous ne devriez pas trainer. \nL'endroit est dangereux pour des gens comme vous";
                        default:
                            return "";

                    }
                default:
                    return "";
            }

        }

        public int Choice(int n)
        {
            if (ask == false)
            {
                if (E.IsPushed(Keys.Space))
                    _idtext++;
                return n;

            }
            else
            {

                if (E.IsPushed(Keys.W))
                {
                    _idtext++;
                    ask = false;
                    return 1;
                }

                else
                {
                    if (E.IsPushed(Keys.X))
                    {
                        _idtext++;
                        ask = false;
                        return 2;
                    }

                    else
                    {
                        if (E.IsPushed(Keys.C))
                        {
                            _idtext++;
                            ask = false;
                            return 3;
                        }

                        else
                        {
                            if (E.IsPushed(Keys.V))
                            {
                                _idtext++;
                                ask = false;
                                return 4;
                            }

                            else
                                return n;

                        }
                    }
                }

            }
        }


        public override void Update(GameTime gameTime)
        {
            choice = Choice(choice);
            talk = Dialogue(conv);

            if (E.IsPushed(Keys.Escape))
                this.State = State.Exit;

            if (talk == "")
                this.State = State.Exit;
        }





        public override void Draw()
        {
            fond_interact.Draw();
            Text.Write("vie", talk, vect, color_font);
        }
    }
}



