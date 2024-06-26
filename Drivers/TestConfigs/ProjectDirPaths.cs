﻿using Newtonsoft.Json;
using PlayDemo1.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.NUnit.SpecFlowPlugin;

namespace PlayDemo1.Drivers.TestConfigs
{

    //public class TestPathConfigs
    //{
    //    public string? BrowserName { get; set; }
    //    public ChromiumOptions? ChromiumOptions { get; set; }
    //    public List<object>? FirefoxOptions { get; set; }
    //    public bool? HeadLess { get; set; }
    //}

    //public class ChromiumOptions
    //{
    //    public string? options1 { get; set; }
    //    public string? options2 { get; set; }
    //    public string? options3 { get; set; }

    //}

    public class ProjectDirPaths
    {
        public ProjectDirPaths()
        {
            Console.WriteLine("I am running");
            //var reportPath = "../../../Reports/screenshots";
            //if (!Directory.Exists(reportPath))
            //{
            //    new System.IO.DirectoryInfo(reportPath).Create();
            //}
        }

        public static string ProjectPath
        {
            get { return Directory.GetCurrentDirectory().Split("bin")[0]; }
        }

        private string? _reportPath;
        public static string ReportPath
        {
            get
            {
                var reportPath = ProjectPath + "Reports/screenshots";
                if (!Directory.Exists(reportPath))
                { new System.IO.DirectoryInfo(reportPath).Create(); }
                return ProjectPath + "Reports";
            }
        }
        public static string ScreenShotPath
        {
            get
            {
                var reportPath = ProjectPath + "Reports/screenshots";
                if (!Directory.Exists(reportPath))
                { new System.IO.DirectoryInfo(reportPath).Create(); }

                return ProjectPath + "Reports/screenshots/";
            }

        }

        //public static ConfigData GetConfigData
        //{
        //    get
        //    {
        //        var f = File.ReadAllText("AppConfig.json");
        //        ConfigData x = JsonConvert.DeserializeObject<ConfigData>(f)!;
        //        //Console.WriteLine($"{x.BrowserName}");
        //        return x;
        //    }
        //}

        





    }
}
