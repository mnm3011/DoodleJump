using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

namespace Doodle_Jump.Texture
{
    /// <summary>
    /// Class inclusive methods Map Draw elements
    /// </summary>
    public static class MapDraw
    {
        /// <summary>
        /// Method draw Static Panel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="moveMap"></param>
        public static void StaticPanel(float _coordX, float _coordY, float moveMap)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(_coordX, _coordY - moveMap, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[2]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(64, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(64, 16);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 16);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Method draw Move Panel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="moveMap"></param>
        public static void MovePanel(float _coordX, float _coordY, float moveMap)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(_coordX, _coordY - moveMap, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[3]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(64, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(64, 16);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 16);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Method draw good Bad Panel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="moveMap"></param>
        public static void BadPanel1(float _coordX, float _coordY, float moveMap)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(_coordX, _coordY - moveMap, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[6]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(64, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(64, 16);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 16);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Method draw a broken Bad Panel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="moveMap"></param>
        public static void BadPanel2(float _coordX, float _coordY, float moveMap)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(_coordX, _coordY - moveMap, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[7]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(64, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(64, 34);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 34);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Method draw Background image
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public static void BackGround(int height)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(0.0f, 0.0f, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[8]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(570, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(570, height);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, height);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();

        }
        /// <summary>
        /// Method draw Monster
        /// </summary>
        /// <param name="k"></param>
        /// <param name="moveMap"></param>
        public static void Monster(Map.MonsterInMap kMonsterInMap, float moveMap)
        {
            if (kMonsterInMap != null)
            {
                Gl.glLoadIdentity();
                Gl.glTranslatef(kMonsterInMap.CoordX, kMonsterInMap.CoordY - moveMap, 0.0f);
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                if (kMonsterInMap.Type == 1)
                {
                    kMonsterInMap.PEvent++;
                    if (kMonsterInMap.PEvent > 50)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[16]);
                    }
                    else
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[9]);
                    }
                    if (kMonsterInMap.PEvent == 90)
                    {
                        kMonsterInMap.PEvent = 0;
                    }
                }
                if (kMonsterInMap.Type == 2)
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[14]);
                if (kMonsterInMap.Type == 3)
                {
                    if (kMonsterInMap.LeftFlag == true)
                    {
                        kMonsterInMap.PEvent++;
                        if (kMonsterInMap.PEvent < 101)
                        {
                            kMonsterInMap.CoordX++;
                        }
                        if (kMonsterInMap.PEvent % 5 == 0)
                        {
                            kMonsterInMap.CoordY -= 1.0f;
                        }
                        if (kMonsterInMap.PEvent == 100)
                        {
                            kMonsterInMap.LeftFlag = false;
                            kMonsterInMap.PEvent = 0;
                        }
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[18]);
                    }
                    if (kMonsterInMap.LeftFlag == false)
                    {
                        kMonsterInMap.PEvent++;
                        if (kMonsterInMap.PEvent < 101)
                        {
                            kMonsterInMap.CoordX--;
                        }
                        if (kMonsterInMap.PEvent % 5 == 0)
                        {
                            kMonsterInMap.CoordY += 1.0f;
                        }
                        if (kMonsterInMap.PEvent == 100)
                        {
                            kMonsterInMap.LeftFlag = true;
                            kMonsterInMap.PEvent = 0;

                        }
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[17]);
                    }
                }
                if (kMonsterInMap.Type == 4)
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[22]);
                }

                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex2i(0, 0);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex2i(kMonsterInMap.Width, 0);
                Gl.glTexCoord2f(1.0f, 1.0f);
                Gl.glVertex2i(kMonsterInMap.Width, kMonsterInMap.Height);
                Gl.glTexCoord2f(0.0f, 1.0f);
                Gl.glVertex2i(0, kMonsterInMap.Height);
                Gl.glEnd();
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                Gl.glLoadIdentity();
            }
        }


        /// <summary>
        /// Method draw bonus
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="type"></param>
        /// <param name="moveMap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Bonus(float _coordX, float _coordY, uint type, float moveMap, int width, int height)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(_coordX, _coordY - moveMap, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            if ((type == 0) || (type == 1))
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[12]);
            if ((type == 2) || (type == 3))
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[15]);
            if ((type == 4))
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[19]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(width, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(width, height);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, height);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();

        }
        /// <summary>
        /// Method draw used Bonus 1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="moveMap"></param>
        public static void Bonus1j(float _coordX, float _coordY, float moveMap)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(_coordX, _coordY - moveMap, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[13]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(18, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(18, 28);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 28);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();
        }
        /// <summary>
        /// Method draw used Bonus 2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="moveMap"></param>
        public static void Bonus2j(float _coordX, float _coordY, float moveMap)
        {
            Gl.glLoadIdentity();
            Gl.glTranslatef(_coordX, _coordY - moveMap, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[21]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(54, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(54, 26);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 26);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();
        }

    }

}
