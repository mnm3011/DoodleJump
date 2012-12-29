using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;


namespace Doodle_Jump
{
    public partial class MainForm : Form
    {

        private static bool durkaFlag = false;

        private Map.Map map = new Map.Map();
        private Doodler.Doodler doodle = new Doodler.Doodler();
        private static Utility.Sound sounds = new Utility.Sound();

        private static uint[] mGlTextureObject = new uint[50];

        private static int height = 620, width = 540;

        private static Map.MonsterInMap durkaXY = null;

        private static float menuXGameOver = 480.0f;
        private static float menuWidthGameOver = 5.0f;

        public static string DoodlerName = "";
        public static bool pauseFlag = false;
        //menu:
        // 0 - main menu
        // 1 - play game
        // 2 - game over
        // 3 - top 10
        // 4 - enter name
        public static uint menu = 0;

        public bool gameMenuSound = false;
        public bool durkaSound = false;

        private static List<Menu.ObjectMenu> objects_menu = new List<Doodle_Jump.Menu.ObjectMenu>();
        private static List<Doodler.Score> scores = new List<Doodle_Jump.Doodler.Score>();

        public bool pressButton = false;

        public MainForm()
        {

            InitializeComponent();
            OpenGlControl.InitializeContexts();
            Utility.FPS.reset();

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, OpenGlControl.Width, OpenGlControl.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Glu.gluOrtho2D(0, width, 0, height);
            Gl.glFlush();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            objects_menu = Doodle_Jump.Menu.ObjectMenu.ListObjectMenu();

            mGlTextureObject[0] = Texture.Texture.LoadImage(@"..\..\..\images\doodle-left.png");
            mGlTextureObject[1] = Texture.Texture.LoadImage(@"..\..\..\images\doodle-right.png");
            mGlTextureObject[2] = Texture.Texture.LoadImage(@"..\..\..\images\static_panel.png");
            mGlTextureObject[3] = Texture.Texture.LoadImage(@"..\..\..\images\move_panel.png");
            mGlTextureObject[4] = Texture.Texture.LoadImage(@"..\..\..\images\doodle-jump-left.png");
            mGlTextureObject[5] = Texture.Texture.LoadImage(@"..\..\..\images\doodle-jump-right.png");
            mGlTextureObject[6] = Texture.Texture.LoadImage(@"..\..\..\images\bad_panel1.png");
            mGlTextureObject[7] = Texture.Texture.LoadImage(@"..\..\..\images\bad_panel2.png");
            mGlTextureObject[8] = Texture.Texture.LoadImage(@"..\..\..\images\bg.png");
            mGlTextureObject[9] = Texture.Texture.LoadImage(@"..\..\..\images\monster_1.png");
            mGlTextureObject[10] = Texture.Texture.LoadImage(@"..\..\..\images\doodle-pow.png");
            mGlTextureObject[11] = Texture.Texture.LoadImage(@"..\..\..\images\shot.png");
            mGlTextureObject[12] = Texture.Texture.LoadImage(@"..\..\..\images\pruz1.png");
            mGlTextureObject[13] = Texture.Texture.LoadImage(@"..\..\..\images\pruz2.png");
            mGlTextureObject[14] = Texture.Texture.LoadImage(@"..\..\..\images\monster_2.png");
            mGlTextureObject[15] = Texture.Texture.LoadImage(@"..\..\..\images\batut1.png");
            mGlTextureObject[16] = Texture.Texture.LoadImage(@"..\..\..\images\monster_1a.png");
            mGlTextureObject[17] = Texture.Texture.LoadImage(@"..\..\..\images\monster_3left.png");
            mGlTextureObject[18] = Texture.Texture.LoadImage(@"..\..\..\images\monster_3right.png");
            mGlTextureObject[19] = Texture.Texture.LoadImage(@"..\..\..\images\gyro_on_panel.png");
            mGlTextureObject[20] = Texture.Texture.LoadImage(@"..\..\..\images\gyro1.png");
            mGlTextureObject[21] = Texture.Texture.LoadImage(@"..\..\..\images\batut2.png");
            mGlTextureObject[22] = Texture.Texture.LoadImage(@"..\..\..\images\durka.png");
            mGlTextureObject[23] = Texture.Texture.LoadImage(@"..\..\..\images\menu\main_menu_bg.png");
            mGlTextureObject[24] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_newgame.png");
            mGlTextureObject[25] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_newgame_active.png");
            mGlTextureObject[26] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_exit.png");
            mGlTextureObject[27] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_exit_active.png");
            mGlTextureObject[28] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_restart.png");
            mGlTextureObject[29] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_restart_active.png");
            mGlTextureObject[30] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_top10.png");
            mGlTextureObject[31] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_top10_active.png");
            mGlTextureObject[32] = Texture.Texture.LoadImage(@"..\..\..\images\menu\top10.png");
            mGlTextureObject[33] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_return.png");
            mGlTextureObject[34] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_return_active.png");
            mGlTextureObject[35] = Texture.Texture.LoadImage(@"..\..\..\images\bg_gameover.png");
            mGlTextureObject[36] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_ok.png");
            mGlTextureObject[37] = Texture.Texture.LoadImage(@"..\..\..\images\menu\button_ok_active.png");
            mGlTextureObject[38] = Texture.Texture.LoadImage(@"..\..\..\images\menu\enter_name.png");
            mGlTextureObject[39] = Texture.Texture.LoadImage(@"..\..\..\images\pause.png");
            mGlTextureObject[40] = Texture.Texture.LoadImage(@"..\..\..\images\menu\help1.png");
            mGlTextureObject[41] = Texture.Texture.LoadImage(@"..\..\..\images\menu\sound.png");
            mGlTextureObject[42] = Texture.Texture.LoadImage(@"..\..\..\images\menu\sound_active.png");
            mGlTextureObject[43] = Texture.Texture.LoadImage(@"..\..\..\images\menu\soundoff.png");
            mGlTextureObject[44] = Texture.Texture.LoadImage(@"..\..\..\images\menu\soundoff_active.png");
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (menu)
            {
                case 0:
                    {
                        Doodle_Jump.Menu.ObjectMenu.RenderGlobalMenu();
                        break;
                    }
                case 1:
                    {

                        RenderScene();

                        break;
                    }
                case 2:
                    {
                        doodle.GameOver(doodle, map, objects_menu);
                        if ((gameMenuSound == false) && (sounds.OffSound == false) && (durkaFlag == false))
                        {
                            sounds.ESound4.Play();
                            gameMenuSound = true;
                        }
                        Doodle_Jump.Doodler.Score.WritingFile(map);
                        break;
                    }
                case 3:
                    {
                        Doodle_Jump.Menu.ObjectMenu.RenderTop10(objects_menu);
                        Doodler.Score.ReadingFile();
                        Doodle_Jump.Doodler.Score.WritingFile(map);
                        break;
                    }
                case 4:
                    {
                        Doodle_Jump.Menu.ObjectMenu.RenderEnterName(objects_menu);
                        Gl.glColor4ub(105, 52, 20, 255);
                        Texture.Texture.PrintText2DPoint(230.0f, 355.0f, MainForm.DoodlerName);
                        break;
                    }
                case 5:
                    {
                        HelpMenuDraw();
                        break;
                    }

            }

            OpenGlControl.Invalidate();
        }

        private void RenderScene()
        {
            Utility.FPS.Update();


            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            Gl.glColor3ub(237, 225, 87);
            //фон
            Texture.MapDraw.BackGround(height);
            //прямоугольник
            Gl.glColor4ub(237, 225, 87, 120);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex2i(0, height - 35);
            Gl.glVertex2i(width, height - 35);
            Gl.glVertex2i(width, height);
            Gl.glVertex2i(0, height);
            Gl.glEnd();
            Gl.glLoadIdentity();






            if (pauseFlag == true)
            {
                GamePauseDraw();
            }
            else
            {

                map.Initialization();
                TurnRightOrLeft(doodle.KeyRightOrLeft);

                if (durkaFlag == false) //если персонаж не попал в дырку
                {
                    if (pressButton == true)
                        PressKeys();
                    Doodler.MechanicDoodler.DoodlerJump(map, doodle);
                    doodle.DoodlerX += doodle.AccelX;

                    if (doodle.TimerPowned > 0)
                    {
                        doodle.TimerPowned--;
                        doodle.DoodlerPowned();

                    }
                    else
                    {
                        Texture.DoodlerDraw.DoodlerRedraw(doodle);
                    }
                    if (doodle.gyroFlag == true)
                    {
                        doodle.DoodlerGyro();
                    }
                    doodle.Infinity();

                }

                //если персонаж попал в дырку
                if (durkaFlag == true)
                {
                    if ((MainForm.sounds.OffSound == false) && (durkaSound == false))
                    {
                        MainForm.sounds.ESound2.Play();
                        durkaSound = true;
                    }
                    Texture.DoodlerDraw.DoodlerInDurka(doodle, durkaXY);

                    if (doodle.DoodlerWidth < 20)
                    {
                        menu = 2;
                    }

                }
            }
            Gl.glColor4ub(105, 52, 20, 255);



            Texture.Texture.PrintText2DPoint(width - 100, height - 22, "FPS:    " + Utility.FPS.Get());

            Texture.Texture.PrintText2DPoint(width - 250, height - 22, "Score:  " + (uint)map.moveMap);

            Texture.Texture.PrintText2DPoint(width - 450, height - 22, "Name:  " + DoodlerName);

            objects_menu[10].CoordY = MainForm.height - 30;
            if (sounds.OffSound == false)
            {
                Doodle_Jump.Menu.ObjectMenu.RenderObjectOnMenu(MainForm.objects_menu, 1);
            }
            else
            {
                Doodle_Jump.Menu.ObjectMenu.RenderObjectOnMenu(MainForm.objects_menu, 7);
            }
            Gl.glDisable(Gl.GL_BLEND);
            Gl.glFlush();


        }





        private void OpenGlControl_Resize(object sender, EventArgs e)
        {
            Size s = this.OpenGlControl.Size;
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, s.Width, s.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            width = s.Width;
            height = s.Height;

            Glu.gluOrtho2D(0, width, 0, height);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }



        public static void TurnRightOrLeft(bool flag)
        {
            // поворот персонажа вправо или влево
            if (flag == true)
            {

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject[0]);

            }

            if (flag == false)
            {

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject[1]);

            }
        }


        private void OpenGlControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pressButton = true;
                doodle.KeyRightOrLeft = true;
                if (doodle.AccelX >= -2.5f)
                    doodle.AccelX -= 0.5f;
            }
            if (e.KeyCode == Keys.Right)
            {
                pressButton = true;
                doodle.KeyRightOrLeft = false;
                if (doodle.AccelX <= 2.5f)
                    doodle.AccelX += 0.5f;

            }

            if (e.KeyCode == Keys.Escape)
            {
                bool pauseOneClick = false;
                if ((pauseFlag == true) && (pauseOneClick == false))
                {
                    pauseFlag = false;
                    pauseOneClick = true;
                }

                if ((pauseFlag == false) && (pauseOneClick == false))
                {

                    pauseFlag = true;
                    pauseOneClick = true;
                }

            }
            if (e.KeyCode == Keys.Space)
            {
                if ((doodle.Godlike == false))
                {
                    doodle.PownedFlag = true;
                    doodle.TimerPowned = 10;
                    map.Shots.Add(new Doodle_Jump.Doodler.Shot(doodle.DoodlerX + 16.0f, doodle.DoodlerY + doodle.WidthAndHeight));
                    if ((sounds.OffSound == false) && (menu == 1))
                        sounds.ESound8.Play();
                }
            }

            if (menu == 4)
            {
                if (((int)e.KeyCode >= 65) && ((int)e.KeyCode <= 90))
                    DoodlerName += e.KeyCode;
                if (e.KeyCode == Keys.Back)
                {
                    if (DoodlerName.Length > 0)
                        DoodlerName = DoodlerName.Remove(DoodlerName.Length - 1);
                }
            }

        }


        private void OpenGlControl_MouseMove(object sender, MouseEventArgs e)
        {
            float y = height - e.Y;
            foreach (Doodle_Jump.Menu.ObjectMenu k in objects_menu)
            {
                if ((e.X >= k.CoordX) && (e.X <= k.CoordX + k.Width) && (y >= k.CoordY) && (y <= k.CoordY + k.Height))
                {
                    k.Active = true;
                }
                else
                {
                    k.Active = false;
                }
            }
        }

        private void OpenGlControl_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Doodle_Jump.Menu.ObjectMenu k in objects_menu)
            {
                if (k.Active == true)
                {
                    switch (k.Id)
                    {

                        case 2: //exit
                            {
                                if (menu == 0)
                                {
                                    Doodle_Jump.Doodler.Score.WritingFile(map);
                                    this.Close();

                                }
                                break;
                            }
                        case 0: //new game
                            {
                                if (menu == 0)
                                {
                                    menu = 4;
                                    NewGame(ref map, ref doodle);
                                }
                                break;
                            }
                        case 1:
                            {
                                if (menu == 0)
                                    menu = 3;
                                break;
                            }
                        case 3:
                            {
                                if (menu == 3)
                                    menu = 0;
                                break;
                            }
                        case 4:
                            {
                                if (menu == 2)
                                {
                                    menu = 1;
                                    NewGame(ref map, ref doodle);
                                }
                                break;
                            }
                        case 5:
                            {
                                if (menu == 2)
                                {
                                    Doodle_Jump.Doodler.Score.WritingFile(map);
                                    this.Close();
                                }
                                break;
                            }
                        case 6:
                            {   //в главное меню
                                if (menu == 2)
                                {
                                    menu = 0;
                                }
                                break;
                            }
                        case 7:
                            {
                                if (menu == 4)
                                    menu = 0;
                                break;
                            }


                        case 8:
                            {
                                if (DoodlerName != "")
                                {
                                    menu = 5;
                                }
                                break;

                            }
                        case 9:
                            {
                                if (menu == 5)
                                {
                                    menu = 1;
                                }
                                break;
                            }
                        case 10:
                            {
                                if (menu == 1)
                                {
                                    if (sounds.OffSound == true)
                                        sounds.OffSound = false;
                                    else
                                    {
                                        sounds.OffSound = true;
                                    }
                                }
                                break;
                            }


                    }
                }
            }
        }

        private void NewGame(ref Map.Map map, ref Doodler.Doodler doodle)
        {
            map = new Map.Map();
            doodle = new Doodler.Doodler();
            durkaFlag = false;
            gameMenuSound = false;
        }

        private static void GamePauseDraw()
        {
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glTranslatef(230, 350, 0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject[39]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(100, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(100, 50);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 50);

            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLoadIdentity();

        }
        private static void HelpMenuDraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glLoadIdentity();
            Gl.glTranslatef(0.0f, 0.0f, 0.0f);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.mGlTextureObject[8]);
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
            Gl.glLoadIdentity();


            Gl.glTranslatef(70, 200, 0);
            if (menu == 5)
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject[40]);
            }


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex2i(400, 0);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex2i(400, 300);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex2i(0, 300);

            Gl.glEnd();
            Gl.glLoadIdentity();
            Doodle_Jump.Menu.ObjectMenu.RenderObjectOnMenu(objects_menu, 6);

            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_BLEND);

            Gl.glLoadIdentity();
        }

        private void OpenGlControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pressButton = false;
                doodle.KeyRightOrLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                pressButton = false;
                doodle.KeyRightOrLeft = false;


            }
        }

        private void PressKeys()
        {
            if (doodle.KeyRightOrLeft == true)
            {
                if (doodle.AccelX >= -2.5f)
                    doodle.AccelX -= 0.5f;
            }
            if (doodle.KeyRightOrLeft == false)
            {
                if (doodle.AccelX <= 2.5f)
                    doodle.AccelX += 0.5f;

            }
        }


        public static int Height1
        {
            get { return height; }
            set { height = value; }
        }

        public static int Width1
        {
            get { return width; }
            set { width = value; }
        }
        public static bool DurkaFlag
        {
            get { return durkaFlag; }
            set { durkaFlag = value; }
        }

        public static List<Menu.ObjectMenu> Objects_menu
        {
            get { return objects_menu; }
        }
        public static List<Doodler.Score> Scores
        {
            get { return scores; }
            set { scores = value; }
        }


        public static Utility.Sound Sounds
        {
            get { return sounds; }
            set { sounds = value; }
        }

        public static uint[] MGlTextureObject
        {
            get { return mGlTextureObject; }
            set { mGlTextureObject = value; }
        }

        public static Map.MonsterInMap DurkaXY
        {
            get { return durkaXY; }
            set { durkaXY = value; }
        }

        public static float MenuXGameOver
        {
            get { return menuXGameOver; }
            set { menuXGameOver = value; }
        }
        public static float MenuWidthGameOver
        {
            get { return menuWidthGameOver; }
            set { menuWidthGameOver = value; }
        }
    }


}

