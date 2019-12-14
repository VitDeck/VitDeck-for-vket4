using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator
{
    public class A02_VRCSDKVersionRule : BaseRule
    {
        const string versionFilePath = "Assets/VRCSDK/version.txt";

        const string sdkDownloadURL = "https://www.vrchat.net/download/sdk";

        private VRCSDKVersion targetVersion;

        public A02_VRCSDKVersionRule(string name, VRCSDKVersion version) : base(name)
        {
            targetVersion = version;
        }

        protected override void Logic(ValidationTarget target)
        {

            if (!File.Exists(versionFilePath))
            {
                AddIssue(new Issue(null,
                    IssueLevel.Error,
                    "VRCSDKがインポートされていません。",
                    "公式サイトからダウンロードし、インポートして下さい。",
                    solutionURL: "https://www.vrchat.net/download/sdk"
                    ));
                return;
            }

            var currentVersion = new VRCSDKVersion(File.ReadAllText(versionFilePath));

            if (currentVersion < targetVersion)
            {
                AddIssue(new Issue(null,
                    IssueLevel.Error,
                    "VRCSDKが最新バージョンではありません。",
                    "公式サイトからダウンロードし、インポートして下さい。",
                    solutionURL: "https://www.vrchat.net/download/sdk"
                    ));
            }
        }
    }
}