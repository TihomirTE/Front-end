using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Enums;

namespace PackageManager.Commands
{
    internal class ExtendedInstallCommand : InstallCommand
    {
        public ExtendedInstallCommand(IInstaller<IPackage> installer, IPackage package)
            : base(installer, package)
        {
        }
        public IInstaller<IPackage> Installer
        {
            get
            {
                return this.installer;
            }
        }

        public IPackage Package
        {
            get
            {
                return this.package;
            }
        }

        public InstallerOperation Operation { get; set; }
            
               
    }
}
