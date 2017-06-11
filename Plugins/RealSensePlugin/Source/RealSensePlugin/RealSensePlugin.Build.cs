/////////////////////////////////////////////////////////////////////////////////////////////
// Copyright 2017 Intel Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
/////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.IO;

namespace UnrealBuildTool.Rules 
{
	public class RealSensePlugin : ModuleRules 
    {
        public RealSensePlugin(TargetInfo Target)
        {
            // https://answers.unrealengine.com/questions/51798/how-can-i-enable-unwind-semantics-for-c-style-exce.html
            UEBuildConfiguration.bForceEnableExceptions = true;

            PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine" });
            PrivateDependencyModuleNames.AddRange(new string[] { "RHI", "RenderCore", "ShaderCore" });

            PrivateIncludePaths.AddRange(new string[] { "RealSensePlugin/Private" });

            string RealSenseDirectory = Environment.GetEnvironmentVariable("RSSDK_DIR");
            string RealSenseIncludeDirectory = Path.Combine(RealSenseDirectory,"include");
            PublicIncludePaths.Add(RealSenseIncludeDirectory);

            if (Target.Platform == UnrealTargetPlatform.Win32)
            {
                string RealSenseLibrary32Directory = Path.Combine(RealSenseDirectory, "lib\\Win32\\libpxc.lib");
                PublicAdditionalLibraries.Add(RealSenseLibrary32Directory);
            }
            else if (Target.Platform == UnrealTargetPlatform.Win64)
            {
                string RealSenseLibrary64Directory = Path.Combine(RealSenseDirectory, "lib\\x64\\libpxc.lib");
                PublicAdditionalLibraries.Add(RealSenseLibrary64Directory);
            }
        }
	}
}
