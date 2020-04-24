//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="John Helfrich">
//      Copyright (c) John Helfrich. MIT License
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of 
// the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <author>John Helfrich</author>
//-----------------------------------------------------------------------
namespace WinForms_TC3CPP_OnlineChange
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using TwinCAT.Ads;
    using TwinCAT.Measurement.Scope.API.Model;
    using TwinCAT.Scope2.Communications;
    public partial class CppOnlineDash : Form
    {
        // ADS Variables
        private TcAdsClient tcClient;
        private TcAdsClient tcClientTaskValues;
        private AmsAddress amsAddressTcCom;
        private AmsAddress amsAddressTask;
        private AdsStream readStream;
        private AdsBinaryReader reader;
        private string tmcVendorInfo_Name = "C++ Module Vendor|"; //Left as the default
        private string tmcVersionedClassfactory_Name = "CPPVP1|";
        private UInt32 tcCOM_indexGroup = 0x1010010;
        private UInt32 tcCOM_indexOffset = 0x3002119;
        private UInt32 task_indexGroup = 0x1010010;
        private UInt32 task_indexOffset = 0x81000000;

        // Scope Variables
        Chart chart;
        AxisGroup axisGroup;
        Channel channel;
        AcquisitionInterpreter acquisitionInterpreter;
        AdsAcquisition adsAcquisition;
        SeriesStyle style;

        // XML Parser data for pulling ADS Static Routes
        private XmlNodeList RouteName;
        private XmlNodeList RouteAddress;
        private XmlNodeList RouteNetId;
        private const string StaticRoutePath = @"C:\TwinCAT\3.1\Target\StaticRoutes.xml";

        // Threading Variables
        private CancellationTokenSource _cts;

        public CppOnlineDash()
        {
            // Initialize Components
            InitializeComponent();
            XML_ADS_Parser();
            UI_Disconnected();
            scopeProjectPanel.ScopeProject = new ScopeProject();
            chart = new YTChart();
            axisGroup = new AxisGroup();
            channel = new Channel();
            acquisitionInterpreter = new AcquisitionInterpreter();
            adsAcquisition = new AdsAcquisition();
            style = new SeriesStyle();

            // Register Events
            checkBoxAdsLocal.CheckedChanged += new EventHandler(this.AdsTargetBox_Checked);
            btnAdsConnect.Click += new EventHandler(this.AdsConnect_Click);
            btnAdsDisconnect.Click += new EventHandler(this.AdsDisconnect_Click);
            btnTcComVer1.Click += new EventHandler(this.TcComVer1_Click);
            btnTcComVer2.Click += new EventHandler(this.TcComVer2_Click);
            btnTcComVer3.Click += new EventHandler(this.TcComVer3_Click);
            btnTcComVer4.Click += new EventHandler(this.TcComVer4_Click);
            btnTcComVer5.Click += new EventHandler(this.TcComVer5_Click);

            // Execute some setup code
            scopeProjectPanel.ScopeProject.AddMember(chart);
            chart.AddMember(axisGroup);
            axisGroup.AddMember(channel);
        }


        private void XML_ADS_Parser()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
                xmlDoc.Load(StaticRoutePath); // Load the XML document from the specified file

                // Get elements
                RouteName = xmlDoc.GetElementsByTagName("Name");
                RouteAddress = xmlDoc.GetElementsByTagName("Address");
                RouteNetId = xmlDoc.GetElementsByTagName("NetId");

                // Load the ComboBox
                for (int i = 0; i < RouteName.Count; i++)
                {
                    if (RouteName[i].InnerText.Length > 0)
                    {
                        comboBoxAdsTargets.Items.Add(RouteName[i].InnerText);
                    }
                }

                if (comboBoxAdsTargets.Items.Count > 0)
                {
                    comboBoxAdsTargets.SelectedIndex = 0;
                    checkBoxAdsLocal.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Issue Loading XML Data: " + ex);
                MessageBox.Show("Could not find the StaticRoutes data file\nFile Location: " + @"C:\TwinCAT\3.1\Target\StaticRoutes.xml" + "\n\nSetting local as ADS target...");
                comboBoxAdsTargets.Enabled = false;
                comboBoxAdsTargets.Update();
            }
        }

        private void AdsTargetBox_Checked(Object sender, EventArgs e)
        {
            if (checkBoxAdsLocal.Checked)
                comboBoxAdsTargets.Enabled = false;
            else
                comboBoxAdsTargets.Enabled = true;

            comboBoxAdsTargets.Update();
        }

        private void AdsConnect_Click(Object sender, EventArgs e)
        {
            tcClient = new TcAdsClient();
            tcClientTaskValues = new TcAdsClient();
            readStream = new AdsStream(sizeof(double));
            reader = new AdsBinaryReader(readStream);


            try
            {
                if (checkBoxAdsLocal.Checked)
                {
                    amsAddressTcCom = new AmsAddress(10);
                    amsAddressTask = new AmsAddress(350);
                    tcClient.Connect(10);
                    tcClientTaskValues.Connect(350);
                }
                else
                {
                    amsAddressTcCom = new AmsAddress(RouteNetId[comboBoxAdsTargets.SelectedIndex].InnerText, 10);
                    amsAddressTask = new AmsAddress(RouteNetId[comboBoxAdsTargets.SelectedIndex].InnerText, 350);
                    tcClient.Connect(amsAddressTcCom);
                    tcClientTaskValues.Connect(amsAddressTask);
                }

                // Read the state of the device
                StateInfo stateInfo = tcClient.ReadState();
                _cts = new CancellationTokenSource();
                Task.Run(async () => await AdsSymbolUpdate());
                UI_Connected();

                ChangeChannelSettings( Color.Green, Color.DarkGreen );
                SetAcquisitions();     
                Start_Scope();
            }
            catch (AdsException ex)
            {
                MessageBox.Show("Could not connect to ADS target...\n\n\nException: " + ex.Message);
            }
        }

        private void AdsDisconnect_Click(Object sender, EventArgs e)
        {
            AdsDisconnect();
        }

        private void SetAcquisitions()
        {
            //AmsNetId and AmsPort need the TwinCAT.Ads.dll
            adsAcquisition.AmsNetId = amsAddressTask.NetId;
            adsAcquisition.TargetPort = 350;
            adsAcquisition.SymbolBased = true;
            adsAcquisition.SymbolName = "Object1 (SignalsDemo).Outputs.Value";
            adsAcquisition.DataType = DataTypeConverter.AdsToScope2Datatype(AdsDatatypeId.ADST_INT32);
            adsAcquisition.SampleTime = (uint)(10 * TimeSpan.TicksPerMillisecond);
            acquisitionInterpreter.Acquisition = adsAcquisition;
            channel.AddMember(acquisitionInterpreter);
        }

        private void ChangeChannelSettings(Color displayColor, Color markerColor)
        {
            style = channel.SubMember.OfType<ChannelStyle>().First().SubMember.OfType<SeriesStyle>().First();
            channel.DisplayColor = displayColor;
            style.DisplayColor = displayColor;
            style.MarkColor = markerColor;
            style.LineWidth = 3;
        }

        private void Start_Scope()
        {
            try
            {
                //dascard old data
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Reply)
                    scopeProjectPanel.ScopeProject.Disconnect();

                //start record
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Config)
                    scopeProjectPanel.ScopeProject.StartRecord();

                //start all charts
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Connected)
                {
                    foreach (Chart chart in scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>())
                    {
                        chart.StartDisplay();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on start record!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Stop_Scope()
        {
            try
            {
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
                {
                    scopeProjectPanel.ScopeProject.StopRecord();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on stop record!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TcComVer1_Click(Object sender, EventArgs e)
        {
            _writeTcComModuleVersion("0.0.0.1");
            ChangeChannelSettings(Color.Green, Color.DarkGreen);
        }
        private void TcComVer2_Click(Object sender, EventArgs e)
        {
            _writeTcComModuleVersion("0.0.0.2");
            ChangeChannelSettings(Color.Red, Color.DarkRed);
        }
        private void TcComVer3_Click(Object sender, EventArgs e)
        {
            _writeTcComModuleVersion("0.0.0.3");
            ChangeChannelSettings(Color.Blue, Color.DarkBlue);
        }
        private void TcComVer4_Click(Object sender, EventArgs e)
        {
            _writeTcComModuleVersion("0.0.0.4");
            ChangeChannelSettings(Color.Purple, Color.DarkMagenta);
        }
        private void TcComVer5_Click(Object sender, EventArgs e)
        {
            _writeTcComModuleVersion("0.0.0.5");
            ChangeChannelSettings(Color.Aqua, Color.Aquamarine);
        }

        private void _writeTcComModuleVersion(string TcComVersion)
        {
            try
            {
                tcClient.WriteAnyString(tcCOM_indexGroup, tcCOM_indexOffset, tmcVendorInfo_Name + tmcVersionedClassfactory_Name + TcComVersion, 127, Encoding.Default);

            }
            catch (AdsException ex)
            {
                MessageBox.Show("Failed to write the TcCom Version to the Target" + "\n" + "LibraryID: " + TcComVersion + "\n\n" + "Exception: " + ex.Message);
            }
        }

        private async Task AdsSymbolUpdate()
        {
            var token = _cts.Token;
            var runner = true;


            await Task.Run(() =>
            {
                while (runner)
                {
                    try
                    {
                        if (_cts.IsCancellationRequested)
                            runner = false;
                        else
                            this.Invoke(new Action(() => UpdateSymbols()));
                    }
                    catch
                    {
                        MessageBox.Show("Thread Stopped");
                        if (_cts != null)
                            _cts.Cancel();
                    }               
                    Thread.Sleep(20);
                }
            });
        }

        private void AdsDisconnect()
        {
            try
            {
                if (_cts != null)
                    _cts.Cancel();

                if (tcClient != null)
                {
                    tcClient.Disconnect();
                    tcClientTaskValues.Disconnect();
                }

                UI_Disconnected();
                Stop_Scope();
            }
            catch (AdsException ex)
            {
                Console.WriteLine("Connection does not exist...\n\n\nException: " + ex.Message);
            }
        }

        private void UpdateSymbols()
        {
            try
            {
                // Read Loaded TcCOM
                labelTcComStatus.Text = tcClient.ReadAnyString(tcCOM_indexGroup, tcCOM_indexOffset, 255, Encoding.Default);

                // Read an UINT32 Value
                tcClientTaskValues.Read(task_indexGroup, task_indexOffset, readStream, 0, 8);
                readStream.Position = 0;
                labelSignalValue.Text = reader.ReadDouble().ToString();
            }
            catch
            {
                MessageBox.Show("Correct symbols not accessible...");
                if (_cts != null)
                {
                    _cts.Cancel();
                    AdsDisconnect();
                }
            }
        }

            private void UI_Connected()
        {
            btnAdsConnect.Enabled = false;
            btnAdsDisconnect.Enabled = true;
            btnTcComVer1.Enabled = true;
            btnTcComVer2.Enabled = true;
            btnTcComVer3.Enabled = true;
            btnTcComVer4.Enabled = true;
            btnTcComVer5.Enabled = true;
            checkBoxAdsLocal.Enabled = false;
            comboBoxAdsTargets.Enabled = false;
        }

        private void UI_Disconnected()
        {
            btnAdsConnect.Enabled = true;
            btnAdsDisconnect.Enabled = false;
            btnTcComVer1.Enabled = false;
            btnTcComVer2.Enabled = false;
            btnTcComVer3.Enabled = false;
            btnTcComVer4.Enabled = false;
            btnTcComVer5.Enabled = false;
            checkBoxAdsLocal.Enabled = true;
            if (checkBoxAdsLocal.Checked)
                comboBoxAdsTargets.Enabled = false;
            else
                comboBoxAdsTargets.Enabled = true;
            labelTcComStatus.Text = "Disconnected";
        }

        private void CppOnlineDash_Load(object sender, EventArgs e)
        {

        }
    }
}
