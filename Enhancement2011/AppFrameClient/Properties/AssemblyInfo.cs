using System.Reflection;
using System.Runtime.InteropServices;
using log4net.Config;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("AppFrameClient")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Coral Software")]
[assembly: AssemblyProduct("AppFrameClient")]
[assembly: AssemblyCopyright("Copyright © Coral Software 2008")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("fb98fa58-7dd4-4300-a94b-62a7a64b7392")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//





[assembly: AssemblyVersion("1.5.0.0")]
[assembly: AssemblyFileVersion("1.5.0.0")]

// Configure log4net.
[assembly: XmlConfigurator(Watch = true)]
//[assembly: Log(AttributeTargetTypes = "AppFrame.Logic.*", EntryLevel = LogLevel.Error, ExitLevel = LogLevel.Error, ExceptionLevel = LogLevel.Error)]