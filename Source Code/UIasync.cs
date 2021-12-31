using System;
using System.IO;
using System.Windows.Forms;

namespace MuMMyBot
{
    public partial class UIasync : Form
    {
        public UIasync()
        {
            InitializeComponent();
        }

        string combination = "";
        string[] arr;

        
        private GlobalKeyboardHook _globalKeyboardHook;

        public void listenKey(bool d)
        {
            if (d)
            {
                _globalKeyboardHook = new GlobalKeyboardHook();
                _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
            }
            else
            {
                _globalKeyboardHook.KeyboardPressed += null;
                _globalKeyboardHook.Dispose();
                _globalKeyboardHook = null;
            }
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardData.VirtualCode != UI.virtualKeyValues[comboBox6.SelectedIndex]) return;

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                e.Handled = true;
                button1_Click("", e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (UI.checkProcess()) return;

                combination = richTextBox1.Text;
                arr = combination.Split('\n');
                timer1.Interval = Convert.ToInt32(textBox1.Text);

                if (button1.Text == "Start Macrô")
                {
                    timer1.Start();
                    richTextBox1.Enabled = false;
                    textBox1.Enabled = false;
                    button1.Text = "Stop Macrô";
                }
                else if (button1.Text == "Stop Macrô")
                {
                    timer1.Stop();
                    richTextBox1.Enabled = true;
                    textBox1.Enabled = true;
                    button1.Text = "Start Macrô";
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (UI.mainProcess != null)
                {
                    for (int i = 0; i < arr.Length - 1; i = i + 2)
                    {
                        int tLn = Array.IndexOf(UI.keys, arr[i].ToUpper());

                        if (UI.inputTypeIndex == 0)
                        {
                            short key = UI.directInputKeyValues[tLn];

                            cDirectInput.Send_Key(key, (int)cDirectInput.KeyEventF.KeyDown);
                            UI.slp(UI.keyPressPullDelay);
                            cDirectInput.Send_Key(key, (int)cDirectInput.KeyEventF.KeyUp);
                        }
                        else if (UI.inputTypeIndex == 1)
                        {
                            short key = UI.virtualKeyValues[tLn];

                            standartInput.SendKeyDown(key);
                            UI.slp(UI.keyPressPullDelay);
                            standartInput.SendKeyUp(key);
                        }
                        else if (UI.inputTypeIndex == 2)
                        {
                            short key = UI.virtualKeyValues[tLn];
                            backgroundInput.PostMessage(
                                backgroundInput.FindWindowEx(UI.mainProcess.MainWindowHandle, IntPtr.Zero, UI.BGSubWindowName, null),
                                backgroundInput.WM_KEYDOWN, key, 0);
                            UI.slp(UI.keyPressPullDelay);
                            backgroundInput.PostMessage(
                                backgroundInput.FindWindowEx(UI.mainProcess.MainWindowHandle, IntPtr.Zero, UI.BGSubWindowName, null),
                                backgroundInput.WM_KEYUP, key, 0);
                        }

                        int cd = Convert.ToInt32(arr[i + 1]);
                        UI.slp(cd);
                    }
                }
            }
            catch (Exception x)
            {
                button1_Click("", e);
                MessageBox.Show("Error: " + x.ToString(), "The text should be entered in the desired format.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\asyncSettings.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(textBox1.Text);
            sw.WriteLine(checkBox1.Checked);
            sw.WriteLine(comboBox6.Text);

            string[] splitLines = richTextBox1.Text.Split('\n');
            for (int i = 0; i < splitLines.Length; i++)
            {
                sw.Write(splitLines[i]);
                if (i != (splitLines.Length - 1)) sw.Write("\n");
            }
            sw.Close();
            fs.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UI.writeKeyNames(comboBox6);

            if (File.Exists(Application.StartupPath + "\\asyncSettings.txt"))
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\asyncSettings.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string read = sr.ReadToEnd();
                sr.Close();
                fs.Close();

                string[] spl = read.Split('\n');
                textBox1.Text = spl[0].Replace("\r", "");
                checkBox1.Checked = Convert.ToBoolean(spl[1].Replace("\r", ""));
                comboBox6.Text = spl[2].Replace("\r","");

                for (int i = 3; i < spl.Length; i++)
                {
                    richTextBox1.Text += spl[i];
                    if (i != (spl.Length - 1)) richTextBox1.Text += "\n";
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox6.Enabled = true;
                listenKey(true);
            }
            else
            {
                comboBox6.Enabled = false;
                listenKey(false);
            }
        }
    }
}
