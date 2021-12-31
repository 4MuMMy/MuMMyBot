//      [!]      [!]      [!] -->      RUN AS ADMINISTRATOR      <-- [!]      [!]      [!]
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MuMMyBot
{
    public partial class UI : Form
    {
        public static string[] inputTypes = { "Direct Input", "Standart Input", "Background Input" };
        public static string[] keys = {
                "Esc",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "0",
                "-",
                "=",
                "Back Space",
                "Tab",
                "Q",
                "W",
                "E",
                "R",
                "T",
                "Y",
                "U",
                "I",
                "O",
                "P",
                "[",
                "]",
                "Enter",
                "Ctrl (Left)",
                "A",
                "S",
                "D",
                "F",
                "G",
                "H",
                "J",
                "K",
                "L",
                ";",
                "'",
                "`",
                "Shift (Left)",
                "\\",
                "Z",
                "X",
                "C",
                "V",
                "B",
                "N",
                "M",
                ",",
                ".",
                "/",
                "Shift (Right)",
                "* (Numpad)",
                "Alt (Left)",
                "Space",
                "Caps Lock",
                "F1",
                "F2",
                "F3",
                "F4",
                "F5",
                "F6",
                "F7",
                "F8",
                "F9",
                "F10",
                "Num Lock",
                "Scroll Lock",
                "7 (Numpad)",
                "8 (Numpad)",
                "9 (Numpad)",
                "- (Numpad)",
                "4 (Numpad)",
                "5 (Numpad)",
                "6 (Numpad)",
                "+ (Numpad)",
                "1 (Numpad)",
                "2 (Numpad)",
                "3 (Numpad)",
                "0 (Numpad)",
                ". (Numpad)",
                "F11",
                "F12",
                "Enter (Numpad)",
                "Ctrl (Right)",
                ", (Numpad)",
                "/ (Numpad)",
                "Sys Rq",
                "Alt (Right)",
                "Pause",
                "Home",
                "↑",
                "Page Up",
                "←",
                "→",
                "End",
                "↓",
                "Page Down",
                "Insert",
                "Delete",
                "Windows (Left)",
                "Windows (Right)",
                "Menu",
                "Power",
                "Windows Sleep"
            };

        public static short[] directInputKeyValues =
        {
                0x01,
                0x02,
                0x03,
                0x04,
                0x05,
                0x06,
                0x07,
                0x08,
                0x09,
                0x0A,
                0x0B,
                0x0C,
                0x0D,
                0x0E,
                0x0F,
                0x10,
                0x11,
                0x12,
                0x13,
                0x14,
                0x15,
                0x16,
                0x17,
                0x18,
                0x19,
                0x1A,
                0x1B,
                0x1C,
                0x1D,
                0x1E,
                0x1F,
                0x20,
                0x21,
                0x22,
                0x23,
                0x24,
                0x25,
                0x26,
                0x27,
                0x28,
                0x29,
                0x2A,
                0x2B,
                0x2C,
                0x2D,
                0x2E,
                0x2F,
                0x30,
                0x31,
                0x32,
                0x33,
                0x34,
                0x35,
                0x36,
                0x37,
                0x38,
                0x39,
                0x3A,
                0x3B,
                0x3C,
                0x3D,
                0x3E,
                0x3F,
                0x40,
                0x41,
                0x42,
                0x43,
                0x44,
                0x45,
                0x46,
                0x47,
                0x48,
                0x49,
                0x4A,
                0x4B,
                0x4C,
                0x4D,
                0x4E,
                0x4F,
                0x50,
                0x51,
                0x52,
                0x53,
                0x57,
                0x58,
                0x9C,
                0x9D,
                0xB3,
                0xB5,
                0xB7,
                0xB8,
                0xC5,
                0xC7,
                0xC8,
                0xC9,
                0xCB,
                0xCD,
                0xCF,
                0xD0,
                0xD1,
                0xD2,
                0xD3,
                0xDB,
                0xDC,
                0xDD,
                0xDE,
                0xDF
            };

        public static short[] virtualKeyValues=
        {
                0x1B,
                0x31,
                0x32,
                0x33,
                0x34,
                0x35,
                0x36,
                0x37,
                0x38,
                0x39,
                0x30,
                0xBD,
                0xBB,
                0x08,
                0x09,
                0x51,
                0x57,
                0x45,
                0x52,
                0x54,
                0x59,
                0x55,
                0x49,
                0x4F,
                0x50,
                0xDB,
                0xDD,
                0x0D,
                0xA2,
                0x41,
                0x53,
                0x44,
                0x46,
                0x47,
                0x48,
                0x4A,
                0x4B,
                0x4C,
                0xBA,
                0xDE,
                0xC0,
                0xA0,
                0xDC,
                0x5A,
                0x58,
                0x43,
                0x56,
                0x42,
                0x4E,
                0x4D,
                0xBC,
                0xBE,
                0xBF,
                0xA1,
                0x6A,
                0xA4,
                0x20,
                0x14,
                0x70,
                0x71,
                0x72,
                0x73,
                0x74,
                0x75,
                0x76,
                0x77,
                0x78,
                0x79,
                0x90,
                0x91,
                0x67,
                0x68,
                0x69,
                0x6D,
                0x64,
                0x65,
                0x66,
                0x6B,
                0x61,
                0x62,
                0x63,
                0x60,
                0x6E,
                0x7A,
                0x7B,
                0x0D,
                0xA3,
                0xBC,
                0x6F,
                0x2C,
                0xA5,
                0xB3,
                0x24,
                0x26,
                0x21,
                0x25,
                0x27,
                0x23,
                0x28,
                0x22,
                0x2D,
                0x2E,
                0x5B,
                0x5C,
                0xA5,
                0x5F,
                0x5F
            };

        public static Process mainProcess;
        bool noErr = true;
        public static int inputTypeIndex, keyPressPullDelay;
        public static string BGSubWindowName;

        UIasync UIasync_ = new UIasync();

        public UI()
        {
            InitializeComponent();
        }

        public void msg(string t)
        {
            if (console.Text.Length > 100000) console.Text = "";
            console.Text += DateTime.Now + " :->\n" + t + "\n\n";
        }

        public static void slp(int t)
        {
            System.Threading.Thread.Sleep(t);
        }

        public static void writeKeyNames(ComboBox c)
        {
            foreach (var i in keys)
            {
                c.Items.Add(i);
            }

            c.SelectedIndex = 0;
        }

        public static void writeInputTypes(ComboBox c)
        {
            foreach (var i in inputTypes)
            {
                c.Items.Add(i);
            }

            c.SelectedIndex = 0;
        }

        void doSpl(StreamReader s, ComboBox c, TextBox t, ComboBox c2 = null)
        {
            string[] spl = s.ReadLine().Split('|');
            if (c2 == null)
            {
                c.Text = spl[0];
                t.Text = spl[1];
            }
            else
            {
                c.Text = spl[0];
                c2.Text = spl[1];
                t.Text = spl[2];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = new Random().Next(0, 999999999) + Guid.NewGuid().ToString().Replace("-", "");

            writeKeyNames(mk1Combo);
            writeKeyNames(comboBox1);
            writeKeyNames(comboBox2);
            writeKeyNames(comboBox3);
            writeKeyNames(comboBox4);
            writeKeyNames(comboBox5);
            writeKeyNames(comboBox6);
            writeKeyNames(comboBox7);
            writeKeyNames(comboBox8);
            writeKeyNames(comboBox9);
            writeKeyNames(comboBox10);
            writeKeyNames(comboBox11);
            writeKeyNames(comboBox12);
            writeKeyNames(comboBox13);
            writeKeyNames(comboBox14);
            writeKeyNames(comboBox15);
            writeKeyNames(comboBox16);
            writeKeyNames(comboBox17);

            writeInputTypes(comboBox18);

            loadSavedSettings();

            inputTypeIndex = comboBox18.SelectedIndex;

            radioButton1_CheckedChanged("", e);
            radioButton2_CheckedChanged("", e);
            radioButton3_CheckedChanged("", e);
        }

        public void loadProcess(bool showInfo = true)
        {
            try
            {
                mainProcess = null;

                if (radioButton1.Checked)
                    mainProcess = Process.GetProcessById(Convert.ToInt32(pIDTxt.Text));
                else if (radioButton2.Checked)
                {
                    windowNameTxt.Items.Clear();

                    Process[] pcs = Process.GetProcesses();

                    foreach (Process p in pcs)
                    {
                        try
                        {
                            if (windowNameTxt.Items.IndexOf(p.MainWindowTitle) == -1)
                                windowNameTxt.Items.Add(p.MainWindowTitle);

                            if (p.MainWindowTitle == windowNameTxt.Text) mainProcess = p;
                        }
                        catch (Exception x) { msg(x + ""); }
                    }
                }
                else if (radioButton3.Checked)
                {
                    Process[] pcs = Process.GetProcesses();

                    comboBox19.Items.Clear();

                    foreach (Process p in pcs)
                    {
                        try
                        {
                            if (comboBox19.Items.IndexOf(p.ProcessName) == -1)
                                comboBox19.Items.Add(p.ProcessName);

                            if (p.ProcessName == comboBox19.Text) mainProcess = p;
                        }
                        catch (Exception x) { msg(x + ""); }
                    }
                }

                if (mainProcess != null)
                {
                    msg("Window loaded > " + mainProcess.ProcessName);

                    ProcessModule pM = mainProcess.MainModule;
                    msg("Loaded Module: \n" +
                    "ModuleName: " + pM.ModuleName + "\n" +
                    "BaseAddress: " + pM.BaseAddress + "\n" +
                    "EntryPointAddress: " + pM.EntryPointAddress + "\n" +
                    "ModuleMemorySize: " + pM.ModuleMemorySize + "\n" +
                    "FileVersionInfo: \n" + pM.FileVersionInfo + "\n");

                    saveChanges();
                }
                else msg("Window Not Found");
            }
            catch (Exception x)
            {
                mainProcess = null;
                if (showInfo) msg(x + "");

            }
        }

        public static bool checkProcess()
        {
            if (mainProcess == null)
            {
                MessageBox.Show("Please check process settings.", "No Process");
                return true;
            }
            else return false;
        }

        void createMacro(Button b, Timer t, TextBox h, ComboBox c, ComboBox c2 = null)
        {
            try
            {
                if (checkProcess()) return;

                if (b.Text == "Start")
                {
                    t.Interval = Convert.ToInt32(h.Text);
                    b.Text = "Stop";
                    t.Start();
                    h.Enabled = false;
                    c.Enabled = false;
                    if (c2 != null) c2.Enabled = false;

                    msg(mainProcess.ProcessName + " started");
                }
                else
                {
                    b.Text = "Start";
                    t.Stop();
                    h.Enabled = true;
                    c.Enabled = true;
                    if (c2 != null) c2.Enabled = true;

                    msg(mainProcess.ProcessName + " stopped");
                }

                saveChanges();

                noErr = true;
            }
            catch(Exception x)
            {
                noErr = false;
                msg(x + "");
                MessageBox.Show(x.ToString(), "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createMacro(button1, timer1, mk1hiz, mk1Combo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createMacro(button2, timer2, textBox1, comboBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            createMacro(button3, timer3, textBox2, comboBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            createMacro(button4, timer4, textBox3, comboBox3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            createMacro(button5, timer5, textBox4, comboBox4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            createMacro(button6, timer6, textBox5, comboBox5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            createMacro(button7, timer7, textBox6, comboBox6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            createMacro(button8, timer8, textBox7, comboBox7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            createMacro(button9, timer9, textBox8, comboBox8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            createMacro(button10, timer10, textBox9, comboBox9);
        }

        void timerLoadKey(ComboBox c, ComboBox c2 = null)
        {
            if (mainProcess != null)
            {
                short key1, key2 = -1;

                if (inputTypeIndex == 0)
                {
                    key1 = directInputKeyValues[c.SelectedIndex];
                    if (c2 != null)
                        key2 = directInputKeyValues[c2.SelectedIndex];

                    cDirectInput.Send_Key(key1, (int)cDirectInput.KeyEventF.KeyDown);
                    if (c2 != null) cDirectInput.Send_Key(key2, (int)cDirectInput.KeyEventF.KeyDown);
                    slp(keyPressPullDelay);
                    if (c2 != null) cDirectInput.Send_Key(key2, (int)cDirectInput.KeyEventF.KeyUp);
                    cDirectInput.Send_Key(key1, (int)cDirectInput.KeyEventF.KeyUp);
                }
                else if (inputTypeIndex == 1)
                {
                    key1 = virtualKeyValues[c.SelectedIndex];
                    if (c2 != null)
                        key2 = virtualKeyValues[c2.SelectedIndex];

                    standartInput.SendKeyDown(key1);
                    if (c2 != null) standartInput.SendKeyDown(key2);
                    slp(keyPressPullDelay);
                    if (c2 != null) standartInput.SendKeyUp(key2);
                    standartInput.SendKeyUp(key1);
                }
                else if (inputTypeIndex == 2)
                {
                    key1 = virtualKeyValues[c.SelectedIndex];
                    if (c2 != null)
                        key2 = virtualKeyValues[c2.SelectedIndex];

                    backgroundInput.PostMessage(
                        backgroundInput.FindWindowEx(mainProcess.MainWindowHandle, IntPtr.Zero, BGSubWindowName, null),
                        backgroundInput.WM_KEYDOWN, key1, 0);
                    if (c2 != null) backgroundInput.PostMessage(
                        backgroundInput.FindWindowEx(mainProcess.MainWindowHandle, IntPtr.Zero, BGSubWindowName, null),
                        backgroundInput.WM_KEYDOWN, key2, 0);
                    slp(keyPressPullDelay);
                    if (c2 != null) backgroundInput.PostMessage(
                        backgroundInput.FindWindowEx(mainProcess.MainWindowHandle, IntPtr.Zero, BGSubWindowName, null),
                        backgroundInput.WM_KEYUP, key2, 0);
                    backgroundInput.PostMessage(
                        backgroundInput.FindWindowEx(mainProcess.MainWindowHandle, IntPtr.Zero, BGSubWindowName, null),
                        backgroundInput.WM_KEYUP, key1, 0);
                }
}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLoadKey(mk1Combo);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox1);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox2);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox3);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox4);
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox5);
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox6);
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox7);
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox8);
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (noErr) if (mk1hiz.Text != "") button1_Click("", e);
            if (noErr) if (textBox1.Text != "") button2_Click("", e);
            if (noErr) if (textBox2.Text != "") button3_Click("", e);
            if (noErr) if (textBox3.Text != "") button4_Click("", e);
            if (noErr) if (textBox4.Text != "") button5_Click("", e);
            if (noErr) if (textBox5.Text != "") button6_Click("", e);
            if (noErr) if (textBox6.Text != "") button7_Click("", e);
            if (noErr) if (textBox7.Text != "") button8_Click("", e);
            if (noErr) if (textBox8.Text != "") button9_Click("", e);
            if (noErr) if (textBox9.Text != "") button10_Click("", e);
            if (noErr) if (textBox10.Text != "") button13_Click("", e);
            if (noErr) if (textBox11.Text != "") button14_Click("", e);
            if (noErr) if (textBox12.Text != "") button15_Click("", e);
            if (noErr) if (textBox13.Text != "") button16_Click("", e);
            noErr = true;
        }

        void loadSavedSettings()
        {
            if (File.Exists(Application.StartupPath + "\\syncSettings.txt"))
            {
                FileStream f = new FileStream(Application.StartupPath + "\\syncSettings.txt", FileMode.Open, FileAccess.Read);
                StreamReader s = new StreamReader(f);

                int sInd = Convert.ToInt32(s.ReadLine().Replace("\r", ""));

                radioButton1.Checked = sInd == 1 ? true : false;
                radioButton2.Checked = sInd == 2 ? true : false;
                radioButton3.Checked = sInd == 3 ? true : false;
                pIDTxt.Text = s.ReadLine().Replace("\r", "");
                windowNameTxt.Text = s.ReadLine().Replace("\r", "");
                comboBox19.Text = s.ReadLine().Replace("\r", "");
                comboBox18.Text = s.ReadLine().Replace("\r", "");
                textBox14.Text = s.ReadLine().Replace("\r", "");
                textBox15.Text = s.ReadLine().Replace("\r", "");

                doSpl(s, mk1Combo, mk1hiz);
                doSpl(s, comboBox1, textBox1);
                doSpl(s, comboBox2, textBox2);
                doSpl(s, comboBox3, textBox3);
                doSpl(s, comboBox4, textBox4);
                doSpl(s, comboBox5, textBox5);
                doSpl(s, comboBox6, textBox6);
                doSpl(s, comboBox7, textBox7);
                doSpl(s, comboBox8, textBox8);
                doSpl(s, comboBox9, textBox9);

                doSpl(s, comboBox10, textBox10, comboBox11);
                doSpl(s, comboBox12, textBox11, comboBox13);
                doSpl(s, comboBox14, textBox12, comboBox15);
                doSpl(s, comboBox16, textBox13, comboBox17);

                s.Close();
                f.Close();
            }
        }

        void saveChanges()
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\syncSettings.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(radioButton1.Checked ? "1" : radioButton2.Checked ? "2" : radioButton3.Checked ? "3" : "");
            sw.WriteLine(pIDTxt.Text);
            sw.WriteLine(windowNameTxt.Text);
            sw.WriteLine(comboBox19.Text);
            sw.WriteLine(comboBox18.Text);
            sw.WriteLine(textBox14.Text);
            sw.WriteLine(textBox15.Text);
            sw.WriteLine(mk1Combo.Text + "|" + mk1hiz.Text);
            sw.WriteLine(comboBox1.Text + "|" + textBox1.Text);
            sw.WriteLine(comboBox2.Text + "|" + textBox2.Text);
            sw.WriteLine(comboBox3.Text + "|" + textBox3.Text);
            sw.WriteLine(comboBox4.Text + "|" + textBox4.Text);
            sw.WriteLine(comboBox5.Text + "|" + textBox5.Text);
            sw.WriteLine(comboBox6.Text + "|" + textBox6.Text);
            sw.WriteLine(comboBox7.Text + "|" + textBox7.Text);
            sw.WriteLine(comboBox8.Text + "|" + textBox8.Text);
            sw.WriteLine(comboBox9.Text + "|" + textBox9.Text);
            sw.WriteLine(comboBox10.Text + "|" + comboBox11.Text + "|" + textBox10.Text);
            sw.WriteLine(comboBox12.Text + "|" + comboBox13.Text + "|" + textBox11.Text);
            sw.WriteLine(comboBox14.Text + "|" + comboBox15.Text + "|" + textBox12.Text);
            sw.Write(comboBox16.Text + "|" + comboBox17.Text + "|" + textBox13.Text);
            sw.Close();
            fs.Close();

            msg("Changes saved.");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            createMacro(button13, timer11, textBox10, comboBox10, comboBox11);
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox10, comboBox11);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            createMacro(button14, timer12, textBox11, comboBox12, comboBox13);
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox12, comboBox13);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            createMacro(button15, timer13, textBox12, comboBox14, comboBox15);
        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox14, comboBox15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            createMacro(button16, timer14, textBox13, comboBox16, comboBox17);
        }

        private void timer14_Tick(object sender, EventArgs e)
        {
            timerLoadKey(comboBox16, comboBox17);
        }
        
        private void button17_Click(object sender, EventArgs e)
        {
            if (!UIasync_.Visible)
            {
                UIasync_ = new UIasync();
                UIasync_.Show();
            }
            else UIasync_.Focus();
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputTypeIndex = comboBox18.SelectedIndex;
            loadProcess(false);

            if (comboBox18.SelectedIndex == 2) textBox14.Enabled = true;
            else textBox14.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                loadProcess(false);
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                windowNameTxt.Enabled = false;
                comboBox19.Enabled = false;
                pIDTxt.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                loadProcess(false);
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                pIDTxt.Enabled = false;
                comboBox19.Enabled = false;
                windowNameTxt.Enabled = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                loadProcess(false);
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                pIDTxt.Enabled = false;
                windowNameTxt.Enabled = false;
                comboBox19.Enabled = true;
            }
        }

        private void pIDTxt_Leave(object sender, EventArgs e)
        {
            loadProcess();
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            loadProcess(false);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            BGSubWindowName = textBox14.Text;
        }

        void flexibleDropDown(object sender)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            System.Drawing.Graphics g = senderComboBox.CreateGraphics();
            System.Drawing.Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in senderComboBox.Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width + 25;
        }

        private void windowNameTxt_Leave(object sender, EventArgs e)
        {
            loadProcess();
        }

        private void windowNameTxt_DropDown(object sender, EventArgs e)
        {
            windowNameTxt.Sorted = true;
            flexibleDropDown(sender);
        }

        private void comboBox19_Leave(object sender, EventArgs e)
        {
            loadProcess();
        }

        private void comboBox19_DropDown(object sender, EventArgs e)
        {
            comboBox19.Sorted = true;
            flexibleDropDown(sender);
        }

        private void console_TextChanged(object sender, EventArgs e)
        {
            console.SelectionStart = console.Text.Length;
            console.ScrollToCaret();
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            keyPressPullDelay = Convert.ToInt32(textBox15.Text);
        }
    }

}
//by MuMMy
