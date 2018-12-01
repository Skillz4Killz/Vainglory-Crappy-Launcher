using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;
using System.Net;


namespace Vainglory_Updater_Tool
{
  public partial class Form1 : Form
  {

    //Create timer
    private Timer timer;

    //Create release, local and donwloadLink strings
    private string release, local, downloadLink;

    //Create & set downloadStarted bool
    private bool downloadStarted = false;

    public Form1()
    {

      //Init component
      InitializeComponent();

      //Disable play button
      playButton.Enabled = false;

      //Disable install button
      installButton.Enabled = false;

      //Get the release & local versions
      getVersions();

      //Init timer
      initTimer();

    }
    
    private void initTimer()
    {

      //Create new timer
      timer = new Timer();

      //Add tick with event handler
      timer.Tick += new EventHandler(gameIsRunning);

      //Set the timer interval
      timer.Interval = 100;

      //Start the timer
      timer.Start();
    }

    private void gameIsRunning(object sender, EventArgs e)
    {

      //On no connection
      if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
      {

        //Set play button text
        playButton.Text = "No connection";
      }

      //Otherwise on Vainglory app running
      else if (System.Diagnostics.Process.GetProcessesByName("Vainglory").Length > 0)
      {

        //Set play button text
        playButton.Text = "Running";
      }

      //Otherwise on Vainglory installer running
      else if(System.Diagnostics.Process.GetProcessesByName("VainglorySetup").Length > 0)
      {

        //Set play button text
        playButton.Text = "Installing";
      }

      //Otherwise
      else
      {

        //On release is different than local, then update
        if (downloadStarted != true && release != local)
        {

          //Set play button text
          playButton.Text = "Downloading update";

          //Download the installer
          using (WebClient wc = new WebClient())
          {

            //Check progress
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;

            //Check if download is completed
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;

            //Start download asynchronously
            wc.DownloadFileAsync(
                // Param1 = Link of file
                new Uri(downloadLink),
                // Param2 = Path to save
                "VainglorySetup.exe"
            );

            //Set bool to true
            downloadStarted = true;
          }
        }

        //Otherwise on release number is equal to local
        else if(release == local)
        {

          //enable play button
          playButton.Enabled = true;

          //set play button text
          playButton.Text = "Play";

          //On installer exists
          if (File.Exists("VainglorySetup.exe"))
          {

            //enable play button
            installButton.Enabled = true;
          }

          //Dispose the timer
          timer.Dispose();
        }
      }
    }

    private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {

      //Update the progress bar
      progressBar.Value = e.ProgressPercentage;

      //Set the download label text
      downloadLabel.Text = e.ProgressPercentage.ToString();
    }

    private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {

      //Write the release number on file
      File.WriteAllText("version.txt", release);

      //Start the setup
      System.Diagnostics.Process.Start("VainglorySetup.exe");

      //Get the release and local versions
      getVersions();
    }

    private void getVersions()
    {

      //Clear change log
      changeLogs.Clear();

      //Set url
      var urlAddress = @"https://www.vainglorygame.com/crossplatform/";

      //Create & set the htmlWeb
      HtmlWeb web = new HtmlWeb();

      //Create & set the html document
      var htmlDoc = web.Load(urlAddress);

      //Create & set the html node
      var htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//small/b");

      //Create & set the download link
      var htmlLink = htmlDoc.DocumentNode.SelectNodes("//p/a");

      //Loop through all nodes in htmlLink
      foreach (var nodes in htmlLink)
      {

        //On inner text is for windows
        if (nodes.InnerText == "Download for Windows")
        {

          //Set the download link
          downloadLink = nodes.Attributes["href"].Value;
        }
      }

      //Set the release version
      release = htmlNode.InnerText;

      //Set the label
      releaseLabel.Text = "Release version: " + release;

      //Create & set the change logs
      var changeLog = htmlDoc.DocumentNode.SelectNodes("//section/div/div/div/div/ul").First();

      //Get all the logs
      foreach (var node in changeLog.Elements("li"))
      {

        //Set the log box
        changeLogs.Text += node.InnerText + "\n\n";
      }

      //On file don't exist 
      if (!File.Exists("version.txt"))
      {

        //Create the file and write the release version on it, then close it
        using (File.Create("version.txt")) { } 

        //Get the last local version
        local = File.ReadAllText("version.txt");

        //Set label
        localLabel.Text = "Local version: " + local;
      }

      //Otherwise the file exists
      else
      {

        //Get the last local version
        local = File.ReadAllText("version.txt");

        //Set label
        localLabel.Text = "Local version: " + local;
      }
    }

    private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
    {

      //Create & set message buttons
      MessageBoxButtons buttons = MessageBoxButtons.OK;

      //Create & set the dialog to show
      DialogResult result = MessageBox.Show(
        "Version 1.0.0 - By starfoxcom",
        "About Vainglory Crappy Launcher",
        buttons);
    }

    private void playButton_Click(object sender, EventArgs e)
    {

      //Start the game
      System.Diagnostics.Process.Start("Vainglory.exe");

      //Disable play button
      playButton.Enabled = false;

      //Disable install button
      installButton.Enabled = false;

      //Init timer
      initTimer();
    }

    private void installButton_Click(object sender, EventArgs e)
    {

      //Start the setup
      System.Diagnostics.Process.Start("VainglorySetup.exe");

      //Disable play button
      playButton.Enabled = false;

      //Disable install button
      installButton.Enabled = false;

      //Init timer
      initTimer();
    }
  }
}
