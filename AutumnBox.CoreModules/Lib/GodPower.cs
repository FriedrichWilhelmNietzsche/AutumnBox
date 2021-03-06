﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/9/19 20:54:58 (UTC +8:00)
** desc： ...
*************************************************/
using AutumnBox.Basic.Calling.Adb;
using AutumnBox.Basic.Device;
using AutumnBox.Basic.Util;
using AutumnBox.OpenFramework.Content;
using System;
using System.IO;

namespace AutumnBox.CoreModules.Lib
{
    [Obsolete("Please use CstmDpmCommander to instead",true)]
    internal class GodPower : DeviceCommander
    {
        private const string FMT_CMD =
    "CLASSPATH=" + GODPOWER_APK_ON_DEVICE +
    " app_process /system/bin " + INNER_CLASS + " {0}";
        private const string INNER_CLASS = "com.web1n.myapplication.test";
        private const string GODPOWER_APK_ON_DEVICE = "/data/local/tmp/godpower.apk";
        private const string ARG_RM_ALL_ACC = "-removeAllAccounts";
        private const string ARG_RM_ALL_USR = "-removeAllUsers";
        private const string ARG_SET_ICE_BOX = "-setUpIcebox";
        private const string ARG_SET_STP_APP = "-setUpStopapp";
        private const string GODPOWER_APK_INNER_RES = "Res.godpower.apk";
        public ShellCommand GetRemoveUserCommand()
        {
            var cmd = string.Format(FMT_CMD, ARG_RM_ALL_USR);
            return CmdStation.GetShellCommand(Device, cmd);
        }
        public ShellCommand GetRemoveAccountCommnad()
        {
            var cmd = string.Format(FMT_CMD, ARG_RM_ALL_ACC);
            return CmdStation.GetShellCommand(Device, cmd);
        }
        public ShellCommand GetSetIceBoxCommand()
        {
            var cmd = string.Format(FMT_CMD, ARG_SET_ICE_BOX);
            return CmdStation.GetShellCommand(Device, cmd);
        }
        public ShellCommand GetSetStopAppCommand()
        {
            var cmd = string.Format(FMT_CMD, ARG_SET_STP_APP);
            return CmdStation.GetShellCommand(Device, cmd);
        }
        public AdbCommand GetPushCommand()
        {
            return  CmdStation.GetAdbCommand(Device, $"push \"{file.FullName}\" {GODPOWER_APK_ON_DEVICE}");
        }
        private FileInfo file;
        public void Extract()
        {
            file = new FileInfo(Path.Combine(ctx.Tmp.Path, "godpower.apk"));
            ctx.EmbFileManager
                .Get(GODPOWER_APK_INNER_RES)
                .ExtractTo(file);
        }
        public void Push()
        {
            GetPushCommand().Execute().ThrowIfExitCodeNotEqualsZero();
        }

        public void RemoveAllUser()
        {
            GetRemoveUserCommand().Execute().ThrowIfExitCodeNotEqualsZero();
        }
        public void RemoveAllAccount()
        {
            GetRemoveAccountCommnad().Execute().ThrowIfExitCodeNotEqualsZero();
        }
        public void SetIceBox()
        {
            GetSetIceBoxCommand().Execute().ThrowIfExitCodeNotEqualsZero();
        }
        public void SetStopApp()
        {
            GetSetStopAppCommand();
        }
        private readonly Context ctx;
        public GodPower(Context ctx, IDevice device) : base(device)
        {
            this.ctx = ctx;
        }
    }
}
