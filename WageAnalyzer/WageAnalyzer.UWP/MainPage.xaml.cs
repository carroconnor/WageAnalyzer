﻿namespace WageAnalyzer.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            string dbPath = FileAccessHelper.GetLocalFilePath("WageAnalyzer.db3");
            LoadApplication(new WageAnalyzer.App(dbPath));
        }
    }
}
