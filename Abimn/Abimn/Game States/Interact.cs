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
        private int conv, choice, random;
        private bool ask;



        public Interact(int n)
            : base(false)
        {
            conv = n;
        }

        public override void Initialize()
        {

            fond_interact = new Entity();
            fond_interact.Initialize(new Pos(fond_interact.Pos.X, fond_interact.Pos.Y + 470));
            fond_interact.LoadContent("interact", "boite_dialogue");


            talk = "";
            _idtext = 1;
            color_font = Color.White;
            vect.X = 30;
            vect.Y = 500;
            choice = 1;
            random = 0;
            ask = false;
        }

        public string Dialogue(int conv)
        {
            switch (conv)
            {
                case 1: switch (_idtext)
                    {
                        case 1: return "Ou suis-je?";
                        case 3: return "il fait sombre... \nFroid... \nPourquoi suis-je ici?";
                        case 4: return "Meme mon propre nom...";
                        case 2: return "Je ne connais pas cette caverne... \nOn dirait une ruine... ou un tombeau? ";
                        case 5: return "... Que!";
                        case 6: return "J'entends du bruit au loin... \nPeut-etre que quelqu'un aura des reponses";
                        default:
                            return "";

                    }
                case 2: switch (_idtext)
                    {
                        case 1: return "Bien le bonjour. \nComment vous sentez vous?\n";
                        case 2: ask = true;
                            return " [W]-Comme si j'etais tombee du quatrieme etage... \n [X]-Bien. Merci. \n [C]-Un renard... qui parle... \n [V]-Qui etes-vous? ";
                        case 3: return "Ne vous en faites pas. Je suis la pour vous aider. \nVous avez l'air un eu deboussolee mon amie. \nNe vous en faites pas. Tout va bien se passer. \n Quel est votre nom?";
                        case 4:
                            ask = true;
                            if (choice == 4)
                                return "[W]-Euh... \n[X]-Je ne sais pas... \n[C]-Francoise. \n[V]-J'ai demande avant!";
                            else
                                return "[W]-Euh... \n[X]-Cela ne vous regarde pas. \n[C]-Marie-France de la Marne.";
                        case 5: if (choice == 4)
                            { return "Je m'appelle Mesmer, prince des Abysses. \nVoulez vous bien me dire votre nom a present?\n...\nVous ne vous souvenez pas de votre nom, n'est-ce pas?\n Voila qui est curieux... \nEt complique..."; }
                            else
                            { return "Mmmh... Curieux pour un esprit aussi rayonnant... \nVous ne vous souvenez pas de votre nom n'est-ce pas?"; }
                        case 6: return "...";
                        case 7: return "Et bien je suis navre mais je ne sais pas trop comment vous aider sans \nmeme pouvoir jeter un oeil a votre dossier... \nJe dois rester ici pour accueillir les arrivants qui ont deja \nleurs papiers, voyez-vous...";
                        case 8: ask = true;
                            return "[W]-C'est tout ce que ca vous fait?! \n[X]-Mais que m'est-il arrive? Je ne sais meme pas ce que je fais ici...\n    ni quel est cet endroit.";
                        case 9: return "Calmez-vou. Cela ne sert a rien de s'enerver.";
                        case 10: return " Vous allez surement trouver cela etrange mais... vous etes morte. \nLaissez moi etre le premier a vous souhaiter la bienvenu dans l'Abimn.";
                        case 11: return "Certains habitants de votre monde appelle le \nnotre 'Limbes' ou 'Purgatoire' \nMais vous vous rendrez vites compte que ces noms sont \nbien eloignes de la verite.";
                        case 12: return "Il peut vous paraitre un peu etrange mais vous ne devriez \npas y rester trop longtemps. \nLes ames ne font qu'y passer en general. \n Des que votre probleme d'identite sera regle, vous serez jugee et \npartirez pour votre Repos Eternel: \nle Paradis ou l'Enfer";
                        case 14: return "Voulez-vous que je vous donne quelques conseils?\n Pour survivre jusqu'a votre depart?";
                        case 15: ask = true;
                            return "[w]-Oui, s'il vous plait.\n[X]-Non, merci. Je saurai me debrouiller seule.";
                        case 16: if (choice == 2)
                            {
                                _idtext = 19; 
                            return "Tres bien."; }
                            else
                            { return "Il semble que vous ayez deja compris comment vous deplacer dans \nvotre nouvel environnement...\nSachez que vous pouvez appuyer sur [B] pour courrir.\nCela pourrait etre utile pour sauver votre vie..."; }
                        case 17: return "Lorsque vous passer a proximiter de formes de vies intelligentes, \nvous pouvez essayer de leur parler en appuyant sur [Espace].\nLors des Dialogues, les quatre touches de reponses sont [W] [X] [C] et [V].";
                        case 13: return "L'Abimn est un monde plein de danger pour une ame \nsans pouvoir ni souvenir comme vous.\n C'est aussi pour cela qu'elles ne restent pas... Hmmm...";
                        case 18: return "Faites attention.\nA l'exterieur, des creatures rodes.\nEt je vous prie de me croire sur parole quand je vous dis que \nl'energie d'une ame perdue est leur plat favori.";
                    case 19: return "Tres bien.\nPour retrouver vos souvenirs, vous devirez aller directement\n demander a l'O.O.O, Organisme d'Orientation d'Outre-tombre. \nLe responsable, Monsieur Longplancher, devrait pouvoir retrouver votre passe.";
                    case 20: return "Prenez ce couteau. Il vous evitera d'avoir des problemes en chemin.";
                    case 21: return "\n \n~~~~ Arme: Couteau Spirit ~~~~";
                    case 22: return "A present partez. Les prochains arrivants ne devraient pas tarder\net je ne peux pas prendre de retard dans mon travail. \nAller a l'Est, vous trouverez l'administration sans probleme.";
                    case 23: return "Bon courrage, mon amie.";

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

                case 4: switch (_idtext)
                    {
                        case 1: return "Une humaine... fraiche...";
                        case 2: return "J'en veux une...";
                        default:
                            return "";

                    }
                case 5: switch (_idtext)
                    {
                        case 1: return "Pas rester la...\nDangereux...";
                        default:
                            return "";
                    }

                case 10 : switch (_idtext)
                    {
                        case 1: return "Alors tu te preSSentes a moi, ChaSSSeur?";
                        case 2: return "Rentre chez toi. \nTu es trop faible. \nT'aFFronter ne ferais meme pas un bon divertiSSment.";
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



