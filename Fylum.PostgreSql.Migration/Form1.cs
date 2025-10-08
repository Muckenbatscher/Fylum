using Fylum.Connection;
using Fylum.PostgreSql.Migration.Domain;
using M2TWinForms;

namespace Fylum.PostgreSql.Migration
{
    public partial class Form1 : M2TForm
    {
        private readonly IOpenedConnectionProvider _openedConnectionProvider;
        private readonly IMigrationsProvider _migrationsProvider;

        private Form1()
        {
            InitializeComponent();
        }

        public Form1(IOpenedConnectionProvider openedConnectionProvider, 
            IMigrationsProvider migrationsProvider) : this()
        {
            _openedConnectionProvider = openedConnectionProvider;
            _migrationsProvider = migrationsProvider;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var a = _openedConnectionProvider.GetOpenedConnection();
            var b = _migrationsProvider.GetMigrations();
        }
    }
}
