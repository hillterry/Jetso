
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DmFramework;
using Jetso.AuctionAgent;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
#if NET_2_0
[assembly: AssemblyTitle("Jetso.AuctionAgent for .NetFx2.0")]
#elif NET_2_3_5
[assembly: AssemblyTitle("Jetso.AuctionAgent for .NetFx2.3.5")]
#elif NET_3_5
[assembly: AssemblyTitle("Jetso.AuctionAgent for .NetFx3.5")]
#elif NET_4_0
[assembly: AssemblyTitle("Jetso.AuctionAgent for .NetFx4.0")]
#endif
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Jetso.AuctionAgent (Flavor=Debug)")]
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("Jetso.AuctionAgent (Flavor=Retail)")]
#endif
[assembly: AssemblyCompany(AssemblyInfo.AssemblyCompany)]
[assembly: AssemblyProduct("Jetso.AuctionAgent")]
[assembly: AssemblyCopyright(AssemblyInfo.AssemblyCopyright)]
[assembly: AssemblyTrademark("Jetso.AuctionAgent")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]
// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("C32961B2-84BD-43E8-88E2-3FC7DC21517A")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“内部版本号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(AssemblyInfo.Version + "*")]
[assembly: AssemblyFileVersion(AssemblyInfo.FileVersion + AssemblyBuild.VersionBuild)]
