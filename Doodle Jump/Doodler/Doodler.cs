using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;


namespace Doodle_Jump.Doodler
{
    public class Doodler
    {
        private float doodlerY = 48.0f; //
        private float doodlerX = 48.0f;
        private float doodlerWidth = 56.0f;
        private float doodlerHeight = 56.0f;

        private float doodleXGameOver = 100.0f; //using to Game Over menu
        private float doodleYGameOver = 450.0f; //Doodler fly to bottom

        private bool keyRightOrLeft = false;   //see Doodler to Right or Left
        private float accelX = 0.0f;    //Accel to X
        private bool jumpFlag = false;  //If true Doodler on Top, or Botton

        private float accelY = 5.0f;    //Accel to Y
        private float gravity = 0.0f;   //Gravity
        private float i = 0.0f;         //Current jump Y

        public float JUMP_H = 190.0f;  //Height Jump

        private bool pownedFlag = false;        //Powned Doodler
        private uint timerPowned = 0;           //timer atack

        private bool godlike = false;           //good


        public static float jumpOnBatut = 0.0f; //

        public bool gyroFlag = false;           //Doodler used gyrocopted

        public Doodle_Jump.Map.PanelInMap zPanelBuf = null; //buf 

        public void DoodlerPowned()
        {

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[10]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2f(doodlerX, doodlerY);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2f(doodlerX + doodlerWidth - 20, doodlerY);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2f(doodlerX + doodlerWidth - 20, doodlerY + doodlerHeight);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2f(doodlerX, doodlerY + doodlerHeight);

            Gl.glEnd();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
        }

        public void DoodlerGyro()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[20]);
            if (keyRightOrLeft == false)
            {
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex2f(doodlerX - 4, doodlerY + doodlerWidth - 13);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex2f(doodlerX + 45, doodlerY + doodlerWidth - 13);
                Gl.glTexCoord2f(1.0f, 1.0f);
                Gl.glVertex2f(doodlerX + 45, doodlerY + doodlerHeight + 22);
                Gl.glTexCoord2f(0.0f, 1.0f);
                Gl.glVertex2f(doodlerX - 4, doodlerY + doodlerHeight + 22);

                Gl.glEnd();
            }
            if (keyRightOrLeft == true)
            {
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex2f(doodlerX + 15, doodlerY + doodlerWidth - 13);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex2f(doodlerX + 64, doodlerY + doodlerWidth - 13);
                Gl.glTexCoord2f(1.0f, 1.0f);
                Gl.glVertex2f(doodlerX + 64, doodlerY + doodlerHeight + 22);
                Gl.glTexCoord2f(0.0f, 1.0f);
                Gl.glVertex2f(doodlerX + 15, doodlerY + doodlerHeight + 22);

                Gl.glEnd();
            }
            Gl.glEnable(Gl.GL_TEXTURE_2D);
        }


        public void Infinity()
        {
            bool aBuf = false;
            if (((doodlerX + doodlerWidth) > 570) && (aBuf == false))
            {
                doodlerX = 0;
                aBuf = true;
            }
            if (((doodlerX) < -30) && (aBuf == false))
            {
                doodlerX = 500;
                aBuf = true;
            }

        }

        public void GameOver(Doodler doodle, Map.Map map, List<Doodle_Jump.Menu.ObjectMenu> objects_menu)
        {
            if ((doodle != null) && (map != null) && (objects_menu != null))
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glLoadIdentity();

                Gl.glEnable(Gl.GL_BLEND);

                Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

                Gl.glColor4ub(215, 173, 103, 120);
                Gl.glEnable(Gl.GL_TEXTURE_2D);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[35]);

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



                Gl.glLoadIdentity();
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[1]);

                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex2f(doodle.doodleXGameOver, doodle.doodleYGameOver);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex2f(doodle.doodleXGameOver + 56.0f, doodle.doodleYGameOver);
                Gl.glTexCoord2f(1.0f, 1.0f);
                Gl.glVertex2f(doodle.doodleXGameOver + 56.0f, doodle.doodleYGameOver + 56.0f);
                Gl.glTexCoord2f(0.0f, 1.0f);
                Gl.glVertex2f(doodle.doodleXGameOver, doodle.doodleYGameOver + 56.0f);


                Gl.glEnd();
                this.doodleYGameOver -= 5.0f;
                Gl.glColor4ub(215, 173, 103, 120);

                Gl.glDisable(Gl.GL_TEXTURE_2D);
                Gl.glLoadIdentity();
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex2f(MainForm.MenuXGameOver, 100.0f);
                Gl.glVertex2f(MainForm.MenuXGameOver + MainForm.MenuWidthGameOver, 100.0f);
                Gl.glVertex2f(MainForm.MenuXGameOver + MainForm.MenuWidthGameOver, 500.0f);
                Gl.glVertex2f(MainForm.MenuXGameOver, 500.0f);

                Gl.glEnd();
                if (MainForm.MenuXGameOver >= 250)
                {
                    MainForm.MenuWidthGameOver += 5.0f;
                    MainForm.MenuXGameOver -= 5.0f;
                }
                else
                {
                    foreach (Doodle_Jump.Menu.ObjectMenu k in objects_menu)
                    {
                        Doodle_Jump.Menu.ObjectMenu.RenderObjectOnMenu(MainForm.Objects_menu, 4);
                    }
                }
                Gl.glLoadIdentity();
                Gl.glColor4ub(105, 52, 20, 255);



                Texture.Texture.PrintText2DPoint(90, 460, "Score:  " + (uint)map.moveMap);

                Texture.Texture.PrintText2DPoint(90, 480, "Name:  " + MainForm.DoodlerName);

                Gl.glDisable(Gl.GL_BLEND);
                Gl.glFlush();


                Score.WritingFile(map);
            }
        }


        public bool JumpFlag
        {
            get { return jumpFlag; }
            set { jumpFlag = value; }
        }

        public float DoodlerY
        {
            get { return doodlerY; }
            set { doodlerY = value; }
        }

        public float DoodlerX
        {
            get { return doodlerX; }
            set { doodlerX = value; }
        }
        public float WidthAndHeight
        {
            get { return doodlerWidth; }
            set { doodlerWidth = value; }
        }

        public bool KeyRightOrLeft
        {
            get { return keyRightOrLeft; }
            set { keyRightOrLeft = value; }
        }

        public float AccelX
        {
            get { return accelX; }
            set { accelX = value; }
        }
        public float AccelY
        {
            get { return accelY; }
            set { accelY = value; }
        }
        public float ICurrentJumpHeight
        {
            get { return i; }
            set { i = value; }
        }
        public float Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }
        public bool PownedFlag
        {
            get { return pownedFlag; }
            set { pownedFlag = value; }
        }

        public bool Godlike
        {
            get { return godlike; }
            set { godlike = value; }
        }
        public bool GyroFlag
        {
            get { return gyroFlag; }
            set { gyroFlag = value; }
        }
        public uint TimerPowned
        {
            get { return timerPowned; }
            set { timerPowned = value; }
        }
        public float DoodlerWidth
        {
            get { return doodlerWidth; }
            set { doodlerWidth = value; }
        }
        public float DoodleYGameOver
        {
            get { return doodleYGameOver; }
            set { doodleYGameOver = value; }
        }
        public float DoodleXGameOver
        {
            get { return doodleXGameOver; }
            set { doodleXGameOver = value; }
        }
    }
}
