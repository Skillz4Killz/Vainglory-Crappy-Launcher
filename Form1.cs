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

    //Create & set connection
    private bool connection = true;

    //Create & set corrupted
    private bool corrupted = false;

    //Create DateTime
    private DateTime lastUpdate;

    //Create bytes
    private long lastBytes;

    //Create elapsed time counter
    private uint elapsedTime = 0;

    //Create time out counter
    private uint timeOut = 0;

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
      timer.Interval = 1000;

      //Start the timer
      timer.Start();
    }

    private void gameIsRunning(object sender, EventArgs e)
    {

      //On no connection
      if (!connection || timeOut > 10) 
      {

        //On Vainglory installer running
        if (System.Diagnostics.Process.GetProcessesByName("VainglorySetup").Length > 0)
        {

          //Create & set process
          var process = System.Diagnostics.Process.GetProcessesByName("VainglorySetup");

          //On installer corrupted
          if (process[0].MainWindowTitle == "NSIS Error" && corrupted != true)
          {

            //delete version.txt
            File.Delete("Version.txt");

            //Get local & release versions
            getVersions();

            //Set corrupted to true
            corrupted = true;
          }

          //Set play button text
          playButton.Text = "Installing";

          //Reset timeout
          timeOut = 0;
        }

        //Otherwise
        else
        {

          //Reset time out
          timeOut = 0;

          //Set play button text
          playButton.Text = "No connection";

          //Set install button text
          installButton.Text = "Check for connection";

          //Set label
          downloadLabel.Text = "Connection timeout (Waiting for reconnection)";

          //Enable install button
          installButton.Enabled = true;

          //Set connection to false
          connection = false;

          //On installer exists
          if (File.Exists("VainglorySetup.exe"))
          {

            //Set install button text
            installButton.Text = "Try to install";

            //Set connection to true
            connection = true;
          }

          //Dispose the timer
          timer.Dispose();
        }
      }

      //Otherwise on Vainglory app running
      else if (System.Diagnostics.Process.GetProcessesByName("Vainglory").Length > 0)
      {

        //Set play button text
        playButton.Text = "Running";

        //Reset timeout
        timeOut = 0;
      }

      //Otherwise on Vainglory installer running
      else if(System.Diagnostics.Process.GetProcessesByName("VainglorySetup").Length > 0)
      {

        //Create & set process
        var process = System.Diagnostics.Process.GetProcessesByName("VainglorySetup");

        //On installer corrupted
        if (process[0].MainWindowTitle == "NSIS Error" && corrupted != true)
        {

          //delete version.txt
          File.Delete("Version.txt");

          //Get local & release versions
          getVersions();

          //Set corrupted to true
          corrupted = true;
        }

        //Set play button text
        playButton.Text = "Installing";

        //Reset timeout
        timeOut = 0;
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

            //Set bytes to 0
            lastBytes = 0;

            //Set dateTime
            lastUpdate = DateTime.Now;

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

          //Set install button text
          installButton.Text = "Install";

          //On installer exists
          if (File.Exists("VainglorySetup.exe"))
          {

            //Set install button text
            installButton.Text = "Install";

            //enable play button
            installButton.Enabled = true;
          }

          //Dispose the timer
          timer.Dispose();

          timeOut = 0;
        }

        //Otherwise
        else
        {

          //Set play button text
          playButton.Text = "Downloading update";
        }
      }


      //Add to timeout
      ++timeOut;
    }

    private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {

      //Disable install button
      installButton.Enabled = false;

      //ON timer disabled
      if(!timer.Enabled)
      {

        //Start timer
        timer.Start();

        //Get local & release versions
        getVersions();
      }

      //On 100 ticks
      if (elapsedTime > 50)
      {

        //On no last bytes
        if (lastBytes == 0)
        {

          //Set last bytes as the bytes received
          lastBytes = e.BytesReceived;
        }

        //Create & set actual date time
        var now = DateTime.Now;

        //Create & set the timespan
        var timeSpan = now - lastUpdate;

        //Create & set the bytes changed
        var bytesChange = e.BytesReceived - lastBytes;

        //Get bytes downloaded and convert to gigabytes
        var downloaded = e.BytesReceived / 1048576;

        var total = e.TotalBytesToReceive / 1048576;

        //Create & set the bytes per second
        var bytesPerSecond = bytesChange / timeSpan.TotalSeconds;

        //Set the last bytes as the bytes received
        lastBytes = e.BytesReceived;

        //Set the last update as the actual date time
        lastUpdate = now;

        //Update the progress bar
        progressBar.Value = e.ProgressPercentage;

        //Set the download label text
        downloadLabel.Text = e.ProgressPercentage.ToString() + "% " + 
          (bytesPerSecond / 1048576).ToString("f2") + " MB/s | " + downloaded.ToString() +
          "MB/" + total.ToString() + "MB";

        //Reset elapsed time
        elapsedTime = 0;

        //Reset timeout
        timeOut = 0;
      }

      //Add to elapsed time
      ++elapsedTime;

    }

    private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {

      //Download is completed
      downloadStarted = false;

      //Set download text
      downloadLabel.Text = "Download Completed!";

      //Write the release number on file
      File.WriteAllText("version.txt", release);

      //Dispose timer
      timer.Dispose();

      //Try to start the installation
      try
      {

      //Start the setup
      System.Diagnostics.Process.Start("VainglorySetup.exe");
      }

      //if install failed (canceled by user or something else)
      catch
      {
        //Do nothing
      }

      //Get the release and local versions
      getVersions();

      //Reset timeout
      timeOut = 0;

      //Start timer
      timer.Start();
    }

    private void getVersions()
    {

      //Clear change log
      changeLogs.Clear();

      //Set url
      var urlAddress = @"https://www.vainglorygame.com/crossplatform/";

      //Create & set the htmlWeb
      HtmlWeb web = new HtmlWeb();

      //Try to make the html info fetch
      try
      {

        //Create & set the html document
        var htmlDoc = web.Load(urlAddress);

        //On load made
        connection = true;

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

        //Set initial text for change logs
        changeLogs.Text = "What's new on this release:\n\n";

        //Get all the logs
        foreach (var node in changeLog.Elements("li"))
        {

          //Set the log box
          changeLogs.Text += "- " + node.InnerText + "\n\n";
        }


      }

      //On a info fetch fail
      catch
      {

        //Set connection to false
        connection = false;

        //Set the label
        releaseLabel.Text = "Release version: NAN";
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
        "Version 1.1.0 - By starfoxcom",
        "About Vainglory Crappy Launcher",
        buttons);
    }

    private void playButton_Click(object sender, EventArgs e)
    {

      //Try to start the game
      try
      {

      //Start the game
      System.Diagnostics.Process.Start("Vainglory.exe");
      }

      //If game start failed
      catch
      {

        //Try to start the installation
        try
        {

          //Start the setup
          System.Diagnostics.Process.Start("VainglorySetup.exe");
        }

        //if install failed
        catch
        {
          //Delete version.txt, since installer doesn't exist
          //Don't know why user has the version.txt
          File.Delete("version.txt");

          //Get local & release versions
          getVersions();
        }
      }

      //Disable play button
      playButton.Enabled = false;

      //Disable install button
      installButton.Enabled = false;

      //Init timer
      initTimer();
    }

    private void installButton_Click(object sender, EventArgs e)
    {

      //On connection
      if(connection)
      {

        //Try to start the installation
        try
        {

          //Start the setup
          System.Diagnostics.Process.Start("VainglorySetup.exe");
        }

        //if install failed
        catch
        {
          //Do nothing
        }
      }

      //Disable play button
      playButton.Enabled = false;

      //Disable install button
      installButton.Enabled = false;

      //Get local and release versions
      getVersions();

      //Init timer
      initTimer();
    }
  }
}
