using System;
using System.IO;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Int19h.Bannerlord.CSharp.Scripting {
    public class SubModule : MBSubModuleBase {
        protected override void OnSubModuleLoad() {
            try {
                File.WriteAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_load.log", 
                    $"C# Scripting mod loaded at {DateTime.Now}\n");
                
                // Initialize scripting engine directly without Scripts class
                try {
                    // Create script options with TaleWorlds namespace imports and ScriptGlobals
                    var scriptOptions = Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default
                        .WithImports(
                            "System",
                            "System.Collections.Generic", 
                            "System.Linq",
                            "TaleWorlds.CampaignSystem",
                            "TaleWorlds.CampaignSystem.Party",
                            "TaleWorlds.CampaignSystem.Settlements",
                            "TaleWorlds.Core",
                            "TaleWorlds.Library",
                            "TaleWorlds.MountAndBlade",
                            "Int19h.Bannerlord.CSharp.Scripting",
                            "static Int19h.Bannerlord.CSharp.Scripting.ScriptGlobals"
                        );
                    
                    // Create a basic script with TaleWorlds imports
                    var script = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.Create("", scriptOptions);
                    var evalState = script.RunAsync().GetAwaiter().GetResult();
                    
                    // Use reflection to set the evalState in Commands class
                    var commandsType = typeof(Commands);
                    var evalStateField = commandsType.GetField("evalState", 
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                    if (evalStateField != null) {
                        evalStateField.SetValue(null, evalState);
                        File.AppendAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_load.log", 
                            $"Direct scripting engine initialized at {DateTime.Now}\n");
                    } else {
                        File.AppendAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_error.log", 
                            $"Could not find evalState field at {DateTime.Now}\n");
                    }
                } catch (Exception ex) {
                    File.AppendAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_error.log", 
                        $"Direct scripting init failed: {ex}\n");
                }
                
                File.AppendAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_load.log", 
                    $"Scripting engine initialized at {DateTime.Now}\n");
            } catch (Exception ex) {
                try {
                    File.WriteAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_error.log", 
                        $"OnSubModuleLoad failed: {ex}\n");
                } catch { }
            }
        }

        protected override void OnGameStart(Game game, IGameStarter starter) {
            try {
                File.AppendAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_load.log", 
                    $"OnGameStart called at {DateTime.Now}\n");
                
                base.OnGameStart(game, starter);
                
                // Skip complex initialization for now
                // if (starter is CampaignGameStarter campaignStarter) {
                //     campaignStarter.AddBehavior(new CampaignBehavior());
                // }
                
                File.AppendAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_load.log", 
                    $"OnGameStart completed at {DateTime.Now}\n");
            } catch (Exception ex) {
                try {
                    File.WriteAllText("C:\\ProgramData\\Mount and Blade II Bannerlord\\logs\\csharp_scripting_error.log", 
                        $"OnGameStart failed: {ex}\n");
                } catch { }
            }
        }
    }
}
