using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;


namespace Doodle_Jump.Menu
{
    public class ObjectMenu
    {
        private float x;
        private float y;
        private bool active;
        private uint textureS;
        private uint textureActive;
        private float width = 104.0f;
        private float height = 32.0f;
        private uint type;
        private uint id;

        public ObjectMenu(float _coordX, float _coordY, bool _active, uint _textureS, uint _textureActive, uint _type, uint _id)
        {
            x = _coordX;
            y = _coordY;
            active = _active;
            textureS = _textureS;
            textureActive = _textureActive;
            type = _type;
            id = _id;

            if ((_type == 1) || (_type == 7))
            {
                width = 38.0f;
                height = 24.0f;
            }
        }

        public static List<ObjectMenu> ListObjectMenu()
        {
            List<ObjectMenu> listObj = new List<ObjectMenu>();
            //main menu
            listObj.Add(new ObjectMenu(150, 400, false, 24, 25, 0, 0));
            listObj.Add(new ObjectMenu(200, 350, false, 30, 31, 0, 1));
            listObj.Add(new ObjectMenu(250, 300, false, 26, 27, 0, 2));
            //top10
            listObj.Add(new ObjectMenu(220, 150, false, 33, 34, 3, 3));
            //game over
            listObj.Add(new ObjectMenu(310, 350, false, 28, 29, 4, 4));
            listObj.Add(new ObjectMenu(310, 250, false, 26, 27, 4, 5));
            listObj.Add(new ObjectMenu(310, 300, false, 33, 34, 4, 6));
            //enter name
            listObj.Add(new ObjectMenu(220, 230, false, 33, 34, 5, 7));
            listObj.Add(new ObjectMenu(220, 270, false, 36, 37, 5, 8));
            //
            listObj.Add(new ObjectMenu(230, 150, false, 36, 37, 6, 9));

            listObj.Add(new ObjectMenu(30, MainForm.Height1 - 30, false, 41, 42, 1, 10));
            listObj.Add(new ObjectMenu(30, MainForm.Height1 - 30, false, 43, 44, 7, 11));

            return listObj;
        }
        public static void RenderGlobalMenu()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[23]);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);

            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(MainForm.Width1, 0);

            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(MainForm.Width1, MainForm.Height1);

            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, MainForm.Height1);
            Gl.glEnd();

            RenderObjectOnMenu(MainForm.Objects_menu, 0);

            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_BLEND);

            Gl.glLoadIdentity();
        }

        public static void RenderObjectOnMenu(List<ObjectMenu> obj, uint type)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            foreach (ObjectMenu k in obj)
            {
                if (k.type == type)
                {
                    if (k.active == false)
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[k.textureS]);
                    if (k.active == true)
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[k.textureActive]);

                    Gl.glBegin(Gl.GL_QUADS);

                    Gl.glTexCoord2f(0.0f, 0.0f);
                    Gl.glVertex2f(k.x, k.y);

                    Gl.glTexCoord2f(1.0f, 0.0f);
                    Gl.glVertex2f(k.x + k.width, k.y);

                    Gl.glTexCoord2f(1.0f, 1.0f);
                    Gl.glVertex2f(k.x + k.width, k.y + k.height);

                    Gl.glTexCoord2f(0.0f, 1.0f);
                    Gl.glVertex2f(k.x, k.y + k.height);
                    Gl.glEnd();
                }
            }


        }

        public static void RenderTop10(List<ObjectMenu> obj)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[23]);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);

            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(MainForm.Width1, 0);

            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(MainForm.Width1, MainForm.Height1);

            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, MainForm.Height1);
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[32]);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(170, 170);

            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(170 + 200, 170);

            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(170 + 200, 170 + 273);

            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(170, 170 + 273);
            Gl.glEnd();

            if (obj != null)
            {

                foreach (ObjectMenu k in obj)
                {
                    if (k.type == 3)
                    {
                        if (k.active == false)
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[k.textureS]);
                        if (k.active == true)
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[k.textureActive]);
                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(0.0f, 0.0f);
                        Gl.glVertex2f(k.x, k.y);

                        Gl.glTexCoord2f(1.0f, 0.0f);
                        Gl.glVertex2f(k.x + k.width, k.y);

                        Gl.glTexCoord2f(1.0f, 1.0f);
                        Gl.glVertex2f(k.x + k.width, k.y + k.height);

                        Gl.glTexCoord2f(0.0f, 1.0f);
                        Gl.glVertex2f(k.x, k.y + k.height);
                        Gl.glEnd();
                    }
                }
            }
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_BLEND);

            Gl.glLoadIdentity();
            Gl.glFlush();


        }

        public static void RenderEnterName(List<ObjectMenu> obj)
        {
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[23]);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);

            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(MainForm.Width1, 0);

            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(MainForm.Width1, MainForm.Height1);

            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, MainForm.Height1);
            Gl.glEnd();


            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[38]);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(177, 240);

            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(177 + 200, 240);

            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(177 + 200, 240 + 183);

            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(177, 240 + 183);
            Gl.glEnd();
            if (obj != null)
            {
                foreach (ObjectMenu k in obj)
                {
                    if (k.type == 5)
                    {
                        if (k.active == false)
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[k.textureS]);
                        if (k.active == true)
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[k.textureActive]);
                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(0.0f, 0.0f);
                        Gl.glVertex2f(k.x, k.y);

                        Gl.glTexCoord2f(1.0f, 0.0f);
                        Gl.glVertex2f(k.x + k.width, k.y);

                        Gl.glTexCoord2f(1.0f, 1.0f);
                        Gl.glVertex2f(k.x + k.width, k.y + k.height);

                        Gl.glTexCoord2f(0.0f, 1.0f);
                        Gl.glVertex2f(k.x, k.y + k.height);
                        Gl.glEnd();
                    }
                }

            }

            Gl.glDisable(Gl.GL_TEXTURE_2D);

            // Texture.Texture.PrintText2DPoint(100.0f, 100.0f, MainForm.DoodlerName);

            Gl.glDisable(Gl.GL_BLEND);

            Gl.glLoadIdentity();
            Gl.glFlush();

        }



        public float CoordX
        {
            get { return x; }
        }
        public float CoordY
        {
            get { return y; }
            set { y = value; }
        }
        public float Width
        {
            get { return width; }
            set { width = value; }
        }
        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        public bool Active
        {
            set { active = value; }
            get { return active; }
        }
        public uint TextureS
        {
            get { return textureS; }
        }
        public uint Type
        {
            get { return type; }
        }

        public uint Id
        {
            get { return id; }
        }
    }
    
}
