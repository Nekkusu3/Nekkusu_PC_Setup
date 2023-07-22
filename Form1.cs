// Decompiled with JetBrains decompiler
// Type: Nekkusu_PC_Setup.Form1
// Assembly: Nekkusu PC Setup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5404176C-4BC5-4E75-BF07-CBC8F848C4FF
// Assembly location: D:\User\Documents\server, code etc\Programme\Nekkusu PC Setup.exe

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nekkusu_PC_Setup
{
  public class Form1 : Form
  {
    public bool safetyRegistry;
    public bool GroupPolicyButton;
    public bool DocumentsButton;
    public bool ExplorerOpen;
    public int DownloadCounter;
    public string selectedDrive;
    public string userpath;
    public string userpathDownloads;
    public string DownloadPathNew;
    public string PicturePathNew;
    public string VideoPathNew;
    public string DesktopPathNew;
    public string MusicPathNew;
    public string DocumentsPathNew;
    public string RegistryPathEZ;
    public string RegistryPathEZ2;
    public string DownloadFolder;
    public string ExeFolderLocation;
    private IContainer components = (IContainer) null;
    private Button chromebutton;
    private Button steambutton;
    private Button geforcebutton;
    private Button ooabpbutton;
    private Button teambutton;
    private Button nekkusuttt;
    private Button discordbutton1;
    private Button lolbutton;
    private Button dsbutton;
    private Button pcsxbutton;
    private Button corsairicuebutton;
    private Button grouppolicy;
    private ListBox listBox1;
    private Button button14;
    private Button safetyregistrybutton;
    private RichTextBox richTextBox1;
    private ProgressBar progressBar1;

    public Form1()
    {
      this.InitializeComponent();
      this.safetyRegistry = true;
      string element = "documents\\";
      string[] logicalDrives = Environment.GetLogicalDrives();
      ((IEnumerable<string>) logicalDrives).Append<string>(element);
      this.listBox1.Items.AddRange((object[]) logicalDrives);
      this.RegistryPathEZ = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders";
      this.RegistryPathEZ2 = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Folders";
      this.DownloadFolder = Registry.CurrentUser.OpenSubKey(this.RegistryPathEZ, true).GetValue("{374DE290-123F-4565-9164-39C4925E467B}").ToString();
      this.ExeFolderLocation = Directory.GetCurrentDirectory();
    }

    public void Drives_selected(object sender, EventArgs e)
    {
      this.selectedDrive = this.listBox1.SelectedItem.ToString();
      this.userpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
      this.userpathDownloads = this.userpath + "\\downloads";
      this.DownloadPathNew = this.selectedDrive + "Downloads";
      this.PicturePathNew = this.selectedDrive + "Pictures";
      this.VideoPathNew = this.selectedDrive + "Videos";
      this.DesktopPathNew = this.selectedDrive + "Desktop";
      this.MusicPathNew = this.selectedDrive + "Music";
      this.DocumentsPathNew = this.selectedDrive + "Documents";
      RegistryKey registryKey1 = Registry.CurrentUser.OpenSubKey(this.RegistryPathEZ, true);
      RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey(this.RegistryPathEZ2, true);
      this.DirectoryCreator();
      if (!this.safetyRegistry)
      {
        registryKey1.SetValue("{374DE290-123F-4565-9164-39C4925E467B}", (object) this.DownloadPathNew);
        registryKey2.SetValue("{374DE290-123F-4565-9164-39C4925E467B}", (object) this.DownloadPathNew);
        registryKey1.SetValue("{0DDD015D-B06C-45D5-8C4C-F59713854639}", (object) this.PicturePathNew);
        registryKey2.SetValue("{0DDD015D-B06C-45D5-8C4C-F59713854639}", (object) this.PicturePathNew);
        registryKey1.SetValue("My Pictures", (object) this.PicturePathNew);
        registryKey2.SetValue("My Pictures", (object) this.PicturePathNew);
        registryKey1.SetValue("{35286A68-3C57-41A1-BBB1-0EAE73D76C95}", (object) this.VideoPathNew);
        registryKey2.SetValue("{35286A68-3C57-41A1-BBB1-0EAE73D76C95}", (object) this.VideoPathNew);
        registryKey1.SetValue("My Video", (object) this.VideoPathNew);
        registryKey2.SetValue("My Video", (object) this.VideoPathNew);
        registryKey1.SetValue("{754AC886-DF64-4CBA-86B5-F7FBF4FBCEF5}", (object) this.DesktopPathNew);
        registryKey2.SetValue("{754AC886-DF64-4CBA-86B5-F7FBF4FBCEF5}", (object) this.DesktopPathNew);
        registryKey1.SetValue("Desktop", (object) this.DesktopPathNew);
        registryKey2.SetValue("Desktop", (object) this.DesktopPathNew);
        registryKey1.SetValue("{A0C69A99-21C8-4671-8703-7934162FCF1D}", (object) this.MusicPathNew);
        registryKey2.SetValue("{A0C69A99-21C8-4671-8703-7934162FCF1D}", (object) this.MusicPathNew);
        registryKey1.SetValue("My Music", (object) this.MusicPathNew);
        registryKey2.SetValue("My Music", (object) this.MusicPathNew);
        if (this.DocumentsButton)
        {
          registryKey1.SetValue("{F42EE2D3-909F-4907-8871-4C22FC0BF756}", (object) this.DocumentsPathNew);
          registryKey2.SetValue("{F42EE2D3-909F-4907-8871-4C22FC0BF756}", (object) this.DocumentsPathNew);
          registryKey1.SetValue("Personal", (object) this.DocumentsPathNew);
          registryKey2.SetValue("Personal", (object) this.DocumentsPathNew);
        }
        Process.Start("shutdown", "/r /t 0");
      }
      else if (this.safetyRegistry)
      {
        int num = (int) MessageBox.Show("safety is on!");
      }
      this.DownloadFolder = Registry.CurrentUser.GetValue(this.RegistryPathEZ, (object) "{374DE290-123F-4565-9164-39C4925E467B}").ToString();
    }

    public void Safetyregistrybutton_click(object sender, EventArgs e)
    {
      if (this.safetyRegistry)
      {
        this.safetyregistrybutton.Text = "Unsafe";
        this.safetyRegistry = false;
      }
      else
      {
        if (this.safetyRegistry)
          return;
        this.safetyregistrybutton.Text = "Safe";
        this.safetyRegistry = true;
      }
    }

    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) => this.progressBar1.Value = e.ProgressPercentage;

    private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
    {
      Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
      --this.DownloadCounter;
      if (this.DownloadCounter == 0)
        this.ResetDelay();
      else
        --this.DownloadCounter;
    }

    private async Task ResetDelay()
    {
      await Task.Delay(3000);
      this.Resetprogressbar();
    }

    private void Resetprogressbar() => this.progressBar1.Value = 0;

    public void ChromeButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\ChromeSetup.exe"))
        {
          this.chromebutton.Text = "Downloaded Google Chrome";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://harambe.ch/ChromeSetup.exe"; 
          string fileName = this.DownloadFolder + "\\ChromeSetup.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.ChromeButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.chromebutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void SteamButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\SteamSetup.exe"))
        {
          this.steambutton.Text = "Downloaded Steam";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://steamcdn-a.akamaihd.net/client/installer/SteamSetup.exe";
          string fileName = this.DownloadFolder + "\\SteamSetup.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.SteamButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.steambutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void GeForceButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\GeForceExperience.exe"))
        {
          this.geforcebutton.Text = "Downloaded GeForceExperience";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://de.download.nvidia.com/GFE/GFEClient/3.20.4.14/GeForce_Experience_v3.20.4.14.exe";
          string fileName = this.DownloadFolder + "\\GeForce_Experience.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.GeForceButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.geforcebutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void OOAPBButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\OOAPB.exe"))
        {
          this.ooabpbutton.Text = "Downloaded OOAPB";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://dl5.oo-software.com/files/ooappbuster/OOAPB.exe";
          string fileName = this.DownloadFolder + "\\OOAPB.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.OOAPButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.ooabpbutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void TeamViewerButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\TeamViewer_Setup.exe"))
        {
          this.teambutton.Text = "Downloaded TeamViewer";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://download.teamviewer.com/download/TeamViewer_Setup.exe";
          string fileName = this.DownloadFolder + "\\TeamViewer_Setup.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.TeamViewerButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.teambutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void CSSContentNekkusuButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\TTTCSSContent.exe"))
        {
          this.nekkusuttt.Text = "Downloaded TTTCSSContent";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://harambe.ch/TTT%20CSSContent69.exe";
          string fileName = this.DownloadFolder + "\\TTTCSSContent.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.TTTCSSContentButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.nekkusuttt.Text = "Download failed! Restart the programm.";
      }
    }

    private void DiscordButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\DiscordSetup.exe"))
        {
          this.discordbutton1.Text = "Downloaded Discord";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://discord.com/api/download?platform=win";
          string fileName = this.DownloadFolder + "\\DiscordSetup.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DiscordButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.discordbutton1.Text = "Download failed! Restart the programm.";
      }
    }

    private void LeagueButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\LoLInstaller.exe"))
        {
          this.lolbutton.Text = "Downloaded LoL";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://lol.secure.dyn.riotcdn.net/channels/public/x/installer/current/live.na.exe";
          string fileName = this.DownloadFolder + "\\LoLInstaller.exe";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.LeagueButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.lolbutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void DS4Button_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\DS4Windows.zip"))
        {
          this.dsbutton.Text = "Downloaded DS4";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://github.com/Jays2Kings/DS4Windows/releases/download/v1.4.52/DS4Windows.zip";
          string fileName = this.DownloadFolder + "\\DS4Windows.zip";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DS4ButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.dsbutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void PCSX2Button_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\PCSX2.zip"))
        {
          this.pcsxbutton.Text = "Downloaded PCSX2";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://www.harambe.ch/pcsx2.zip";
          string fileName = this.DownloadFolder + "\\PCSX2.zip";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.PCSX2ButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.pcsxbutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void ICueButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\iCueSetup.msi"))
        {
          this.corsairicuebutton.Text = "Downloaded iCue";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "http://downloads.corsair.com/Files/CUE/iCUESetup_3.31.81_release.msi";
          string fileName = this.DownloadFolder + "\\iCueSetup.msi";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.ICueButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.corsairicuebutton.Text = "Download failed! Restart the programm.";
      }
    }

    private void GroupPolicyButton_click(object sender, EventArgs e)
    {
      try
      {
        if (System.IO.File.Exists(this.DownloadFolder + "\\gpmsc.msi"))
        {
          this.grouppolicy.Text = "Downloaded GPE";
          Process.Start("file://" + this.DownloadFolder, this.DownloadFolder);
        }
        else
        {
          WebClient webClient = new WebClient();
          string uriString = "https://www.microsoft.com/en-us/download/confirmation.aspx?id=21895";
          string fileName = this.DownloadFolder + "\\gpmsc.msi";
          ++this.DownloadCounter;
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownloadCompleted);
          webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.GPEButtonText);
          webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
          webClient.DownloadFileAsync(new Uri(uriString), fileName);
        }
      }
      catch
      {
        this.corsairicuebutton.Text = "Download failed! Restart the programm.";
      }
    }

    public void DirectoryCreator()
    {
      if (!Directory.Exists(this.DownloadPathNew))
        Directory.CreateDirectory(this.DownloadPathNew);
      if (!Directory.Exists(this.PicturePathNew))
        Directory.CreateDirectory(this.PicturePathNew);
      if (!Directory.Exists(this.VideoPathNew))
        Directory.CreateDirectory(this.VideoPathNew);
      if (!Directory.Exists(this.DesktopPathNew))
        Directory.CreateDirectory(this.DesktopPathNew);
      if (!Directory.Exists(this.MusicPathNew))
        Directory.CreateDirectory(this.MusicPathNew);
      if (Directory.Exists(this.DocumentsPathNew))
        return;
      Directory.CreateDirectory(this.DocumentsPathNew);
    }

    public void Documents_click(object sender, EventArgs e)
    {
      if (!this.DocumentsButton)
      {
        this.DocumentsButton = true;
      }
      else
      {
        if (!this.DocumentsButton)
          return;
        this.DocumentsButton = true;
      }
    }

    private void ChromeButtonText(object sender, AsyncCompletedEventArgs e) => this.chromebutton.Text = "Downloaded Google Chrome";

    private void SteamButtonText(object sender, AsyncCompletedEventArgs e) => this.steambutton.Text = "Downloaded Steam";

    private void GeForceButtonText(object sender, AsyncCompletedEventArgs e) => this.geforcebutton.Text = "Downloaded GeForce Experience";

    private void OOAPButtonText(object sender, AsyncCompletedEventArgs e) => this.ooabpbutton.Text = "Downloaded OOABP";

    private void TeamViewerButtonText(object sender, AsyncCompletedEventArgs e) => this.teambutton.Text = "Downloaded TeamViewer";

    private void TTTCSSContentButtonText(object sender, AsyncCompletedEventArgs e) => this.nekkusuttt.Text = "Downloaded TTTCSSContent";

    private void DiscordButtonText(object sender, AsyncCompletedEventArgs e) => this.discordbutton1.Text = "Downloaded Discord";

    private void LeagueButtonText(object sender, AsyncCompletedEventArgs e) => this.lolbutton.Text = "Downloaded LoL";

    private void DS4ButtonText(object sender, AsyncCompletedEventArgs e) => this.dsbutton.Text = "Downloaded DS4";

    private void PCSX2ButtonText(object sender, AsyncCompletedEventArgs e) => this.pcsxbutton.Text = "Downloaded PCSX2";

    private void ICueButtonText(object sender, AsyncCompletedEventArgs e) => this.corsairicuebutton.Text = "Downloaded iCue";

    private void GPEButtonText(object sender, AsyncCompletedEventArgs e) => this.grouppolicy.Text = "Downloaded GPE";

    private void Richtextbox1_click(object sender, EventArgs e) => Process.Start("http://www.harambe.ch");

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.chromebutton = new Button();
      this.steambutton = new Button();
      this.geforcebutton = new Button();
      this.ooabpbutton = new Button();
      this.teambutton = new Button();
      this.nekkusuttt = new Button();
      this.discordbutton1 = new Button();
      this.lolbutton = new Button();
      this.dsbutton = new Button();
      this.pcsxbutton = new Button();
      this.corsairicuebutton = new Button();
      this.grouppolicy = new Button();
      this.listBox1 = new ListBox();
      this.button14 = new Button();
      this.safetyregistrybutton = new Button();
      this.richTextBox1 = new RichTextBox();
      this.progressBar1 = new ProgressBar();
      this.SuspendLayout();
      this.chromebutton.Location = new Point(30, 26);
      this.chromebutton.Name = "chromebutton";
      this.chromebutton.Size = new Size(200, 80);
      this.chromebutton.TabIndex = 0;
      this.chromebutton.Text = "Google Chrome";
      this.chromebutton.UseVisualStyleBackColor = true;
      this.chromebutton.Click += new EventHandler(this.ChromeButton_click);
      this.steambutton.Location = new Point(260, 26);
      this.steambutton.Name = "steambutton";
      this.steambutton.Size = new Size(200, 80);
      this.steambutton.TabIndex = 1;
      this.steambutton.Text = "Steam";
      this.steambutton.UseVisualStyleBackColor = true;
      this.steambutton.Click += new EventHandler(this.SteamButton_click);
      this.geforcebutton.Location = new Point(490, 26);
      this.geforcebutton.Name = "geforcebutton";
      this.geforcebutton.Size = new Size(200, 80);
      this.geforcebutton.TabIndex = 2;
      this.geforcebutton.Text = "GeForceExperience";
      this.geforcebutton.UseVisualStyleBackColor = true;
      this.geforcebutton.Click += new EventHandler(this.GeForceButton_click);
      this.ooabpbutton.Location = new Point(720, 26);
      this.ooabpbutton.Name = "ooabpbutton";
      this.ooabpbutton.Size = new Size(200, 80);
      this.ooabpbutton.TabIndex = 3;
      this.ooabpbutton.Text = "OOABP";
      this.ooabpbutton.UseVisualStyleBackColor = true;
      this.ooabpbutton.Click += new EventHandler(this.OOAPBButton_click);
      this.teambutton.Location = new Point(490, 116);
      this.teambutton.Name = "teambutton";
      this.teambutton.Size = new Size(200, 80);
      this.teambutton.TabIndex = 4;
      this.teambutton.Text = "TeamViewer";
      this.teambutton.UseVisualStyleBackColor = true;
      this.teambutton.Click += new EventHandler(this.TeamViewerButton_click);
      this.nekkusuttt.Location = new Point(260, 116);
      this.nekkusuttt.Name = "nekkusuttt";
      this.nekkusuttt.Size = new Size(200, 80);
      this.nekkusuttt.TabIndex = 5;
      this.nekkusuttt.Text = "Nekkusu TTT";
      this.nekkusuttt.UseVisualStyleBackColor = true;
      this.nekkusuttt.Click += new EventHandler(this.CSSContentNekkusuButton_click);
      this.discordbutton1.Location = new Point(30, 116);
      this.discordbutton1.Name = "discordbutton1";
      this.discordbutton1.Size = new Size(200, 80);
      this.discordbutton1.TabIndex = 6;
      this.discordbutton1.Text = "Discord";
      this.discordbutton1.UseVisualStyleBackColor = true;
      this.discordbutton1.Click += new EventHandler(this.DiscordButton_click);
      this.lolbutton.Location = new Point(720, 116);
      this.lolbutton.Name = "lolbutton";
      this.lolbutton.Size = new Size(200, 80);
      this.lolbutton.TabIndex = 7;
      this.lolbutton.Text = "League of Legends";
      this.lolbutton.UseVisualStyleBackColor = true;
      this.lolbutton.Click += new EventHandler(this.LeagueButton_click);
      this.dsbutton.Location = new Point(30, 206);
      this.dsbutton.Name = "dsbutton";
      this.dsbutton.Size = new Size(200, 80);
      this.dsbutton.TabIndex = 8;
      this.dsbutton.Text = "DS4";
      this.dsbutton.UseVisualStyleBackColor = true;
      this.dsbutton.Click += new EventHandler(this.DS4Button_click);
      this.pcsxbutton.Location = new Point(260, 206);
      this.pcsxbutton.Name = "pcsxbutton";
      this.pcsxbutton.Size = new Size(200, 80);
      this.pcsxbutton.TabIndex = 9;
      this.pcsxbutton.Text = "PCSX2";
      this.pcsxbutton.UseVisualStyleBackColor = true;
      this.pcsxbutton.Click += new EventHandler(this.PCSX2Button_click);
      this.corsairicuebutton.Location = new Point(490, 206);
      this.corsairicuebutton.Name = "corsairicuebutton";
      this.corsairicuebutton.Size = new Size(200, 80);
      this.corsairicuebutton.TabIndex = 10;
      this.corsairicuebutton.Text = "iCue";
      this.corsairicuebutton.UseVisualStyleBackColor = true;
      this.corsairicuebutton.Click += new EventHandler(this.ICueButton_click);
      this.grouppolicy.Location = new Point(720, 206);
      this.grouppolicy.Name = "grouppolicy";
      this.grouppolicy.Size = new Size(200, 80);
      this.grouppolicy.TabIndex = 11;
      this.grouppolicy.Text = "GroupPolicy";
      this.grouppolicy.UseVisualStyleBackColor = true;
      this.grouppolicy.Click += new EventHandler(this.GroupPolicyButton_click);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 16;
      this.listBox1.Location = new Point(138, 444);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(120, 68);
      this.listBox1.TabIndex = 12;
      this.listBox1.SelectedIndexChanged += new EventHandler(this.Drives_selected);
      this.button14.Location = new Point(12, 476);
      this.button14.Name = "button14";
      this.button14.Size = new Size(107, 36);
      this.button14.TabIndex = 14;
      this.button14.Text = "Documents?";
      this.button14.UseVisualStyleBackColor = true;
      this.button14.Click += new EventHandler(this.Documents_click);
      this.safetyregistrybutton.Location = new Point(12, 421);
      this.safetyregistrybutton.Name = "safetyregistrybutton";
      this.safetyregistrybutton.Size = new Size(107, 36);
      this.safetyregistrybutton.TabIndex = 15;
      this.safetyregistrybutton.Text = "Safe";
      this.safetyregistrybutton.UseVisualStyleBackColor = true;
      this.safetyregistrybutton.Click += new EventHandler(this.Safetyregistrybutton_click);
      this.richTextBox1.Location = new Point(756, 483);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.Size = new Size(196, 70);
      this.richTextBox1.TabIndex = 16;
      this.richTextBox1.Text = "Made by Nekkusu\nMore at https://www.harambe.ch";
      this.richTextBox1.Click += new EventHandler(this.Richtextbox1_click);
      this.progressBar1.Location = new Point(13, 342);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(919, 30);
      this.progressBar1.TabIndex = 17;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(944, 548);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.richTextBox1);
      this.Controls.Add((Control) this.safetyregistrybutton);
      this.Controls.Add((Control) this.button14);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.grouppolicy);
      this.Controls.Add((Control) this.corsairicuebutton);
      this.Controls.Add((Control) this.pcsxbutton);
      this.Controls.Add((Control) this.dsbutton);
      this.Controls.Add((Control) this.lolbutton);
      this.Controls.Add((Control) this.discordbutton1);
      this.Controls.Add((Control) this.nekkusuttt);
      this.Controls.Add((Control) this.teambutton);
      this.Controls.Add((Control) this.ooabpbutton);
      this.Controls.Add((Control) this.geforcebutton);
      this.Controls.Add((Control) this.steambutton);
      this.Controls.Add((Control) this.chromebutton);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form1);
      this.Text = "Nekkusu PC Setup";
      this.ResumeLayout(false);
    }
  }
}
