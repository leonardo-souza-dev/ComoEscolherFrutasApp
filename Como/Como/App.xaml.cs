using Como;
using Como.Data;
using Como.Model;
using Como.View;
using Como.ViewModel;

using Xamarin.Forms;

namespace Como
{
    public partial class App : Application
    {
        static ComoDb database;

        public static DicaViewModel FrutasVM { get; set; }
        public static ConfiguracaoApp Config { get; set; }

        private IRepository[] repositories;
        private RepositoryIterator repositoryIterator;


        public App()
        {
            InitializeComponent();

            Config = new ConfiguracaoApp();

            DeviceRepository deviceRepository = new DeviceRepository();
            CloudRepository cloudRepository = new CloudRepository();

            repositories = new IRepository[2];
            repositories[0] = deviceRepository;
            repositories[1] = cloudRepository;
            repositoryIterator = new RepositoryIterator(repositories);


            FrutasVM = new DicaViewModel(repositoryIterator);
            MainPage = new DicasView();

        }

        public static ComoDb Database
        {
            get
            {
                if (database == null)
                {
                    var path = DependencyService.Get<IFileHelper>().GetLocalFilePath("ComoDbSQLite.db3");
                    database = new ComoDb(path);
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
