﻿using System;
using System.Threading.Tasks;
using Builtcode.Doctor.UI.Mobile.Services;
using Builtcode.Doctor.UI.Mobile.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using DryIoc;
using Prism.DryIoc;
using Prism.Logging;
using Xamarin.Forms;

using DebugLogger = Builtcode.Doctor.UI.Mobile.Services.DebugLogger;

namespace Builtcode.Doctor.UI.Mobile
{
    public partial class App : PrismApplication
    {
        /* 
         * NOTE: 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() 
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            LogUnobservedTaskExceptions();

            await NavigationService.NavigateAsync("SplashScreenPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register the Popup Plugin Navigation Service
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterInstance(CreateLogger());
            
            containerRegistry.RegisterInstance(CreateMedicoService());
            containerRegistry.RegisterInstance(CreatePacienteService());
            
            containerRegistry.RegisterInstance(CreateRestService());
            containerRegistry.RegisterInstance(CreateSynchManager());
            

            // Navigating to "TabbedPage?createTab=ViewA&createTab=ViewB&createTab=ViewC will generate a TabbedPage
            // with three tabs for ViewA, ViewB, & ViewC
            // Adding `selectedTab=ViewB` will set the current tab to ViewB
            containerRegistry.RegisterForNavigation<TabbedPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<SplashScreenPage>();
            containerRegistry.RegisterForNavigation<TodoItemDetail>();
            
            containerRegistry.RegisterForNavigation<MedicoPage>();
            containerRegistry.RegisterForNavigation<MedicoDetail>();
            
            containerRegistry.RegisterForNavigation<PacientePage>();
            containerRegistry.RegisterForNavigation<PacienteDetail>();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle IApplicationLifecycle
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle IApplicationLifecycle
            base.OnResume();

            // Handle when your app resumes
            System.Diagnostics.Debug.Print("Resume");

            Container.Resolve<ISynchManager>().SaveBackendAsync();

        }

        private ILoggerFacade CreateLogger() => new DebugLogger();
        private  IMedicoService CreateMedicoService() => new MedicoService();
        private  IPacienteService CreatePacienteService() => new PacienteService();
        private  IRestService CreateRestService() => new RestService();
        private  ISynchManager CreateSynchManager() => new SynchManager(new RestService(), new  MedicoService(), new PacienteService());
        
        

        private void LogUnobservedTaskExceptions()
        {
            TaskScheduler.UnobservedTaskException += ( sender, e ) =>
            {
                Container.Resolve<ILoggerFacade>().Log(e.Exception);
            };
        }
    }
}
