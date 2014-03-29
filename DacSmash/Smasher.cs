using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.SqlServer.Dac;

namespace DacSmash
{
    public class Smasher
    {
        private readonly string _dacPacFileName;
        private readonly Dictionary<string, string> _sqlCmdVars;
        private readonly string _targetConnectionString;
        private readonly string _targetDatabase;

        public Smasher(string targetConnectionString, string dacPacFileName, string targetDatabase,
            Dictionary<string, string> sqlCmdVars)
        {
            _targetConnectionString = targetConnectionString;
            _dacPacFileName = dacPacFileName;
            _targetDatabase = targetDatabase;
            _sqlCmdVars = sqlCmdVars;
        }

        public void Smash(DacDeployOptions dacDeployOptions)
        {
            var dacServices = new DacServices(_targetConnectionString);
            dacServices.Message += (sender, args) => Debug.WriteLine(args.Message);
            dacServices.ProgressChanged += (sender, args) => Debug.WriteLine(args.Message + " " + args.Status);
            using (DacPackage dacPackage = DacPackage.Load(_dacPacFileName))
            {
                var deployOptions = dacDeployOptions;
                _sqlCmdVars.ToList().ForEach(deployOptions.SqlCommandVariableValues.Add);
                dacServices.Deploy(dacPackage, _targetDatabase, true, deployOptions);
            }
        }

        public void Smash()
        {
            var deployOptions = new DacDeployOptions();
            Smash(deployOptions);
        }
    }
}