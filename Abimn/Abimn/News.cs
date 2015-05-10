using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    public static class News
    {
        private static XmlDocument doc;
        private static XmlDeclaration declaration;
        private static bool docLoaded;
        public static bool LoadFinished = false;

        public static void Load()
        {
            doc = new XmlDocument();
            try
            {
                int foo = 0;
                int bar = foo / foo;
                doc.Load("http://localhost/Abimn/news.xml");
            }
            catch
            {
                docLoaded = false;
                LoadFinished = true;
                return;
            }
            declaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            docLoaded = true;
            LoadFinished = true;
        }

        public static void Draw(Pos pos)
        {
            if (docLoaded)
            {
                foreach (XmlNode e in doc.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode i in e.ChildNodes)
                    {
                        switch (i.Name)
                        {
                            case "title":
                                Text.Write("vie", i.InnerText, pos.ToVector2(), Color.Yellow, 1.4f);
                                pos.J += 35;
                                break;
                            case "date":
                                Text.Write("vie", i.InnerText, pos.ToVector2(), Color.Silver, 0.8f);
                                pos.J += 25;
                                break;
                            case "content":
                                Text.Write("vie", i.InnerText, pos.ToVector2(), Color.White, 0.9f);
                                pos.J += 100;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else
                Text.Write("vie", "Pas de connexion", pos.ToVector2(), Color.Gray);
        }
    }
}
