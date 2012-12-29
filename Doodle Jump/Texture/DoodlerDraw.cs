using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

namespace Doodle_Jump.Texture
{
    public static class DoodlerDraw
    {
        public static void Shot(float _coordX, float _coordY)
        {
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[11]);
            Gl.glTranslatef(_coordX, _coordY, 0.0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2d(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2d(1.0f, 0.0f);
            Gl.glVertex2i(15, 0);
            Gl.glTexCoord2d(1.0f, 1.0f);
            Gl.glVertex2i(15, 15);
            Gl.glTexCoord2d(0.0f, 1.0f);
            Gl.glVertex2i(0, 15);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();
        }
        public static void DoodlerRedraw(Doodler.Doodler doodle)
        {
            if (doodle != null)
            {
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glTranslatef(doodle.DoodlerX, doodle.DoodlerY, 0.0f);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex2f(0.0f, 0.0f);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex2f(doodle.DoodlerWidth, 0.0f);
                Gl.glTexCoord2f(1.0f, 1.0f);
                Gl.glVertex2f(doodle.DoodlerWidth, doodle.DoodlerWidth);
                Gl.glTexCoord2f(0.0f, 1.0f);
                Gl.glVertex2f(0.0f, doodle.DoodlerWidth);

                Gl.glEnd();
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                Gl.glLoadIdentity();

            }
        }
        public static void DoodlerInDurka(Doodler.Doodler doodle, Map.MonsterInMap durkaXY)
        {
            if ((doodle != null) && (durkaXY != null))
            {
                if ((doodle.DoodlerX >= durkaXY.CoordX) && (doodle.DoodlerX <= ((durkaXY.CoordX + durkaXY.Width) / 2.0f)))
                {
                    doodle.DoodlerX++;
                    doodle.DoodlerY++;

                }

                else
                {
                    doodle.DoodlerX--;
                    doodle.DoodlerY++;
                    doodle.DoodlerWidth--;
                }

                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glTranslatef(doodle.DoodlerX, doodle.DoodlerY, 0.0f);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex2f(0.0f, 0.0f);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex2f(doodle.DoodlerWidth, 0.0f);
                Gl.glTexCoord2f(1.0f, 1.0f);
                Gl.glVertex2f(doodle.DoodlerWidth, doodle.DoodlerWidth);
                Gl.glTexCoord2f(0.0f, 1.0f);
                Gl.glVertex2f(0.0f, doodle.DoodlerWidth);

                Gl.glEnd();
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                Gl.glLoadIdentity();

            }
        }
    }
}
